using FileExplorer.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;

namespace FileExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private IFileService  _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("filesGet")]

        public async ValueTask<IActionResult> GeetFiles([FromQuery] StorageDriveEntryFilterModel filterModel, IWebHostEnvironment webHostEnvironment)
        {
            var result = await _fileService.GetFiles(webHostEnvironment.WebRootPath, filterModel);
            return result.Any() ? 
                Ok(result) 
                : BadRequest();
        }
    }
}
