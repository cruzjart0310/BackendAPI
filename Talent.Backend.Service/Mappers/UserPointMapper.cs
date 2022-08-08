using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Mappers
{
    public static class UserPointMapper
    {
        public static UserPointResponseDto<UserDto> Map(Bussiness.Models.UserPointResponse<User> userPointResponse)
        {
            return new UserPointResponseDto<UserDto>
            {
                Element = new UserDto
                {
                    Id =    userPointResponse.Element.Id,
                    FirstName = userPointResponse.Element.FirstName,    
                    LastName = userPointResponse.Element.LastName,  
                },
                Points = userPointResponse.Points
            };
        }
    }
}
