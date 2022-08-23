namespace Talent.Backend.DataAccessEF.Models
{
    public class UserForRegistration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPassword { get; set; }
        public string ClientURI { get; set; }
    }
}
