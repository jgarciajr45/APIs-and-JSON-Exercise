using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            string openWeatherMapApiKey = "9e0f7bbf757bf28622d9998c5c41edf6";
            string city = "Redwood City"; 
            int numberOfQuotes = 5;

            OpenWeatherMapApi weatherApi = new OpenWeatherMapApi(openWeatherMapApiKey);
            RonVsKanyeApi quotesApi = new RonVsKanyeApi();

            Console.WriteLine("Fetching weather information...");
            weatherApi.GetWeather(city);

            Console.WriteLine("Generating quotes...");
            quotesApi.GenerateQuotes(numberOfQuotes);
        }
    }
}
