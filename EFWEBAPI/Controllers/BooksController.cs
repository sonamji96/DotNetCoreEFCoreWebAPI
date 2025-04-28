using EFWEBAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFWEBAPI.Controllers
{

    [Route("api/Books")]
    [ApiController]
    public class BooksController(AppDbContext _appDbContext) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> insertBook([FromBody] Book book)
        {
            _appDbContext.Books.Add(book);
            await _appDbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPost("BulkInsertion")]
        public async Task<IActionResult> insertBooks([FromBody] List<Book> book)
        {
            _appDbContext.Books.AddRange(book);
            await _appDbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllBook()
        {
            var result = await _appDbContext.Books.ToListAsync();
            return Ok(result);

         }

    }
}
