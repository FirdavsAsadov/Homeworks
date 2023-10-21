using N55_HT_Task1;

var example = new DirectoryandFileService();
Console.WriteLine($"{example.GetAllFiles(Directory.GetCurrentDirectory())} Hamma Fayllar soni");
Console.WriteLine($"{example.GetAllFolders(Directory.GetCurrentDirectory())} Hamma FolderLar soni");
Console.WriteLine($"{example.GetTotalSizeFiles(Directory.GetCurrentDirectory())} File Size");
Console.WriteLine($"{example.GetBigFileName(Directory.GetCurrentDirectory())} eng Katta file nomi");

