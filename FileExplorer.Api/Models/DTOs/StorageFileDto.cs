using FileExplorer.Application.FIleStorage.Models.Storage;
using Training.FileExplorer.Api.Models.Dtos;

namespace FileExplorer.Api.FIleStorage.Dtos;

public class StorageFileDto
{
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string DirectoryPath { get; set; } = string.Empty;

    public long Size { get; set; }

    public string Extension { get; set; } = string.Empty;

    public StorageItemType ItemType { get; set; }
}