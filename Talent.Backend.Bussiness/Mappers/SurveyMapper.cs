using System.Collections.Generic;
using System.Linq;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class SurveyMapper
    {
        public static Survey Map(Talent.Backend.Bussiness.Models.Survey survey)
        {
            if(survey == null) 
                return null;

            return new Survey
            {
                Id = survey.Id,
                Name = survey.Name,
                Questions = survey?.Questions?.Select(q => new Question
                {
                    Id = q.Id,
                    Title = q.Title,
                    Type = new QuestionType
                    {
                        Id = q?.Type.Id,
                        Title = q?.Type.Title,
                    },
                    Answers = q?.Answers?.Select(a => new Answer
                    {
                        Id = a.Id,
                        Title = a.Title,
                        IsCorrect = a.IsCorrect,
                    }).ToList(),
                }).ToList(),
                CreatedAt = survey.CreatedAt,   
            };
        }

        public static Talent.Backend.Bussiness.Models.Survey Map(Survey survey)
        {
            if (survey == null)
                return null;

            return new Models.Survey
            {
                Id = survey.Id,
                Name = survey.Name,
                Questions = survey?.Questions?.Select(q => new Talent.Backend.Bussiness.Models.Question
                {
                    Id = q.Id,
                    Title = q.Title,
                    Type = new Talent.Backend.Bussiness.Models.QuestionType
                    {
                        Id = q?.Type.Id,
                        Title = q?.Type.Title,
                    },
                    Answers = q?.Answers?.Select(a => new Talent.Backend.Bussiness.Models.Answer
                    {
                        Id = a.Id,
                        Title = a.Title,
                        IsCorrect = a.IsCorrect,
                    }).ToList()
                }).ToList(),
                CreatedAt = survey.CreatedAt,
            };
        }
    }
}
