using Microsoft.AspNetCore.Mvc;
using Models;
using NXLibraryBackend.Data;
using Microsoft.EntityFrameworkCore;


namespace NX_Library_Backend.AuthorsController
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController(NXLibDbContext _ctx) : Controller
    {
        [HttpGet("GetAuthors")]

        public async Task<List<Author>> GetAuthors()
        {
            var rslt = from a in _ctx.BookAuthor
                       select a;
            return await rslt.ToListAsync();
        }

        [HttpPost("AddAuthor")]
        public async Task<ActionResult> AddAuthor(Author author)
        {
            _ctx.BookAuthor.Add(author);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
