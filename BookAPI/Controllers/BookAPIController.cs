using BookAPI.Data;
using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAllBooks")]
        public async Task<ActionResult<Book>> GetAllBooks()
        {
            var books = await _context.Books.Include("Reviews").ToListAsync(); ;

            if (books==null)
            {
                return NotFound("No Books Found!");
            }

            return Ok(books);
        }
    }
}
