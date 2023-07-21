using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIsAndJSON
{
    public class Program
    {
        public static async Task Main()
        {
            var kanyeQuotes = await QuoteGenerator.GetKanyeQuotes(5);
            var ronQuotes = await QuoteGenerator.GetRonQuotes(5);

            Console.WriteLine("Kanye and Ron's Conversation:");
            Console.WriteLine("----------------------------");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye: '{kanyeQuotes[i]}'");
                Console.WriteLine($"Ron: '{ronQuotes[i]}'");
                Console.WriteLine("----------------------------");
            }

             await WeatherGenerator.GetCurrentWeather();
        }
    }
}
