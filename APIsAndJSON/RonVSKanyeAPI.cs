using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class RonVsKanyeApi
    {
        private string RonSwansonUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        private string KanyeWestUrl = "https://api.kanye.rest";

        public void GenerateQuotes(int numberOfQuotes)
        {
            HttpClient client = new HttpClient();
            {
                for (int i = 0; i < numberOfQuotes; i++)
                {
                    string ronSwansonResponse = client.GetStringAsync(RonSwansonUrl).Result;
                    JArray ronSwansonQuoteArray = JArray.Parse(ronSwansonResponse);
                    string ronSwansonQuote = ronSwansonQuoteArray[0].ToString();

                    var kanyeWestResponse = client.GetStringAsync(KanyeWestUrl).Result;
                    JObject kanyeWestQuoteObject = JObject.Parse(kanyeWestResponse);
                    string kanyeWestQuote = kanyeWestQuoteObject["quote"].ToString();

                    Console.WriteLine($"Ron Swanson: {ronSwansonQuote}");
                    Console.WriteLine($"Kanye West: {kanyeWestQuote}");
                    Console.WriteLine();
                }
            }       
        }
    }
}
