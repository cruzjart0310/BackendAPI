using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.DataAccessEF.Contracts;

namespace Talent.Backend.Bussiness.Contracts
{
    public interface IQuestionBussiness: IGenericBussines<Question>,IFileUploaded
    {

    }
}
