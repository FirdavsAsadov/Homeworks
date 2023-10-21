using FileExplorer.Application.FIleStorage.Models.Storage;
using Training.FileExplorer.Api.Models.Dtos;

namespace FileExplorer.Api.Models.Dtos;

public interface IStorageItemDto
{
    string Path { get; set; }

    StorageItemType ItemType { get; set; }
}