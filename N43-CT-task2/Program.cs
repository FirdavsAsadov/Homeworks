using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N43_CT_task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = @"E:\Files\interweiv.txt";
            var mutex = new Mutex(false, "OpenFileMutex");
            Task.Run(async () =>
            {
                mutex.WaitOne();
                var guid = Guid.NewGuid();
                var fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
                Console.WriteLine("Reading...");
                var emailmessageapp = "Hello bro {{UserName}}";
                var buffer = Encoding.UTF8.GetBytes(emailmessageapp);
                await fileStream.ReadAsync(buffer, 0, buffer.Length);
                await fileStream.WriteAsync(buffer, 0, buffer.Length);
                Thread.Sleep(10000);
                fileStream.Close();
                Console.WriteLine($"App {guid} closed successfully");
                var template = "";
                var message = template.Replace("{{UserName}}", "G'ayrat");
                Console.WriteLine(message);
                mutex.ReleaseMutex();
            }).Wait();
        }
    }
}