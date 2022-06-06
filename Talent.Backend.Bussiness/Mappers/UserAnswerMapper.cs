using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.Bussiness.Mappers
{
    public class UserAnswerMapper
    {
        public static UserAnswer Map(Talent.Backend.Bussiness.Models.UserAnswer userAnswer)
        {
            if (userAnswer == null)
                return null;

            return new UserAnswer
            {
                Id = userAnswer.Id,
                User = new User
                {
                    Id = userAnswer.User.Id,
                    FirstName = userAnswer.User.FirstName
                },
                Answer = userAnswer?.Answer?.Select(u => new Answer
                {
                    Id = u.Id,
                    Title = u.Title
                }).ToList(),
                CreatedAt = userAnswer.CreatedAt,
            };
        }

        public static Talent.Backend.Bussiness.Models.UserAnswer Map(UserAnswer userAnswer)
        {
            if (userAnswer == null)
                return null;

            return new Models.UserAnswer
            {
                Id = userAnswer.Id,
                User = new Models.User
                {
                    Id = userAnswer.User.Id,
                    FirstName = userAnswer.User.FirstName
                },
                Answer = userAnswer?.Answer?.Select(u => new Talent.Backend.Bussiness.Models.Answer
                {
                    Id = u.Id,
                    Title = u.Title
                }).ToList(),
                CreatedAt = userAnswer.CreatedAt,
            };
        }
    }
}
