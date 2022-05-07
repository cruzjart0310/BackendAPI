using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Dtos
{
    public class UserResponsibleDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
