using System.Collections.Generic;
using System.Linq;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class SurveyMapper
    {
        public static Survey Map(Talent.Backend.Bussiness.Models.Survey survey)
        {
            return new Survey
            {
                Id = survey.Id,
                Name = survey.Name,
                Questions = survey?.Questions.Select(q => new Question
                {
                    Id = q.Id,
                    Title = q.Title,
                    CreatedAt = q.CreatedAt,
                    Type = new QuestionType
                    {
                        Id = q.Type.Id,
                        Title = q.Type.Title,
                        CreatedAt = q.Type.CreatedAt
                    },
                    Answers = survey?.Questions.Select(a => new Answer
                    {
                        Id = a.Id,
                        Title = a.Title,
                        CreatedAt = a.CreatedAt,
                    })
                }),
                CreatedAt = survey.CreatedAt,
                UpdatedAt = survey.UpdatedAt,
                DeletedAt = survey.DeletedAt,
            };
        }

        public static Talent.Backend.Bussiness.Models.Survey Map(Survey survey)
        {
            return new Models.Survey
            {
                Id = survey.Id,
                Name = survey.Name,
                Questions = survey?.Questions?.Select(q => new Talent.Backend.Bussiness.Models.Question
                {
                    Id = q.Id,
                    Title = q.Title,
                    CreatedAt = q.CreatedAt,
                    Type = new Talent.Backend.Bussiness.Models.QuestionType
                    {
                        Id = q.Type.Id,
                        Title = q.Type.Title,
                        CreatedAt = q.Type.CreatedAt
                    },
                    Answers = q?.Answers.Select(a => new Talent.Backend.Bussiness.Models.Answer
                    {
                        Id = a.Id,
                        Title = a.Title,
                        CreatedAt = a.CreatedAt,
                    })
                }),
                CreatedAt = survey.CreatedAt,
                UpdatedAt = survey.UpdatedAt,
                DeletedAt = survey.DeletedAt,
            };
        }
    }
}
