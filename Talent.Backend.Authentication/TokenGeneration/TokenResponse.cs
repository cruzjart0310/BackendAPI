using System;

namespace Talent.Backend.Authentication.TokenGeneration
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
