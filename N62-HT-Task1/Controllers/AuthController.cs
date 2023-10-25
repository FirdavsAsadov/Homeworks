using Microsoft.AspNetCore.Mvc;
using N62_HT_Task1.Interfeys;

namespace N62_HT_Task1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async ValueTask<IActionResult> Login(User user)
        {
           var result = _userService.Login(user);
            return Ok(result);
        }
    }
}
