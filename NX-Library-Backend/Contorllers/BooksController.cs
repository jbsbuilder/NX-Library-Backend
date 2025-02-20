using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NX_Library_Backend.Data;
using Models;
using NXLibraryBackend.Data;
using DTOs;

namespace NXLibraryBackend.BookController
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class BookContorller(NXLibDbContext _ctx) : Controller
    {
        [HttpGet("GetBooks")]
        public async Task<List<Book>> GetBooks()
        {

            var books = await _ctx.Books
                .Include(author => author.BookAuthor)
                .ToListAsync();

            return books;

        }

        [HttpGet("GetBook/{bookId}")]
        public async Task<Book?> GetBook(int bookId)
        {
            var rslt = from c in _ctx.Books
                       where c.Id == bookId
                       select c;
            return await rslt.FirstOrDefaultAsync();
        }

        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBook(AddBookDTO book)
        {
     
            _ctx.Books.Add(
                new Book
                {
                    BookTitle = book.BookTitle,
                    AuthorId = book.AuthorId,
                    Genere = book.Genere,
                    Copies = book.Copies
                }
                );
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("/UpdateBook")]
        public async Task<ActionResult> UpdateBook(UpdateBookDTO bookDto)
        {
            var book = await _ctx.Books.FindAsync(bookDto.Id);
            if (book == null)
            {
                return NotFound();
            }

            book.BookTitle = bookDto.BookTitle;
            book.AuthorId = bookDto.AuthorId;
            book.Genere = bookDto.Genere;
            book.Copies = bookDto.Copies;

            _ctx.Books.Update(book);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("/DeleteBook/{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            var rslt = from c in _ctx.Books
                       where c.Id == bookId
                       select c;
            Book? book = await rslt.FirstOrDefaultAsync();
            if (book != null)
            {
                _ctx.Books.Remove(book);
                await _ctx.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
