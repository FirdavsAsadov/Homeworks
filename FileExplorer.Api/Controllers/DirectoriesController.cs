using AutoMapper;
using FileExplorer.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Services;
using Training.Training.Api.Models.Models.Dtos;

namespace FileExplorer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectoriesController : ControllerBase
    {
        private readonly IDirectoryService _directoryService;
        private readonly IDirectoryProcessingService _directoryProcessingService;
        private readonly IMapper _mapper;

        public DirectoriesController(IDirectoryService directoryService, 
            IDirectoryProcessingService directoryProcessingService, IMapper mapper)
        {
            _directoryService = directoryService;
            _directoryProcessingService = directoryProcessingService;
            _mapper = mapper;
        }

        [HttpGet("root/entries")]
        public async ValueTask<IActionResult> GetRootEntriesAsync([FromQuery] StorageDriveEntryFilterModel filterModel, IWebHostEnvironment environment)
        {
            var result = await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath, filterModel);
            return result.Any() ? Ok(result) : BadRequest();
        }

        [HttpGet("{directoryPath}")]
        public async ValueTask<IActionResult> GetByDirectoryPath([FromRoute] string directoryPath)
        {
            var result = await _directoryService.GetByPathAsync(directoryPath);
            var result2 = result != null ? _mapper.Map<StorageDirectoryDto>(result) : null;
            return result2 != null ? Ok(result2) : NotFound();
           
        }
    }
}
