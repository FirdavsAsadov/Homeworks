using Microsoft.AspNetCore.Mvc;
using N66_HT_Task1.Interfeys;
using N66_HT_Task1.Models;

namespace N66_HT_Task1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookControllers : ControllerBase
    {
        private readonly IBookService  _bookService;

        public BookControllers(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult CreateAsync(Book book)
        {
            var result = _bookService.CreateAsync(book);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _bookService.GetAsync(id);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update(Book book)
        {
            var result = _bookService.UpdateAsync(book);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _bookService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
