namespace Talent.Backend.Bussiness.Models
{
    public class UserForAuthentication
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClientUri { get; set; }
    }
}
