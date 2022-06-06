using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Bussiness.Mappers;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.DataAccessEF.Contracts;

namespace Talent.Backend.Bussiness
{
    public class UserAnswerBussiness : IUserAnswerBussiness
    {
        private readonly IUserAnswerRepository _userAnswerRepository;

        public UserAnswerBussiness(IUserAnswerRepository surveyRepository)
        {
            _userAnswerRepository = surveyRepository;
        }

        public async Task<UserAnswer> CreateAsync(UserAnswer userAnswer)
        {
            var userAnwerMap = UserAnswerMapper.Map(userAnswer); 
            var surveyRepository = await _userAnswerRepository.CreateAsync(userAnwerMap);
            return UserAnswerMapper.Map(surveyRepository);
        }

        public async Task DeleteAsync(int id)
        {
            await _userAnswerRepository.DeleteAsync(id);    
        }

        public async Task<bool> ExistAsync(int id) => await _userAnswerRepository.ExistAsync(id);   

        public async Task<IEnumerable<UserAnswer>> GetAllAsync(Pagination pagination)
        {
            var userAnswer = await _userAnswerRepository.GetAllAsync(PaginationMapper.Map(pagination));

            return userAnswer.Select(UserAnswerMapper.Map);
        }

        public async Task<UserAnswer> GetAsync(int id)
        {
            var userAnswer = await _userAnswerRepository.GetAsync(id);

            return UserAnswerMapper.Map(userAnswer);
        }

        public Task<int> GetTotalRecorsdAsync() => _userAnswerRepository.GetTotalRecorsdAsync();

        public async Task UpdateAsync(int id, UserAnswer userAnswer)
        {
            var userAnswerMap = UserAnswerMapper.Map(userAnswer);
            await _userAnswerRepository.UpdateAsync(id, userAnswerMap);
        }
    }
}
