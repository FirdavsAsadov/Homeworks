using Microsoft.AspNetCore.Mvc;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("verification/{token}")]
        public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
        {
            var result = await _accountService.VerificateAsync(token);
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] User user)
        {
            var result = await _accountService.CreateUserAsync(user);
            return Ok(result);
        }
        [HttpPut("verification/{password}")]
        public async ValueTask<IActionResult> Update([FromBody] User user)
        {
            var result = await _accountService.UpdateUserAsync(user);
            return Ok(result);
        }
    }
}
