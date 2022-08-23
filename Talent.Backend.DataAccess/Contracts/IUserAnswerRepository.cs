using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.DataAccessEF.Contracts
{
    public interface IUserAnswerRepository : IGenericRepository<UserAnswer>, IUserPoint
    {
    }
}
