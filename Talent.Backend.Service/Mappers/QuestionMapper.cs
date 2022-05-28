using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Mappers
{
    public static class QuestionMapper
    {
        public static Question Map(Talent.Backend.Service.Dtos.QuestionDto questionDto)
        {
            return new Question
            {
                Id = questionDto.Id,
                Title = questionDto.Title,
                TypeId = questionDto.TypeId,
                SurveyId = questionDto.SurveyId,
                CreatedAt = questionDto.CreatedAt,
                Type = new QuestionType
                {
                    Id = questionDto?.Type?.Id,
                    Title = questionDto?.Type?.Title,
                    //        CreatedAt = q.Type.CreatedAt
                },
                Survey = new Survey
                {
                    Id = questionDto?.Survey?.Id,
                    Name = questionDto?.Survey?.Name,
                }
                //Type = QuestionDto.Questions.Select(q => new Question
                //{
                //    Id = q.Id,
                //    Title = q.Title,
                //    CreatedAt = q.CreatedAt,
                //    Type = new QuestionType
                //    {
                //        Id = q.Type.Id,
                //        Title = q.Type.Title,
                //        CreatedAt = q.Type.CreatedAt
                //    },
                //    Answers = q.Answers.Select(a => new Answer
                //    {
                //        Id = a.Id,
                //        Title = a.Title,
                //        CreatedAt = a.CreatedAt,
                //    })
                //}),

                //2300 = 45000
                //3000 = 62000
            };
        }

        public static Talent.Backend.Service.Dtos.QuestionDto Map(Question question)
        {
            return new Dtos.QuestionDto
            {
                Id = question.Id,
                Title = question.Title,
                TypeId = question.TypeId,
                SurveyId = question.SurveyId,
                CreatedAt = question.CreatedAt,
                Type = new QuestionTypeDto
                {
                    Id = question?.Type?.Id,
                    Title = question?.Type?.Title,
                    //        CreatedAt = q.Type.CreatedAt
                },
                Survey = new Dtos.SurveyDto
                {
                    Id = question?.Survey?.Id,
                    Name = question?.Survey?.Name,
                }
                //Questions = Question?.Questions?.Select(q => new Talent.Backend.Service.Dtos.QuestionDto
                //{
                //    Id = q.Id,
                //    Title = q.Title,
                //    CreatedAt = q.CreatedAt,
                //    Type = new Talent.Backend.Service.Dtos.QuestionTypeDto
                //    {
                //        Id = q.Type.Id,
                //        Title = q.Type.Title,
                //        CreatedAt = q.Type.CreatedAt
                //    },
                //    Answers = q.Answers.Select(a => new Talent.Backend.Service.Dtos.AnswerDto
                //    {
                //        Id = a.Id,
                //        Title = a.Title,
                //        CreatedAt = a.CreatedAt,
                //    })
                //}),
            };
        }
    }
}
