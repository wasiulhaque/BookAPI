using BookAPI.Exceptions;
using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Validators
{
    public class BookValidator
    {
        public static void Validate(Book book, int ID)
        {
            if (book == null)
            {
                throw new BookNotFoundException($"Book with {ID} you are looking for doesn't exist.");
            }
        }
    }
}
