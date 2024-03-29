﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Authentication.TokenGeneration;
using Talent.Backend.DataAccessEF.Contracts;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Extensions;
using Talent.Backend.DataAccessEF.Models;
using Talent.Backend.Email.Contracts;

namespace Talent.Backend.DataAccessEF.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public AccountRepository(EFContext context,
            IEmailSender emailSender,
            IConfiguration configuration,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<AccountResponse<User>> CreateAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.UserProfile = new UserProfile();
            user.UserProfile.Avatar = "avatar.png";
            user.UserProfile.UserId = user.Id;
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return new AccountResponse<User>
                {
                    Errors = errors,
                };
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await _emailSender.SendEmailAsync(MailerConfig.getMessage(user.Url = "https://localhost:44327/api/account/confirm", new Dictionary<string, string>
            {
                {"token", token },
                {"email", user.Email }
            }));

            await _userManager.AddToRoleAsync(user, "User");

            return new AccountResponse<User>
            {
                Element = user,
            };
        }

        public async Task<AccountResponse<User>> EmailConfirmationAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new AccountResponse<User>
                {
                    Errors = new List<string>()
                    {
                        "User not found"
                    }
                };
            }

            var confirmation = await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmation.Succeeded)
            {
                return new AccountResponse<User>
                {
                    Errors = new List<string>()
                    {
                        "Email not confirmed"
                    }
                };
            }

            return new AccountResponse<User>
            {
                Element = user
            };
        }

        public async Task<User> FindByNameAsync(string email) =>
            await _userManager.FindByNameAsync(email);

        public async Task<AccountResponse<User>> ForgotPasswordAsync(string email, string clientUrl)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new AccountResponse<User>
                {
                    Errors = new List<string>()
                    {
                        "User not found"
                    }
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _emailSender.SendEmailAsync(MailerConfig.getMessage(clientUrl, email, new Dictionary<string, string>
            {
                {"token", token },
                {"email", user.Email }
            }));

            return new AccountResponse<User>
            {
                Element = user
            };
        }

        public async Task<AccountResponse<User>> EmailConfirmedAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new AccountResponse<User>
                {
                    Errors = new List<string>()
                    {
                        "User not found"
                    }
                };

            var confirmation = await _userManager.ConfirmEmailAsync(user, token);
            if (confirmation.Succeeded)
                return new AccountResponse<User>
                {
                    Errors = new List<string>()
                    {
                        "Invalid Email Confirmation request"
                    }
                };

            return new AccountResponse<User>
            {
                Element = user
            };
        }

        public async Task<TokenRespose<User>> LoginAsync(UserForAuthentication userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            if (user == null)
            {
                return new TokenRespose<User>
                {
                    Errors = new List<string>()
                    {
                        "User not found"
                    }
                };
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return new TokenRespose<User>
                {
                    Errors = new List<string>()
                    {
                        "Email is not confirmed"
                    }
                };
            }

            if (!await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            {
                await _userManager.AccessFailedAsync(user);
                if (await _userManager.IsLockedOutAsync(user))
                {
                    await _emailSender.SendEmailAsync(MailerConfig.getMessage(userForAuthentication.ClientUri, userForAuthentication.Email));

                    return new TokenRespose<User>
                    {
                        Errors = new List<string>()
                        {
                            "The account is locked out"
                        }
                    };
                }

                return new TokenRespose<User>
                {
                    Errors = new List<string>()
                    {
                        "Invalid Autentication"
                    }
                };
            }

            var result = await _signInManager.PasswordSignInAsync(userForAuthentication.Email, userForAuthentication.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return new TokenRespose<User>
                {
                    Errors = new List<string>()
                    {
                        "Invalid Login"
                    }
                };
            }

            var userByEmail = await _userManager.FindByEmailAsync(userForAuthentication.Email);
            var claims = await _userManager.GetClaimsAsync(userByEmail);
            var tokenGeneration = ClsJwtSecurityToken.GetToken(userForAuthentication.Email, claims, _configuration);

            return new TokenRespose<User>
            {
                Token = tokenGeneration.Token,
                Expiration = tokenGeneration.Expiration,
            };
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AccountResponse<User>> ResetPasswordAsync(ResetPassword entity)
        {
            var user = await _userManager.FindByEmailAsync(entity.Email);
            if (user == null)
                return new AccountResponse<User>
                {
                    Errors = new List<string>()
                    {
                        "User not found"
                    }
                };

            var resetPassResult = await _userManager.ResetPasswordAsync(user, entity.Token, entity.Password);
            if (!resetPassResult.Succeeded)
            {
                var errors = resetPassResult.Errors.Select(e => e.Description).ToList();
                return new AccountResponse<User>
                {
                    Errors = errors
                };
            }

            await _userManager.SetLockoutEndDateAsync(user, new DateTime(2000, 1, 1));

            return new AccountResponse<User>
            {
                Element = user
            };
        }
    }
}
