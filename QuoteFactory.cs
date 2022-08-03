using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    public class QuoteGenerator
    {
        private HttpClient _client;

        public QuoteGenerator(HttpClient client)
        {
            _client = client;
        }

        public string Kanye()
        {
            
            var kanyeURL = "https://api.kanye.rest";

            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;

           
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            return kanyeQuote;
        }

        public string RonSwanson()
        {
           
            var ronswansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronswansonResponse = _client.GetStringAsync(ronswansonURL).Result;
            var ronswansonQuote = JArray.Parse(ronswansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim(); ;

            return ronswansonQuote.ToString();
        }
    }
}
