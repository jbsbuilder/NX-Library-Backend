using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NX_Library_Backend.Interfaces;
using DTOs;
using Models;

namespace NXLibraryBackend.BookController
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookController _bookService;

        public BooksController(IBookController bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _bookService.GetBooks();
                return Ok(books);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetBook/{bookId}")]
        public async Task<IActionResult> GetBook(int bookId)
        {
            try
            {
                var book = await _bookService.GetBook(bookId);
                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(AddBookDTO addBookDto)
        {
            try
            {
                var book = new Book
                {
                    Title = addBookDto?.Title,
                    AuthorId = addBookDto?.AuthorId,
                    Genre = addBookDto?.Genre,
                    DefaultPrice = addBookDto.DefaultPrice
                };
                if (book != null)
                {
                    await _bookService.AddBook(addBookDto);
                    return Ok();
                }
                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateBook/{bookId}")]
        public async Task<ActionResult> UpdateBook(int bookId, UpdateBookDTO updatebookDto)
        {
            try 
            {
                var rslt = await _bookService.UpdateBook(bookId, updatebookDto);
                if (rslt is NotFoundResult)
                {
                    return NotFound();
                }
                return Ok(rslt);  
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteBook/{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            try
            {
                var rslt = await _bookService.DeleteBook(bookId);
                return Ok(rslt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}