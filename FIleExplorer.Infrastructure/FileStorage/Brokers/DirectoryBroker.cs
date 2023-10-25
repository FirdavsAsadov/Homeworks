using AutoMapper;
using FileExplorer.Application.FIleStorage.Brokers;
using FileExplorer.Application.FIleStorage.Models.Storage;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;

namespace FIleExplorer.Infrastructure.FileStorage.Brokers
{
    public class DirectoryBroker : IDirectoryBroker
    {
        private readonly IMapper _mapper;
        public DirectoryBroker(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool ExistsAsync(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public StorageDirectory GetByPathAsync(string directoryPath)
        {
            return _mapper.Map<StorageDirectory>(new DirectoryInfo(directoryPath));
        }

        public IEnumerable<string> GetDirectoriesPath(string directoryPath)
        {
            return Directory.EnumerateDirectories(directoryPath);
        }

        public IEnumerable<string> GetFilesPath(string directoryPath)
        {
            return Directory.EnumerateFiles(directoryPath);
        }

        public bool SetAccessControl(string directoryPath)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return false;

            var directoryInfo = new DirectoryInfo(directoryPath);
            var directorySecurity = directoryInfo.GetAccessControl();

            var currentUser = Environment.UserDomainName + "\\" + Environment.UserName;
            var rule = new FileSystemAccessRule(
                new NTAccount(currentUser),
                FileSystemRights.ReadData,
                AccessControlType.Allow);

            directorySecurity.AddAccessRule(rule);

            directoryInfo.SetAccessControl(directorySecurity);

            return true;
        }
    }
}
