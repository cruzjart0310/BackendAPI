using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Mappers
{
    public static class UserAnswerMapper
    {
        public static UserAnswerDto Map(Talent.Backend.Bussiness.Models.UserAnswer userAnswer)
        {
            if (userAnswer == null)
                return null;

            return new UserAnswerDto
            {
                Id = userAnswer.Id,
                User = new UserAnswerAssignDto
                {
                    Id = userAnswer.User.Id,
                    FirstName = userAnswer.User.FirstName
                },
                Answer = userAnswer?.Answer?.Select(u => new AnswerAssingDto
                {
                    Id = u.Id,
                    Title = u.Title
                }).ToList(),
                CreatedAt = userAnswer.CreatedAt,
            };
        }

        public static Talent.Backend.Bussiness.Models.UserAnswer Map(UserAnswerDto userAnswerDto)
        {
            if (userAnswerDto == null)
                return null;

            return new Talent.Backend.Bussiness.Models.UserAnswer
            {
                Id = userAnswerDto.Id,
                User = new Talent.Backend.Bussiness.Models.User
                {
                    Id = userAnswerDto.User.Id,
                    FirstName = userAnswerDto.User.FirstName
                },
                Answer = userAnswerDto?.Answer?.Select(u => new Talent.Backend.Bussiness.Models.Answer
                {
                    Id = u.Id,
                    Title = u.Title
                }).ToList(),
                CreatedAt = userAnswerDto.CreatedAt,
            };
        }
    }
}
