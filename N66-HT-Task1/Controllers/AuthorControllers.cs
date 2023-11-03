using Microsoft.AspNetCore.Mvc;
using N66_HT_Task1.Interfeys;
using N66_HT_Task1.Models;

namespace N66_HT_Task1.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class AuthorControllers : ControllerBase
    {
       private readonly IAuthorService _authorService;

        public AuthorControllers(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            var result = _authorService.CreateAsync(author);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get(string name)
        {
            var result = _authorService.GetAsync(name);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(Author author)
        {
            var result = _authorService.UpdateAsync(author);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(string name)
        {
            var result = _authorService.DeleteAsync(name);
            return Ok(result);
        }
    }
}
