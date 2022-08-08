using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Talent.Backend.DataAccessEF.Contracts
{
    public  interface IFileDataUploaded
    {
        Task SaveDataFromFile(IFormFile file);  
    }
}
