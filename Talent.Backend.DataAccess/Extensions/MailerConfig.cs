using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Email.Models;

namespace Talent.Backend.DataAccessEF.Extensions
{
    public static class MailerConfig
    {
        public static Message getMessage(string urlClient, Dictionary<string, string> dicParams)
        {
            var callback = QueryHelpers.AddQueryString(urlClient, dicParams);
            var message = new Message(new string[] { "cruzjart@gmail.com" }, "Email Confirmation token", callback, null);
            return message;
        }

        public static Message getMessage(string urlClient,string email)
        {
            var content = $"Your account is locked out. To reset the password click this link: {urlClient = "http://localhost:44333/authentication/forgotpassword"}";
            var message = new Message(new string[] { email }, "Locked out account information", content, null);
            return message;
        }

        public static Message getMessage(string urlClient, string email, Dictionary<string, string> dicParams)
        {
            var callback = QueryHelpers.AddQueryString(urlClient, dicParams);
            var message = new Message(new string[] { email }, "Reset password token", callback, null);
            return message;
        }
    }
}
