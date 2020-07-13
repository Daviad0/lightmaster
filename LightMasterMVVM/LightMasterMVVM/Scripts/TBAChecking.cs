using LightMasterMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Net;
using System.Net.Http;
using System.Text;

namespace LightMasterMVVM.Scripts
{
    public class TBAChecking
    {
        public string CompetitionKey = "2020mijac";
        public string APILink = "https://thebluealliance.com/api/v3/event/";
        public void CheckCurrentMatchesToDB()
        {
            Console.WriteLine("Making API Call...");
            string result = "";
            var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            client.BaseAddress = new Uri(APILink);
            HttpResponseMessage response = client.GetAsync("2020mijac/matches").Result;
            List<TBA_Match> listOfMatches = JsonConvert.DeserializeObject<List<TBA_Match>>(result);
            foreach (var item in listOfMatches)
            {
                Console.WriteLine("TEST:::");
            }
            
            
        }
    }
}
