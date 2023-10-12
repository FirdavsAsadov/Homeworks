using Microsoft.AspNetCore.Mvc;
using N52_ht_Task_1.Models;
using N52_ht_Task_1.Services.Interfeys;

namespace N52_ht_Task_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersControlller : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersControlller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUser([FromBody] User user)
        {
            var result = await _userService.CreateAsync(user);

            return Ok(result);
        }
    }
}
