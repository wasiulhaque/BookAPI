using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Exceptions
{
    public class IDZeroException : Exception
    {
        public IDZeroException()
        {

        }
        public IDZeroException(string message)
            :base(message)
        {
            
        }
    }
}
