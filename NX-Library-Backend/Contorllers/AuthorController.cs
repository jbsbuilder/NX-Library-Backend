using DTOs;
using Microsoft.AspNetCore.Mvc;
using Models;
using NX_Library_Backend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorServices _authorService;

        public AuthorController(IAuthorServices authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                var authors = await _authorService.GetAuthors();
                return Ok(authors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAuthor/{authorId}")]
        public async Task<IActionResult> GetAuthor(int authorId)
        {
            try
            {
                var author = await _authorService.GetAuthor(authorId);
                return Ok(author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor(AddAuthorDTO addAuthorDTO)
        {
            try
            {
                var author = new Author { Name = addAuthorDTO.Name };
                    await _authorService.AddAuthor(addAuthorDTO);
                    return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateAuthor/{authorId}")]
        public async Task<IActionResult> UpdateAuthor(int authorId, UpdateAuthorDTO updateAuthorDTO)
        {
            try
            {
                var rslt = await _authorService.UpdateAuthor(authorId, updateAuthorDTO);
                return Ok(rslt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteAuthor/{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            try
            {
                var result = await _authorService.DeleteAuthor(authorId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}