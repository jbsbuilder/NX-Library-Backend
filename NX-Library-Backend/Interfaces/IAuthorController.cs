using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace NX_Library_Backend.Interfaces

{
    public interface IAuthorController
    {
        Task<List<Author>> GetAuthors();
        Task<Author?> GetAuthor(int authorId);
        Task<ActionResult> AddAuthor(AddAuthorDTO addAuthorDTO);
        Task<ActionResult> UpdateAuthor(int authorId, UpdateAuthorDTO updateAuthorDto);
        Task<ActionResult> DeleteAuthor(int authorId);
    }
}
