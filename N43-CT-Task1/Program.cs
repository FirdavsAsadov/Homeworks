using System.Text;

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
            Console.WriteLine($"App{guid} opened the file");
            var emailTemplate = "Hello {{UserName}} Welcome to our platform";
            var buffer = Encoding.UTF8.GetBytes(emailTemplate);
            await fileStream.WriteAsync(buffer, 0, buffer.Length);

            Thread.Sleep(10000);
            fileStream.Close();

            Console.WriteLine($"App {guid} closed the file");
            mutex.ReleaseMutex();
            var template = "";
            var message = template.Replace("{{UserName}}", "John");
            Console.WriteLine(message);
        }).Wait();

    }
}