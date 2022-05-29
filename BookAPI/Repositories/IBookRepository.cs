﻿using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int ID);
        Task<Book> Create(Book book);
        Task Update(Book book);
        Task Delete(int ID);
    }
}
