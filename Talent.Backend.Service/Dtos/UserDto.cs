using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserProfileDto UserProfile { get; set; }
        public IEnumerable<TeamUserDto> Teams { get; set; }

        public UserDto()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
