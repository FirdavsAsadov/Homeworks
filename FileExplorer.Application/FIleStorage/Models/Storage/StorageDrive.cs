using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FIleStorage.Models.Storage
{
    public class StorageDrive : IStorageEntry
    {
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Format {  get; set; } = string.Empty;
        public string Type {  get; set; } = string.Empty;
        public long TotalSpace {  get; set; }
        public long FreeSpace { get; set; }
        public long UnavailableSpace { get; set; }
        public long UsedSpace { get; set; }
        public StorageItemType ItemType { get; set; }
    }
}
