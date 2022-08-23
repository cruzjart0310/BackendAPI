using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class AnswerMapper
    {
        public static Answer Map(Talent.Backend.Bussiness.Models.Answer answer)
        {
            return new Answer
            {
                Id = answer.Id,
                Title = answer.Title,
                QuestionId = answer.QuestionId,
                CreatedAt = answer.CreatedAt,
                Question = new Question
                {
                    Id = answer.Question.Id,
                    Title = answer?.Question.Title,
                }
            };
        }

        public static Talent.Backend.Bussiness.Models.Answer Map(Answer answer)
        {
            return new Models.Answer
            {
                Id = answer.Id,
                Title = answer.Title,
                QuestionId = answer.QuestionId,
                CreatedAt = answer.CreatedAt,
                Question = new Models.Question
                {
                    Id = answer?.Question?.Id,
                    Title = answer?.Question?.Title,
                }
            };
        }
    }
}
