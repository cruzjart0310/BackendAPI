namespace Talent.Backend.Service.Dtos
{
    public class UserForAuthenticationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClientUri { get; set; }
    }
}
