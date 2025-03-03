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
    public class AuthorService : IAuthorsController
    {
        private readonly NXLibDbContext _context;
        public AuthorService(NXLibDbContext context)
        {
            _context = context;
        }
        public async Task<List<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }
        public async Task<ActionResult> GetAuthor(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author != null)
            {
                return new OkObjectResult(author);
            }
            return new NotFoundResult();
        }
        public async Task<ActionResult> AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
        public async Task<ActionResult> UpdateAuthor(int authorId, UpdateAuthorDTO authorDto)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author != null)
            {
                author.Name = authorDto.Name;
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
        public async Task<ActionResult> DeleteAuthor(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
    }
}