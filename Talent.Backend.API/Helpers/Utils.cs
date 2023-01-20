using Microsoft.AspNetCore.StaticFiles;

namespace Talent.Backend.API.Helpers
{
    public static class Utils
    {
        public static string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType = string.Empty;
            if (provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}
