using AutoMapper;
using FileExplorer.Application.FIleStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleExplorer.Infrastructure.Common.MapperProfiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileInfo, StorageFile>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.DirectoryPath, opt => opt.MapFrom(src => src.DirectoryName))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.Extension, opt => opt.MapFrom(src => src.Extension));
        }
    }
}
