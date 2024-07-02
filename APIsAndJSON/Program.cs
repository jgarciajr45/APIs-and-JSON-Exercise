using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {

            string ronSwansonUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            string kanyeWestUrl = "https://api.kanye.rest";
            int numberOfQuotes = 5;

            HttpClient client = new HttpClient();

            for (int i = 0; i < numberOfQuotes; i++)
            {
                // Get Ron Swanson quote
                var ronSwansonResponse = client.GetStringAsync(ronSwansonUrl).Result;
                JArray ronSwansonQuoteArray = JArray.Parse(ronSwansonResponse);
                string ronSwansonQuote = ronSwansonQuoteArray[0].ToString();

                // Get Kanye West quote
                var kanyeWestResponse = client.GetStringAsync(kanyeWestUrl).Result;
                JObject kanyeWestQuoteObject = JObject.Parse(kanyeWestResponse);
                string kanyeWestQuote = kanyeWestQuoteObject["quote"].ToString();

                // Print the quotes
                Console.WriteLine($"Ron Swanson: {ronSwansonQuote}");
                Console.WriteLine($"Kanye West: {kanyeWestQuote}");
                Console.WriteLine();

            }


        }
    }
}
