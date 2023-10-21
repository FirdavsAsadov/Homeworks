using AutoMapper;
using FileExplorer.Application.FIleStorage.Models.Storage;
using Training.Training.Api.Models.Models.Dtos;

namespace FileExplorer.Api.Common.MapperProfile
{
    public class DirectoryProfile : Profile
    {
        public DirectoryProfile()
        {
            CreateMap<StorageDirectory, StorageDirectoryDto>();
            CreateMap<StorageDirectoryDto, StorageDirectory>();
        }
    }
}
