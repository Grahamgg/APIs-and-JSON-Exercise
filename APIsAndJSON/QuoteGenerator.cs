using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class QuoteGenerator
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<string[]> GetKanyeQuotes(int count)
    {
        var kanyeURL = "https://api.kanye.rest";
        var kanyeQuotes = new string[count];

        for (int i = 0; i < count; i++)
        {
            var kanyeResponse = await client.GetStringAsync(kanyeURL);
            var kanyeData = JsonConvert.DeserializeObject<KanyeResponse>(kanyeResponse);
            kanyeQuotes[i] = kanyeData.Quote;
        }

        return kanyeQuotes;
    }

    public static async Task<string[]> GetRonQuotes(int count)
    {
        var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        var ronQuotes = new string[count];

        for (int i = 0; i < count; i++)
        {
            var ronResponse = await client.GetStringAsync(ronURL);
            ronQuotes[i] = JsonConvert.DeserializeObject<string[]>(ronResponse)[0];
        }

        return ronQuotes;
    }
}

public class KanyeResponse
{
    public string Quote { get; set; }
}


