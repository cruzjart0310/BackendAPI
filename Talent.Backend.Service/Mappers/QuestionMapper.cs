using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Mappers
{
    public static class QuestionMapper
    {
        public static Question Map(Talent.Backend.Service.Dtos.QuestionDto QuestionDto)
        {
            return new Question
            {
                Id = QuestionDto.Id,
                Title = QuestionDto.Title,
                //Questions = QuestionDto.Questions.Select(q => new Question
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

        public static Talent.Backend.Service.Dtos.QuestionDto Map(Question Question)
        {
            return new Dtos.QuestionDto
            {
                Id = Question.Id,
                Title = Question.Title,
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
