using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Mappers
{
    public static class QuestionTypeMapper
    {
        public static QuestionType Map(Talent.Backend.Service.Dtos.QuestionTypeDto questionTypeDto)
        {
            return new QuestionType
            {
                Id = questionTypeDto.Id,
                Title = questionTypeDto.Title,
            };
        }

        public static Talent.Backend.Service.Dtos.QuestionTypeDto Map(QuestionType questionType)
        {
            return new Dtos.QuestionTypeDto
            {
                Id = questionType.Id,
                Title = questionType.Title,
            };
        }
    }
}
