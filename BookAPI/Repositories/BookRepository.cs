using BookAPI.Models;
using BookAPI.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            _context.BooksList.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int ID)
        {
            var bookToDelete = await _context.BooksList.FindAsync(ID);
            _context.BooksList.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.BooksList.ToListAsync();
        }

        public async Task<Book> Get(int ID)
        {
            IDValidator.Validate(ID);
            return await _context.BooksList.FindAsync(ID);
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
