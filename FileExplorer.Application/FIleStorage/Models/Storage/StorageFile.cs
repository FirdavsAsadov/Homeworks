using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FIleStorage.Models.Storage
{
    public class StorageFile : IStorageEntry
    {
        public string Name { get; set; } = string.Empty;
        public string DirectoryPath { get; set; } = string.Empty;
        public long Size { get; set; }
        public string Extensions { get; set; } = string.Empty;
        public string Path { get; set; }
        public StorageItemType ItemType { get; set; }
        public object Extension { get; set; }
    }
}
