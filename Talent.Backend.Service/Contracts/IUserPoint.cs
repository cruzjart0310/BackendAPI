using System.Threading.Tasks;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Contracts
{
    public interface IUserPoint
    {
        Task<UserPointResponseDto<UserDto>> GetPointsAsync(string userId, int surveyId);
    }
}
