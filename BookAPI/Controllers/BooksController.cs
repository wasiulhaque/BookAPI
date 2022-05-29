using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Book>> GetBooks(int ID)
        {
            return await _bookRepository.Get(ID);
        }

        [HttpPost]
        public async Task<ActionResult<Book>>PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.ID }, newBook);
        }

        [HttpPut]
        public async Task<ActionResult>PutBooks(int ID, [FromBody] Book book)
        {
            if(ID != book.ID)
            {
                return BadRequest();
            }

            await _bookRepository.Update(book);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult>Delete(int ID)
        {
            var bookToDelete = await _bookRepository.Get(ID);
            if (bookToDelete == null)
                return NotFound();

            await _bookRepository.Delete(bookToDelete.ID);
            return NoContent();
        }
    }
}
