using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        public static void Convo()
        {
            var client = new HttpClient();

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Ron says:\n{GetRonQuote(client)}\n");
                Thread.Sleep(2000);
                Console.WriteLine($"Kanye says:\n{GetKanyeQuote(client)}\n");
                Thread.Sleep(2000);
            }

            Console.ResetColor();
        }
        private static string GetKanyeQuote(HttpClient client)
        {
            var jtext = client.GetStringAsync("https://api.kanye.rest/").Result;

            var quote = JObject.Parse(jtext).GetValue("quote").ToString();

            return quote;
        }

        private static string GetRonQuote(HttpClient client)
        {
            var jtext = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

            var quote = JArray.Parse(jtext).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

            return quote;
        }

        
    }


    
}
