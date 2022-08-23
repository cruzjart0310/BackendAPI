using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.DataAccessEF.Contracts
{
    public interface IQuestionRepository : IGenericRepository<Question>, IFileDataUploaded
    {

    }
}
