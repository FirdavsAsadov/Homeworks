using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N55_HT_Task1
{
    public class DirectoryandFileService
    {
        public int GetAllFolders(string folderName)  => Directory.GetDirectories(folderName).Length;
        public int GetAllFiles(string fileName) => Directory.GetFiles(fileName).Length;
        public decimal GetTotalSizeFiles(string fileName) => Directory.GetFiles(fileName).Sum(path => new FileInfo(path).Length);
        public string GetBigFileName(string fileName) => Directory.GetFiles(fileName).MaxBy(x => new FileInfo(x).Length);
    }
}
