using System;
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
