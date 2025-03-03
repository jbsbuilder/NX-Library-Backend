﻿using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace NX_Library_Backend.Interfaces

{
    public interface IAuthorsController
    {
        Task<List<Author>> GetAuthors();
        Task<ActionResult> AddAuthor(Author author);
        Task<ActionResult> UpdateAuthor(int authorId, UpdateAuthorDTO authorDto);
        Task<ActionResult> DeleteAuthor(int authorId);
    }
}
