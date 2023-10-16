using Microsoft.AspNetCore.Mvc;
using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;

namespace N53_Ht_Task1.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BonusController : ControllerBase
    {
        private readonly IBonusService _bonusService;

        public BonusController(IBonusService bonusService)
        {
            _bonusService = bonusService;
        }

        [HttpGet]
        public IActionResult GetBonus()
        {
            var result = _bonusService.Get(bonus => true);
            return result.Any() ? Ok(result) : BadRequest();
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateBonus(Bonus bonus)
        {
            var result = _bonusService.CreateAsync(bonus);
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> Update(Bonus bonus)
        {
            var result = _bonusService.UpdateAsync(bonus);
            return Ok(result);
        }
    }
}
