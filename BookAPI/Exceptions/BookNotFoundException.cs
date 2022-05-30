using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException()
        {

        }
        public BookNotFoundException(string message)
            :base(message)
        {

        }
    }
}
