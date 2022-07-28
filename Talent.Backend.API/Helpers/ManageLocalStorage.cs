using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Talent.Backend.API.Helpers
{
    public class ManageLocalStorage: IManageAzureStorage
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ManageLocalStorage(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        

        public Task DeleteFile(string path, string container)
        {
            if (string.IsNullOrEmpty(path))
            {
                return Task.CompletedTask;  
            }

            var fileName = Path.GetFileName(path);  
            var diectoryFile = Path.Combine(_env.WebRootPath, container, fileName);
            
            if (File.Exists(diectoryFile))
            {
                File.Delete(diectoryFile);  
            }

            return Task.CompletedTask;  
        }

        public async Task<string> SaveFile(string container, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, container);

            if (!File.Exists(folder))
            {
                Directory.CreateDirectory(folder);  
            }  
            
            string path = Path.Combine(folder, fileName);
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var content = stream.ToArray();
                await File.WriteAllBytesAsync(path, content);
            }

            var currentUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var pathFromDb = Path.Combine(currentUrl, container, fileName).Replace("\\", "/");
            return pathFromDb;
        }

        public async Task<string> UpdateFile(string container, IFormFile file, string path)
        {
            await DeleteFile(path, container);
            return await SaveFile(container, file);
        }
    }
}
