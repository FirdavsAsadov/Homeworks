using FileExplorer.Application.FIleStorage.Models.Storage;
using Training.FileExplorer.Api.Models.Dtos;

namespace Training.Training.Api.Models.Models.Dtos;

public class StorageDirectoryDto
{
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public long ItemsCount { get; set; }

    public StorageItemType ItemType { get; set; }
}