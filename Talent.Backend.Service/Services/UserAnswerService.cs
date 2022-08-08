using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Service.Mappers;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly IUserAnswerBussiness _userAnswerBussiness;

        public UserAnswerService(IUserAnswerBussiness userAnswerBussiness)
        {
            _userAnswerBussiness = userAnswerBussiness;
        }

        public async Task<UserAnswerDto> CreateAsync(UserAnswerDto userAnswerDto)
        {
            var userAnswerMap = UserAnswerMapper.Map(userAnswerDto);
            var userAnswer = await _userAnswerBussiness.CreateAsync(userAnswerMap);
            return UserAnswerMapper.Map(userAnswer);
        }

        public async Task DeleteAsync(int id)
        {
            await _userAnswerBussiness.DeleteAsync(id);
        }

        public async Task<bool> ExistAsync(int id) => await _userAnswerBussiness.ExistAsync(id);

        public async Task<IEnumerable<UserAnswerDto>> GetAllAsync(PaginationDto paginationDto)
        {
            var surveys = await _userAnswerBussiness.GetAllAsync(PaginationMapper.Map(paginationDto));

            return surveys.Select(UserAnswerMapper.Map);
        }

        public async Task<UserPointResponseDto<UserDto>> GetPointsAsync(string userId, int surveyId)
        {
            var mapper =  await _userAnswerBussiness.GetPointsAsync(userId, surveyId);

            return UserPointMapper.Map(mapper);
        }

        public async Task<UserAnswerDto> GetAsync(int id)
        {
            var userAnswer = await _userAnswerBussiness.GetAsync(id);
            return UserAnswerMapper.Map(userAnswer);
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            return _userAnswerBussiness.GetTotalRecorsdAsync();
        }

        public async Task UpdateAsync(int id, UserAnswerDto surveyDto)
        {
            var userAnswerMap = UserAnswerMapper.Map(surveyDto); ;
            await _userAnswerBussiness.UpdateAsync(id, userAnswerMap);
        }
    }
}
