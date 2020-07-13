using DynamicData.Annotations;
using LightMasterMVVM.DbAssets;
using LightMasterMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace LightMasterMVVM.Scripts
{
    public class TBAChecking
    {
        public ScoutingContext db = new ScoutingContext();
        public string CompetitionKey = "2020mijac";
        public string APILink = "https://thebluealliance.com/api/v3/event/";
        public async void CheckCurrentMatchesToDB()
        {
            HttpClient client = new HttpClient();

            // Call asynchronous network methods in a try/catch block to handle exceptions
            List<TBA_Match> listOfOfficialMatches = new List<TBA_Match>();
            List<TeamMatch> listOfRed1Matches = new List<TeamMatch>();
            List<TeamMatch> listOfRed2Matches = new List<TeamMatch>();
            List<TeamMatch> listOfRed3Matches = new List<TeamMatch>();
            List<TeamMatch> listOfBlue1Matches = new List<TeamMatch>();
            List<TeamMatch> listOfBlue2Matches = new List<TeamMatch>();
            List<TeamMatch> listOfBlue3Matches = new List<TeamMatch>();
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://www.thebluealliance.com/api/v3/event/2020mijac/matches");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<TBA_Match> listOfFoundMatches = JsonConvert.DeserializeObject<List<TBA_Match>>(responseBody);
                //Check to make sure that the matches have been completed and are qualifiers (the default way to check should be using the BLUE alliance)
                listOfOfficialMatches = listOfFoundMatches.Where(x => x.comp_level == "qm" && x.alliances.blue.score > -1).ToList();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            listOfBlue1Matches = db.Matches.Where(x => x.TabletId == "B1" && x.ClientSubmitted == true).ToList();
            listOfBlue2Matches = db.Matches.Where(x => x.TabletId == "B2" && x.ClientSubmitted == true).ToList();
            listOfBlue3Matches = db.Matches.Where(x => x.TabletId == "B3" && x.ClientSubmitted == true).ToList();
            listOfRed1Matches = db.Matches.Where(x => x.TabletId == "R1" && x.ClientSubmitted == true).ToList();
            listOfRed2Matches = db.Matches.Where(x => x.TabletId == "R2" && x.ClientSubmitted == true).ToList();
            listOfRed3Matches = db.Matches.Where(x => x.TabletId == "R3" && x.ClientSubmitted == true).ToList();
            foreach(var completedMatch in listOfOfficialMatches)
            {
                TeamMatch r1completedMatch = listOfRed1Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.red.team_keys[0].Substring(3))).FirstOrDefault();
                TeamMatch r2completedMatch = listOfRed2Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.red.team_keys[1].Substring(3))).FirstOrDefault();
                TeamMatch r3completedMatch = listOfRed3Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.red.team_keys[2].Substring(3))).FirstOrDefault();
                TeamMatch b1completedMatch = listOfBlue1Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.blue.team_keys[0].Substring(3))).FirstOrDefault();
                TeamMatch b2completedMatch = listOfBlue2Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.blue.team_keys[1].Substring(3))).FirstOrDefault();
                TeamMatch b3completedMatch = listOfBlue3Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.blue.team_keys[2].Substring(3))).FirstOrDefault();
                if(r1completedMatch != null && r2completedMatch != null && r3completedMatch != null && b1completedMatch != null && b2completedMatch != null && b3completedMatch != null)
                {
                    //CHECKING CODE
                }
            }
            
        }
    }
}
