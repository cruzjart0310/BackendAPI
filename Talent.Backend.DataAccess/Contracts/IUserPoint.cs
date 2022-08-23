using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.DataAccessEF.Contracts
{
    public interface IUserPoint
    {
        Task<UserPointResponse<User>> GetPointsAsync(string userId, int surveyId);
    }
}
