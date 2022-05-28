using System.Collections.Generic;
using System.Linq;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class QuestionTypeMapper
    {
        public static QuestionType Map(Talent.Backend.Bussiness.Models.QuestionType Question)
        {
            return new QuestionType
            {
                Id = Question.Id,
                Title = Question.Title,
                //CreatedAt = Question.CreatedAt,
            };
        }

        public static Talent.Backend.Bussiness.Models.QuestionType Map(QuestionType Question)
        {
            return new Models.QuestionType
            {
                Id = Question.Id,
                Title = Question.Title,
                //CreatedAt = Question.CreatedAt
            };
        }
    }
}
