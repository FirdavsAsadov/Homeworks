using AutoMapper;
using FileExplorer.Application.FIleStorage.Brokers;
using FileExplorer.Application.FIleStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleExplorer.Infrastructure.FileStorage.Brokers
{
    public class FIleBroker : IFileBroker
    {
        private readonly IMapper _mapper;
        public FIleBroker(IMapper mapper)
        {
            _mapper = mapper;
        }
        public StorageFile GetByPath(string filePath)
        {
            return _mapper.Map<StorageFile>(new FileInfo(filePath));
        }
    }
}
