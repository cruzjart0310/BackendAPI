using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Contracts
{
    public interface IFileUploaded
    {
        Task SaveDataFromFile(IFormFile file);
    }
}
