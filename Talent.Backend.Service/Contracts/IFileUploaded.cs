using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Contracts
{
    public interface IFileUploaded
    {
        Task SaveDataFromFile(IFormFile file);
    }
}
