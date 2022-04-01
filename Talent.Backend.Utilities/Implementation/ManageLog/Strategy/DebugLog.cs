using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Utilities.Implementation.ManageLog.Contracts;

namespace Talent.Backend.Utilities.Implementation.ManageLog.Strategy
{
    public class DebugLog : ILoggin
    {
        public string Writte(string mensaje)
        {
            throw new NotImplementedException();
        }
    }
}
