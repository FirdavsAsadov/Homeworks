using Microsoft.AspNetCore.Mvc;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverControllers : ControllerBase
    {
        private readonly IDriveService _driveService;

        public DriverControllers(IDriveService driveService)
        {
            _driveService = driveService;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAsync()
        {
            _driveService.GetAsync();

        }
    }
}
