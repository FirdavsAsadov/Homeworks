using AutoMapper;
using FileExplorer.Application.FIleStorage.Models.Storage;
using Training.FileExplorer.Api.Models.Dtos;

namespace FileExplorer.Api.Common.MapperProfile
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<StorageDrive, StorageDriveDto>();
            CreateMap<StorageDriveDto, StorageDrive>();
        }
    }
}
