using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace NX_Library_Backend.Interfaces

{
    public interface IAuthorController
    {
        Task<List<Author>> GetAuthors();
        Task<ActionResult> GetAuthor(int authorId);
        Task<ActionResult> AddAuthor(Author author);
        Task<ActionResult> UpdateAuthor(int authorId, UpdateAuthorDTO authorDto);
        Task<ActionResult> DeleteAuthor(int authorId);
    }
}
