using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore5Api.Models;
using NetCore5Api.Repositories;

namespace NetCore5Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public ProductsController(IBookRepository repo)
        {
            _bookRepo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBooksAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            try
            {
                var book = await _bookRepo.GetBookAsync(id);

                return book == null ? NotFound() : Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBook([FromRoute] string id, [FromBody] BookModel model)
        {
            try
            {
                var book = await _bookRepo.GetBookAsync(id);
                if (Guid.Parse(id) == book.Id)
                {
                    await _bookRepo.UpdateBookAsync(id, model);
                    return Ok();
                }
                else
                {
                    return BadRequest("NotFound");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            try
            {
                var book = await _bookRepo.GetBookAsync(id);
                if (Guid.Parse(id) == book.Id)
                {
                    await _bookRepo.DeleteBookAsync(id);
                    return Ok();
                }
                else
                {
                    return BadRequest("NotFound");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllBook(string id)
        {
            try
            {
                await _bookRepo.DeleteAllBookAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var newBookId = await _bookRepo.AddBookAsync(model);
                var book = await _bookRepo.GetBookAsync(newBookId);

                return book == null ? NotFound() : Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
