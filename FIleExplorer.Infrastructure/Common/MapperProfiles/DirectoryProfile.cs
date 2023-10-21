using AutoMapper;
using FileExplorer.Application.FIleStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleExplorer.Infrastructure.Common.MapperProfiles
{
    public class DirectoryProfile : Profile
    {
        public DirectoryProfile()
        {
            CreateMap<DirectoryInfo, StorageDirectory>()
                .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Path, opt => opt.MapFrom(dest => dest.FullName))
                .ForMember(src => src.ItemsCount, opt => opt.MapFrom(dest => dest.GetFileSystemInfos().Count()));
        }
    }
}
