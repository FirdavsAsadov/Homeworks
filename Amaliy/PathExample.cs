using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaliy
{
    public static class PathExample
    {
        public static void Execute()
        {
            var absoluteFilePath = @"C:\Users\user\source\repos\Homeworks\Amaliy\bin\Debug\net7.0\Data\user.json.txt";
            var relativeFilePath = @"Data\user.json.txt";
            var combine = Path.Combine(absoluteFilePath, relativeFilePath);
            var Join = Path.Join(absoluteFilePath, relativeFilePath);
        }
    }
}
