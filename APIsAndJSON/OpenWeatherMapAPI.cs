using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void GetTemp()
        {
            var apiKeyObj = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();

            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={41.0128}&lon={-74.2453}" +
                $"&appid={apiKey}&units=imperial";

            var client = new HttpClient();

            var jtext = client.GetStringAsync(url).Result;

            var weatherObj = JObject.Parse(jtext);

            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}f");
            Console.WriteLine($"Feels Like: {weatherObj["main"]["feels_like"]}f");
            Console.WriteLine($"Todays Low: {weatherObj["main"]["temp_min"]}f");
            Console.WriteLine($"Todays High: {weatherObj["main"]["temp_max"]}f");
        }
    }
}
