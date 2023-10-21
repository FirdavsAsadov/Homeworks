using AutoMapper;
using FileExplorer.Api.FIleStorage.Dtos;
using FileExplorer.Application.FIleStorage.Models.Storage;

namespace FileExplorer.Api.Common.MapperProfile
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<StorageFile, StorageFileDto>();
            CreateMap<StorageFileDto, StorageFile>();
        }
    }
}
