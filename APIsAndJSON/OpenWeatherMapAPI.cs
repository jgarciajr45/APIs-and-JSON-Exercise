using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class OpenWeatherMapApi
    {
        private readonly string _apiKey;

        public OpenWeatherMapApi(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void GetWeather(string city)
        {
            string units = "imperial";
            string weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={_apiKey}";

            HttpClient client = new HttpClient();


            string response = client.GetStringAsync(weatherUrl).Result;
            JObject weatherData = JObject.Parse(response);

            string weatherDescription = weatherData["weather"][0]["description"].ToString();
            string temperature = weatherData["main"]["temp"].ToString();
            string feelsLike = weatherData["main"]["feels_like"].ToString();
            string humidity = weatherData["main"]["humidity"].ToString();
            string windSpeed = weatherData["wind"]["speed"].ToString();

            Console.WriteLine("====================================");
            Console.WriteLine($"Weather Forecast for {city}");
            Console.WriteLine("====================================");
            Console.WriteLine($"Description: {weatherDescription}");
            Console.WriteLine($"Temperature: {temperature} °F");
            Console.WriteLine($"Feels Like: {feelsLike} °F");
            Console.WriteLine($"Humidity: {humidity}%");
            Console.WriteLine($"Wind Speed: {windSpeed} mph");
            Console.WriteLine("====================================");


        }
    }
}
