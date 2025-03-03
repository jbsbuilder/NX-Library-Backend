using DTOs;
using Models;
using NX_Library_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NXLibraryBackend.Data;

namespace NX_Library_Backend.Services
{
    public class BookServices : IBookController
    {
        private readonly NXLibDbContext _context;

        public BookServices(NXLibDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBook(int bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public async Task<ActionResult> AddBook(AddBookDTO addBookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
                Genre = bookDto.Genre,
                DefaultPrice = bookDto.DefaultPrice != 0 ? bookDto.DefaultPrice : 15.00
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<ActionResult> UpdateBook(int bookId, UpdateBookDTO bookDto)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Title = bookDto.Title;
                book.AuthorId = bookDto.AuthorId;
                book.Genre = bookDto.Genre;
                book.DefaultPrice = bookDto.DefaultPrice;

                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }

        public async Task<ActionResult> DeleteBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
    }
}