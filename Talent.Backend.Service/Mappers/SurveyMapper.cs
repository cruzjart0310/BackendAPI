using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Mappers
{
    public static class SurveyMapper
    {
        public static Survey Map(Talent.Backend.Service.Dtos.SurveyDto surveyDto)
        {
            if (surveyDto == null) return null;    

            return new Survey
            {
                Id = surveyDto.Id,
                Name = surveyDto.Name,
                Questions = surveyDto?.Questions?.Select(q => new Question
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
                        Point = a.Point,
                    }).ToList(),
                }).ToList(),
                CreatedAt = surveyDto.CreatedAt,
            };
        }

        public static Talent.Backend.Service.Dtos.SurveyDto Map(Survey survey)
        {
            if (survey == null) return null;

            return new Dtos.SurveyDto
            {
                Id = survey?.Id,
                Name = survey.Name,
                Questions = survey?.Questions?.Select(q => new Talent.Backend.Service.Dtos.QuestionDto
                {
                    Id = q.Id,
                    Title = q.Title,
                    Type = new Talent.Backend.Service.Dtos.QuestionTypeDto
                    {
                        Id = q?.Type.Id,
                        Title = q?.Type.Title,
                    },
                    Answers = q?.Answers?.Select(a => new Talent.Backend.Service.Dtos.AnswerDto
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Point = a.Point,
                    }).ToList()
                }).ToList(),
                CreatedAt = survey.CreatedAt,
            };
        }
    }
}
