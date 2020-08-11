using DynamicData.Annotations;
using LightMasterMVVM.DbAssets;
using LightMasterMVVM.Models;
using Newtonsoft.Json;
using SharpDX.WIC;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LightMasterMVVM.Scripts
{
    public class TBAChecking
    {
        public ScoutingContext db = new ScoutingContext();
        public string CompetitionKey = "2020mijac";
        public string APILink = "https://thebluealliance.com/api/v3/event/";
        public async Task CheckCurrentMatchesToDB(int minmatchtocheck, int maxmatchtocheck)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TBA-Auth-Key", "kzyt55ci5iHn3X1T8BgXYu2yMXmAjdxV5OCXHVA16CRfX8C0Z6tfrwU4BajyleY3");
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
                listOfOfficialMatches = listOfFoundMatches.Where(x => x.comp_level == "qm" && x.alliances.blue.score > -1 && x.match_number <= maxmatchtocheck && x.match_number >= minmatchtocheck).ToList();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            try
            {
                listOfBlue1Matches = db.Matches.Where(x => x.TabletId == "B1" && x.ClientSubmitted == true).ToList();
                listOfBlue2Matches = db.Matches.Where(x => x.TabletId == "B2" && x.ClientSubmitted == true).ToList();
                listOfBlue3Matches = db.Matches.Where(x => x.TabletId == "B3" && x.ClientSubmitted == true).ToList();
                listOfRed1Matches = db.Matches.Where(x => x.TabletId == "R1" && x.ClientSubmitted == true).ToList();
                listOfRed2Matches = db.Matches.Where(x => x.TabletId == "R2" && x.ClientSubmitted == true).ToList();
                listOfRed3Matches = db.Matches.Where(x => x.TabletId == "R3" && x.ClientSubmitted == true).ToList();
            }
            catch(Exception ex)
            {

            }
            
            foreach(var completedMatch in listOfOfficialMatches)
            {
                //TeamMatch r1completedMatch = listOfRed1Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.red.team_keys[0].Substring(3))).FirstOrDefault();
                //TeamMatch r2completedMatch = listOfRed2Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.red.team_keys[1].Substring(3))).FirstOrDefault();
                //TeamMatch r3completedMatch = listOfRed3Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.red.team_keys[2].Substring(3))).FirstOrDefault();
                //TeamMatch b1completedMatch = listOfBlue1Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.blue.team_keys[0].Substring(3))).FirstOrDefault();
                //TeamMatch b2completedMatch = listOfBlue2Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.blue.team_keys[1].Substring(3))).FirstOrDefault();
                //TeamMatch b3completedMatch = listOfBlue3Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == int.Parse(completedMatch.alliances.blue.team_keys[2].Substring(3))).FirstOrDefault();
                TeamMatch r1completedMatch = listOfRed1Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TrackedTeam.team_number == 862 && x.APIChecked == false).FirstOrDefault();
                TeamMatch r2completedMatch = listOfRed2Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TrackedTeam.team_number == 862 && x.APIChecked == false).FirstOrDefault();
                TeamMatch r3completedMatch = listOfRed3Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TrackedTeam.team_number == 862 && x.APIChecked == false).FirstOrDefault();
                TeamMatch b1completedMatch = listOfBlue1Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TrackedTeam.team_number == 862 && x.APIChecked == false).FirstOrDefault();
                TeamMatch b2completedMatch = listOfBlue2Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TrackedTeam.team_number == 862 && x.APIChecked == false).FirstOrDefault();
                TeamMatch b3completedMatch = listOfBlue3Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TrackedTeam.team_number == 862 && x.APIChecked == false).FirstOrDefault();
                if (r1completedMatch != null && r2completedMatch != null && r3completedMatch != null && b1completedMatch != null && b2completedMatch != null && b3completedMatch != null)
                {
                    //RED 1
                    int currentscore = 10;
                    if(completedMatch.score_breakdown.red.initLineRobot1 == "None")
                    {
                        if (!r1completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            r1completedMatch.A_InitiationLine = true;
                        }
                    }
                    else
                    {
                        if (r1completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            r1completedMatch.A_InitiationLine = false;
                        }
                    }
                    if (completedMatch.score_breakdown.red.endgameRobot1 == "None")
                    {
                        if (r1completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r1completedMatch.E_ClimbSuccess = false;
                        }
                        if (r1completedMatch.E_Park)
                        {
                            currentscore--;
                            r1completedMatch.E_Park = false;
                        }
                        if (r1completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r1completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.red.endgameRobot1 == "Park")
                    {
                        if (r1completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r1completedMatch.E_ClimbSuccess = false;
                        }
                        if (!r1completedMatch.E_Park)
                        {
                            currentscore--;
                            r1completedMatch.E_Park = true;
                        }
                        if (r1completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r1completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.red.endgameRobot1 == "Hang")
                    {
                        if (!r1completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r1completedMatch.E_ClimbSuccess = true;
                        }
                        if (r1completedMatch.E_Park)
                        {
                            currentscore--;
                            r1completedMatch.E_Park = false;
                        }
                    }
                    if (completedMatch.score_breakdown.red.endgameRungIsLevel == "IsLevel")
                    {
                        if(!r1completedMatch.E_Balanced && r1completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r1completedMatch.E_Balanced = true;
                        }
                    }
                    else
                    {
                        if (r1completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r1completedMatch.E_Balanced = false;
                        }
                    }
                    r1completedMatch.APIAccuracy = currentscore;
                    //RED 2
                    currentscore = 10;
                    if (completedMatch.score_breakdown.red.initLineRobot2 == "None")
                    {
                        if (!r2completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            r2completedMatch.A_InitiationLine = true;
                        }
                    }
                    else
                    {
                        if (r2completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            r2completedMatch.A_InitiationLine = false;
                        }
                    }
                    if (completedMatch.score_breakdown.red.endgameRobot2 == "None")
                    {
                        if (r2completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r2completedMatch.E_ClimbSuccess = false;
                        }
                        if (r2completedMatch.E_Park)
                        {
                            currentscore--;
                            r2completedMatch.E_Park = false;
                        }
                        if (r2completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r2completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.red.endgameRobot2 == "Park")
                    {
                        if (r2completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r2completedMatch.E_ClimbSuccess = false;
                        }
                        if (!r2completedMatch.E_Park)
                        {
                            currentscore--;
                            r2completedMatch.E_Park = true;
                        }
                        if (r2completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r2completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.red.endgameRobot2 == "Hang")
                    {
                        if (!r2completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r2completedMatch.E_ClimbSuccess = true;
                        }
                        if (r2completedMatch.E_Park)
                        {
                            currentscore--;
                            r2completedMatch.E_Park = false;
                        }
                    }
                    if (completedMatch.score_breakdown.red.endgameRungIsLevel == "IsLevel")
                    {
                        if (!r2completedMatch.E_Balanced && r2completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r2completedMatch.E_Balanced = true;
                        }
                    }
                    else
                    {
                        if (r2completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r2completedMatch.E_Balanced = false;
                        }
                    }
                    r2completedMatch.APIAccuracy = currentscore;
                    //RED 3
                    currentscore = 10;
                    if (completedMatch.score_breakdown.red.initLineRobot3 == "None")
                    {
                        if (!r3completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            r3completedMatch.A_InitiationLine = true;
                        }
                    }
                    else
                    {
                        if (r3completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            r3completedMatch.A_InitiationLine = false;
                        }
                    }
                    if (completedMatch.score_breakdown.red.endgameRobot3 == "None")
                    {
                        if (r3completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r3completedMatch.E_ClimbSuccess = false;
                        }
                        if (r3completedMatch.E_Park)
                        {
                            currentscore--;
                            r3completedMatch.E_Park = false;
                        }
                        if (r3completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r3completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.red.endgameRobot3 == "Park")
                    {
                        if (r3completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r3completedMatch.E_ClimbSuccess = false;
                        }
                        if (!r3completedMatch.E_Park)
                        {
                            currentscore--;
                            r3completedMatch.E_Park = true;
                        }
                        if (r3completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r3completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.red.endgameRobot3 == "Hang")
                    {
                        if (!r3completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r3completedMatch.E_ClimbSuccess = true;
                        }
                        if (r3completedMatch.E_Park)
                        {
                            currentscore--;
                            r3completedMatch.E_Park = false;
                        }
                    }
                    if (completedMatch.score_breakdown.red.endgameRungIsLevel == "IsLevel")
                    {
                        if (!r3completedMatch.E_Balanced && r3completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            r3completedMatch.E_Balanced = true;
                        }
                    }
                    else
                    {
                        if (r3completedMatch.E_Balanced)
                        {
                            currentscore--;
                            r3completedMatch.E_Balanced = false;
                        }
                    }
                    r3completedMatch.APIAccuracy = currentscore;
                    //BLUE 1
                    currentscore = 10;
                    if (completedMatch.score_breakdown.blue.initLineRobot1 == "None")
                    {
                        if (!b1completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            b1completedMatch.A_InitiationLine = true;
                        }
                    }
                    else
                    {
                        if (b1completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            b1completedMatch.A_InitiationLine = false;
                        }
                    }
                    if (completedMatch.score_breakdown.blue.endgameRobot1 == "None")
                    {
                        if (b1completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b1completedMatch.E_ClimbSuccess = false;
                        }
                        if (b1completedMatch.E_Park)
                        {
                            currentscore--;
                            b1completedMatch.E_Park = false;
                        }
                        if (b1completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b1completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.blue.endgameRobot1 == "Park")
                    {
                        if (b1completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b1completedMatch.E_ClimbSuccess = false;
                        }
                        if (!b1completedMatch.E_Park)
                        {
                            currentscore--;
                            b1completedMatch.E_Park = true;
                        }
                        if (b1completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b1completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.blue.endgameRobot1 == "Hang")
                    {
                        if (!b1completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b1completedMatch.E_ClimbSuccess = true;
                        }
                        if (b1completedMatch.E_Park)
                        {
                            currentscore--;
                            b1completedMatch.E_Park = false;
                        }
                    }
                    if (completedMatch.score_breakdown.blue.endgameRungIsLevel == "IsLevel")
                    {
                        if (!b1completedMatch.E_Balanced && b1completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b1completedMatch.E_Balanced = true;
                        }
                    }
                    else
                    {
                        if (b1completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b1completedMatch.E_Balanced = false;
                        }
                    }
                    b1completedMatch.APIAccuracy = currentscore;
                    //BLUE 2
                    currentscore = 10;
                    if (completedMatch.score_breakdown.blue.initLineRobot3 == "None")
                    {
                        if (!b2completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            b2completedMatch.A_InitiationLine = true;
                        }
                    }
                    else
                    {
                        if (b2completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            b2completedMatch.A_InitiationLine = false;
                        }
                    }
                    if (completedMatch.score_breakdown.blue.endgameRobot3 == "None")
                    {
                        if (b2completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b2completedMatch.E_ClimbSuccess = false;
                        }
                        if (b2completedMatch.E_Park)
                        {
                            currentscore--;
                            b2completedMatch.E_Park = false;
                        }
                        if (b2completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b2completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.blue.endgameRobot3 == "Park")
                    {
                        if (b2completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b2completedMatch.E_ClimbSuccess = false;
                        }
                        if (!b2completedMatch.E_Park)
                        {
                            currentscore--;
                            b2completedMatch.E_Park = true;
                        }
                        if (b2completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b2completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.blue.endgameRobot3 == "Hang")
                    {
                        if (!b2completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b2completedMatch.E_ClimbSuccess = true;
                        }
                        if (b2completedMatch.E_Park)
                        {
                            currentscore--;
                            b2completedMatch.E_Park = false;
                        }
                    }
                    if (completedMatch.score_breakdown.blue.endgameRungIsLevel == "IsLevel")
                    {
                        if (!b2completedMatch.E_Balanced && b2completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b2completedMatch.E_Balanced = true;
                        }
                    }
                    else
                    {
                        if (b2completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b2completedMatch.E_Balanced = false;
                        }
                    }
                    b2completedMatch.APIAccuracy = currentscore;
                    //BLUE 3
                    currentscore = 10;
                    if (completedMatch.score_breakdown.blue.initLineRobot3 == "None")
                    {
                        if (!b3completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            b3completedMatch.A_InitiationLine = true;
                        }
                    }
                    else
                    {
                        if (b3completedMatch.A_InitiationLine)
                        {
                            currentscore--;
                            b3completedMatch.A_InitiationLine = false;
                        }
                    }
                    if (completedMatch.score_breakdown.blue.endgameRobot3 == "None")
                    {
                        if (b3completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b3completedMatch.E_ClimbSuccess = false;
                        }
                        if (b3completedMatch.E_Park)
                        {
                            currentscore--;
                            b3completedMatch.E_Park = false;
                        }
                        if (b3completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b3completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.blue.endgameRobot3 == "Park")
                    {
                        if (b3completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b3completedMatch.E_ClimbSuccess = false;
                        }
                        if (!b3completedMatch.E_Park)
                        {
                            currentscore--;
                            b3completedMatch.E_Park = true;
                        }
                        if (b3completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b3completedMatch.E_Balanced = false;
                        }
                    }
                    else if (completedMatch.score_breakdown.blue.endgameRobot3 == "Hang")
                    {
                        if (!b3completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b3completedMatch.E_ClimbSuccess = true;
                        }
                        if (b3completedMatch.E_Park)
                        {
                            currentscore--;
                            b3completedMatch.E_Park = false;
                        }
                    }
                    if (completedMatch.score_breakdown.blue.endgameRungIsLevel == "IsLevel")
                    {
                        if (!b3completedMatch.E_Balanced && b3completedMatch.E_ClimbSuccess)
                        {
                            currentscore--;
                            b3completedMatch.E_Balanced = true;
                        }
                    }
                    else
                    {
                        if (b3completedMatch.E_Balanced)
                        {
                            currentscore--;
                            b3completedMatch.E_Balanced = false;
                        }
                    }
                    b3completedMatch.APIAccuracy = currentscore;
                    r1completedMatch.APIChecked = true;
                    r2completedMatch.APIChecked = true;
                    r3completedMatch.APIChecked = true;
                    b1completedMatch.APIChecked = true;
                    b2completedMatch.APIChecked = true;
                    b3completedMatch.APIChecked = true;
                    //db.Entry(db.Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == 862).FirstOrDefault()).CurrentValues.SetValues(r1completedMatch);
                    //db.Entry(db.Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == 862).FirstOrDefault()).CurrentValues.SetValues(r2completedMatch);
                    //db.Entry(db.Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == 862).FirstOrDefault()).CurrentValues.SetValues(r3completedMatch);
                    //db.Entry(db.Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == 862).FirstOrDefault()).CurrentValues.SetValues(b1completedMatch);
                    //db.Entry(db.Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == 862).FirstOrDefault()).CurrentValues.SetValues(b2completedMatch);
                    //db.Entry(db.Matches.Where(x => x.MatchNumber == completedMatch.match_number && x.TeamNumber == 862).FirstOrDefault()).CurrentValues.SetValues(b3completedMatch);
                    db.Matches.Update(r1completedMatch);
                    db.Matches.Update(r2completedMatch);
                    db.Matches.Update(r3completedMatch);
                    db.Matches.Update(b1completedMatch);
                    db.Matches.Update(b2completedMatch);
                    db.Matches.Update(b3completedMatch);
                    db.SaveChanges();
                }
            }
            
        }
    }
}
