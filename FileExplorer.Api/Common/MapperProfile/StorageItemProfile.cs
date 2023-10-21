using AutoMapper;
using FileExplorer.Api.Models.Dtos;
using FileExplorer.Application.FIleStorage.Models.Storage;

namespace FileExplorer.Api.Common.MapperProfile
{
    public class StorageItemProfile : Profile
    {
        public StorageItemProfile()
        {
            CreateMap<IStorageEntry, IStorageItemDto>();
            CreateMap<IStorageItemDto, IStorageEntry>();
        }
    }
}
