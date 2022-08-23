using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUriService _uriService;
        public AccountController(IAccountService accountService, IUriService uriService)
        {
            _accountService = accountService;
            _uriService = uriService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] UserForRegistrationDto userDto)
        {
            var result = await _accountService.CreateAsync(userDto);
            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(new { result.Errors });
            }
            return Ok(201);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            var result = await _accountService.LoginAsync(userForAuthenticationDto);
            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(new { result.Errors });
            }
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Confirm")]
        public async Task<ActionResult> Confirm(string email, string token)
        {
            var result = await _accountService.EmailConfirmationAsync(email, token);
            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(new { result.Errors });
            }
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("LogOut")]
        public async Task<ActionResult> LogOut()
        {
            await _accountService.LogOutAsync();

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            var result = await _accountService.ForgotPasswordAsync(email);
            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(new { result.Errors });
            }
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(string email)
        {
            var result = await _accountService.ForgotPasswordAsync(email);
            if (result.Errors != null && result.Errors.Any())
            {
                return BadRequest(new { result.Errors });
            }
            return Ok();
        }
    }
}
