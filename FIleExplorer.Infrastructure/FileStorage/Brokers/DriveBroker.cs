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
    public class DriveBroker : IDriveBroker
    {
        private readonly IMapper _mapper;
        public DriveBroker(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IEnumerable<StorageDrive> Get()
        {
            return DriveInfo
                .GetDrives()
                .Select(x => _mapper.Map<StorageDrive>(x))
                .AsQueryable();
        }
    }
}
