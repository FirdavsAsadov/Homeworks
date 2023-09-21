using N39_HT_Task1;

public class Program
{
    static void Main(string[] args)
    {
        List<WeatherReport> _weatherReports = new List<WeatherReport>
        {
            new WeatherReport { State = "California", Degree = 30.1 },
            new WeatherReport { State = "New York", Degree = 29.9 },
            new WeatherReport { State = "Florida", Degree = 30.0 },
            new WeatherReport { State = "Texas", Degree = 29.8 },
            new WeatherReport { State = "Pennsylvania", Degree = 24.9 },
            new WeatherReport { State = "Illinois", Degree = 60.0 },
            new WeatherReport { State = "Ohio", Degree = 49.9 },
            new WeatherReport { State = "Indiana", Degree = 50.0 },
            new WeatherReport { State = "Michigan", Degree = 79.9 },
        };
        List<User> _users = new List<User>
        {
            new User { FirstName = "John", LastName = "Doe" },
            new User { FirstName = "Jane", LastName = "Doe" },
            new User { FirstName = "Jane", LastName = "Doe" },
            new User { FirstName = "john", LastName = "oe" },
            new User { FirstName = "Jane", LastName = "Doe" },
            new User { FirstName = "Jane", LastName = "Doe" },
        };
        var degrethirty = from weather in _weatherReports
            where weather.Degree >= 30
            select weather;
        Console.WriteLine("30 gradusdan yuqori bo'lgan shahrlar");
        foreach (var item in degrethirty)
        {
            Console.WriteLine(item.State);
        }

        var usernameJohn = from item in _users
            where item.FirstName == "John"
            select item;
        Console.WriteLine("Ismi John bo'lganlar");
        foreach (var item in usernameJohn)
        {
            Console.WriteLine($"{item.FirstName} - {item.LastName}");
        }
    }
}