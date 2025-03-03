using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace NX_Library_Backend.Interfaces
{
    public interface IBookController
    {
        Task<List<Book>> GetBooks();
        Task<Book?> GetBook(int bookId);
        Task<ActionResult> AddBook(AddBookDTO book);
        Task<ActionResult> UpdateBook(int bookId, UpdateBookDTO bookDto);
        Task<ActionResult> DeleteBook(int bookId);
    }
}
