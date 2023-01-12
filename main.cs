using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.IO;

class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(
            "https://api.openweathermap.org/data/2.5/weather?lat=45.4211435&lon=-75.6900574&appid=fe1d80e1e103cff8c6afd190cad23fa5"
        );
        // Console.WriteLine(response);
        var jsonAsDictionary = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        // Console.WriteLine(jsonAsDictionary);
        Console.WriteLine("");
        JsonNode forecastNode = JsonNode.Parse(response)!;
        // Console.WriteLine(forecastNode);
        JsonNode mainNode = forecastNode!["main"]!;
        // Console.WriteLine(windNode);
        JsonNode tempNode = mainNode!["temp"]!;
        string temp = tempNode.ToString();
        double finalTemp = Convert.ToDouble(temp) - 273.6;
        Console.WriteLine("Temperature: " + finalTemp.ToString("0.0") + "° C");
        string text = "Total: " + finalTemp.ToString("0.0");
        await File.WriteAllTextAsync("WriteText.txt", text);
            Console.WriteLine("File Updated...");
            Console.WriteLine("");

            var someText = await File.ReadAllTextAsync(@"WriteText.txt");
        Console.WriteLine("\nDone.");
    }
}