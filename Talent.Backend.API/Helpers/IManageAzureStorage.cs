using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Talent.Backend.API.Helpers
{
    public interface IManageAzureStorage
    {
        Task DeleteFile(string path, string container);
        Task<string> SaveFile(string container, IFormFile file);
        Task<string> UpdateFile(string container, IFormFile file, string path);
    }
}