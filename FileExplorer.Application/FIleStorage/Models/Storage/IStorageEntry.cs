using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FIleStorage.Models.Storage
{
    public interface IStorageEntry
    {
        string Path { get; set; }
        StorageItemType ItemType { get; set; }
    }
}
