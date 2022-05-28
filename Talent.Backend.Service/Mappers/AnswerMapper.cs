using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Mappers
{
    public static class AnswerMapper
    {
        public static Answer Map(Talent.Backend.Service.Dtos.AnswerDto answerDto)
        {
            return new Answer
            {
                Id = answerDto.Id,
                Title = answerDto.Title,
                QuestionId = answerDto.QuestionId,
                CreatedAt = answerDto.CreatedAt,
                Question = new Question
                {
                    Id = answerDto?.Question?.Id,
                    Title = answerDto?.Question.Title,
                }
            };
        }

        public static Talent.Backend.Service.Dtos.AnswerDto Map(Answer answer)
        {
            return new Dtos.AnswerDto
            {
                Id = answer.Id,
                Title = answer.Title,
                QuestionId = answer.QuestionId,
                CreatedAt = answer.CreatedAt,
                Question = new Dtos.QuestionDto
                {
                    Id = answer.Question.Id,
                    Title = answer?.Question.Title,
                }
            };
        }
    }
}
