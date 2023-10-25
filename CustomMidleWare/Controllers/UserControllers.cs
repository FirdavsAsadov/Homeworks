using Microsoft.AspNetCore.Mvc;

namespace CustomMidleWare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserControllers : ControllerBase
    {
        private readonly UserService _userService;
        public UserControllers(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _userService.Create(user);
            return Ok();
        }
    }
}
