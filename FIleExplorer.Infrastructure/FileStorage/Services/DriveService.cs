using FileExplorer.Application.FIleStorage.Brokers;
using FileExplorer.Application.FIleStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FIleExplorer.Infrastructure.FileStorage.Services
{
    public class DriveService : IDriveService
    {
        private readonly IDriveBroker  _driveBroker;
        public DriveService(IDriveBroker driveBroker)
        {
            _driveBroker = driveBroker;
        }
        public ValueTask<IList<StorageDrive>> GetAsync()
        {
           var listdrives =  _driveBroker.Get().ToList();
            return new ValueTask<IList<StorageDrive>>(listdrives);
        }
    }
}
