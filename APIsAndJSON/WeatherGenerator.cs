using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class WeatherGenerator
{
    private static readonly HttpClient client = new HttpClient();

   

    public static async Task<int> GetCurrentWeather()
    {
        Console.WriteLine("Please enter your API key:");
        var api_Key = Console.ReadLine();
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the city name: ");
            var city_name = Console.ReadLine();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_Key}";

            var response = await client.GetStringAsync(weatherURL);
            var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
            Console.WriteLine(formattedResponse);
            Console.WriteLine();

            Console.WriteLine("Would you like to choose a different city?");
            var userInput = Console.ReadLine();
            Console.WriteLine();
            if (userInput.ToLower() == "no")
            {
                break;
            }
        }

        return 0; // You can return any value here since it's not relevant for this method.
    }
}




