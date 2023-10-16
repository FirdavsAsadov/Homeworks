using Microsoft.AspNetCore.Mvc;
using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;

namespace N53_Ht_Task1.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService  _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _userService.Get(user => true);
            return result.Any() ? Ok(result) : BadRequest();
        }
        [HttpPost]
        public async ValueTask<IActionResult> CretUses(User user)
        {
            var result = _userService.CreateAsync(user);
            return Ok(result);
        }
        
    }
}
