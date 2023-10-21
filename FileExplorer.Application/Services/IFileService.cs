using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FIleStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.Services
{
    public interface IFileService
    {
        ValueTask<IList<StorageFile>> GetFiles(string directoryPath, FilterPagination paginationOptions);
    }
}
