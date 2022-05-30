using BookAPI.Exceptions;
using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Validators
{
    public class IDValidator
    {
        public static void Validate (int ID)
        {
            if(ID == 0)
            {
                throw new IDZeroException($"ID cannot be zero.");
            }
        }
    }
}
