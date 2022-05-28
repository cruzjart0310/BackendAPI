using System.Collections.Generic;
using System.Linq;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class QuestionMapper
    {
        public static Question Map(Talent.Backend.Bussiness.Models.Question question)
        {
            return new Question
            {
                Id = question.Id,
                Title = question.Title,
                TypeId = question.TypeId,   
                SurveyId = question.SurveyId,   
                CreatedAt = question.CreatedAt,
                Type = new QuestionType
                {
                    Id = question?.Type?.Id,
                    Title = question?.Type?.Title,
                    //        CreatedAt = q.Type.CreatedAt
                },
                Survey = new Survey
                {
                    Id = question?.Survey?.Id,
                    Name = question?.Survey?.Name,
                }
                //Questions = Question.Questions.Select(q => new Question
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
                //    Answers = Question?.Questions.Select(a => new Answer
                //    {
                //        Id = a.Id,
                //        Title = a.Title,
                //        CreatedAt = a.CreatedAt,
                //    })
                //}),
            };
        }

        public static Talent.Backend.Bussiness.Models.Question Map(Question question)
        {
            return new Models.Question
            {
                Id = question.Id,
                Title = question.Title,
                TypeId = question.TypeId,
                SurveyId = question.SurveyId,
                CreatedAt = question.CreatedAt,
                Type = new Models.QuestionType
                {
                    Id = question?.Type?.Id,
                    Title = question?.Type?.Title,
                    //        CreatedAt = q.Type.CreatedAt
                },
                Survey = new Models.Survey
                {
                    Id = question?.Survey?.Id,
                    Name = question?.Survey?.Name,
                }
                //Questions = Question?.Questions?.Select(q => new Talent.Backend.Bussiness.Models.Question
                //{
                //    Id = q.Id,
                //    Title = q.Title,
                //    CreatedAt = q.CreatedAt,
                //    Type = new Talent.Backend.Bussiness.Models.QuestionType
                //    {
                //        Id = q.Type.Id,
                //        Title = q.Type.Title,
                //        CreatedAt = q.Type.CreatedAt
                //    },
                //    Answers = q?.Answers.Select(a => new Talent.Backend.Bussiness.Models.Answer
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
