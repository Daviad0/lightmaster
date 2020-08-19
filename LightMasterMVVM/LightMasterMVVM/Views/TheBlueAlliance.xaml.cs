using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LightMasterMVVM.DbAssets;
using LightMasterMVVM.Models;
using LightMasterMVVM.Scripts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace LightMasterMVVM.Views
{
    public class TheBlueAlliance : UserControl
    {
        private Button getTBAData;
        public TheBlueAlliance()
        {
            this.InitializeComponent();
            getTBAData = this.Find<Button>("getTBAData");
            getTBAData.Click += GetTBAData_Click;
        }

        private void GetTBAData_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (CheckForInternetConnection())
            {
                using (var db = new ScoutingContext())
                {
                    string eventcode = new GetEventCode().EventCode();
                    var urltoget = "https://www.thebluealliance.com/api/v3/event/" + eventcode + "/matches";
                    string tbamatches = "";
                    var request = (HttpWebRequest)WebRequest.Create(urltoget);
                    request.Headers.Add("X-TBA-Auth-Key", "kzyt55ci5iHn3X1T8BgXYu2yMXmAjdxV5OCXHVA16CRfX8C0Z6tfrwU4BajyleY3");
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        tbamatches = reader.ReadToEnd();
                        Console.WriteLine(tbamatches);
                    }
                    var listofallmatches = JsonConvert.DeserializeObject<List<TBA_Match>>(tbamatches);
                    if(listofallmatches.Count > 0)
                    {
                        foreach (var match in listofallmatches)
                        {
                            if(match.comp_level == "qm")
                            {
                                if (match.actual_time == 0)
                                {
                                    Console.WriteLine("Something isn't right... This match has already been completed (Match " + match.match_number + ")");
                                }
                                if(db.FRCTeams.Where(x => x.event_key == eventcode && x.team_number == int.Parse(match.alliances.red.team_keys[0])).FirstOrDefault() == null)
                                {
                                    db.FRCTeams.Add(new FRCTeamModel() { event_key = eventcode, team_number = int.Parse(match.alliances.red.team_keys[0]) });
                                }
                                if (db.FRCTeams.Where(x => x.event_key == eventcode && x.team_number == int.Parse(match.alliances.red.team_keys[1])).FirstOrDefault() == null)
                                {
                                    db.FRCTeams.Add(new FRCTeamModel() { event_key = eventcode, team_number = int.Parse(match.alliances.red.team_keys[1]) });
                                }
                                if (db.FRCTeams.Where(x => x.event_key == eventcode && x.team_number == int.Parse(match.alliances.red.team_keys[2])).FirstOrDefault() == null)
                                {
                                    db.FRCTeams.Add(new FRCTeamModel() { event_key = eventcode, team_number = int.Parse(match.alliances.red.team_keys[2]) });
                                }
                                if (db.FRCTeams.Where(x => x.event_key == eventcode && x.team_number == int.Parse(match.alliances.blue.team_keys[0])).FirstOrDefault() == null)
                                {
                                    db.FRCTeams.Add(new FRCTeamModel() { event_key = eventcode, team_number = int.Parse(match.alliances.blue.team_keys[0]) });
                                }
                                if (db.FRCTeams.Where(x => x.event_key == eventcode && x.team_number == int.Parse(match.alliances.blue.team_keys[1])).FirstOrDefault() == null)
                                {
                                    db.FRCTeams.Add(new FRCTeamModel() { event_key = eventcode, team_number = int.Parse(match.alliances.blue.team_keys[1]) });
                                }
                                if (db.FRCTeams.Where(x => x.event_key == eventcode && x.team_number == int.Parse(match.alliances.blue.team_keys[2])).FirstOrDefault() == null)
                                {
                                    db.FRCTeams.Add(new FRCTeamModel() { event_key = eventcode, team_number = int.Parse(match.alliances.blue.team_keys[2]) });
                                }
                                db.SaveChanges();
                                var r1TeamMatch = new TeamMatch() { EventCode = eventcode, PowerCellInner = new int[21], PowerCellOuter = new int[21], PowerCellLower = new int[21], PowerCellMissed = new int[21], MatchNumber = match.match_number, IsQualifying = true, TabletId = "R1", TrackedTeam = db.FRCTeams.Where(x => x.team_number == int.Parse(match.alliances.red.team_keys[0]) && x.event_key == eventcode).FirstOrDefault() };
                                var r2TeamMatch = new TeamMatch() { EventCode = eventcode, PowerCellInner = new int[21], PowerCellOuter = new int[21], PowerCellLower = new int[21], PowerCellMissed = new int[21], MatchNumber = match.match_number, IsQualifying = true, TabletId = "R2", TrackedTeam = db.FRCTeams.Where(x => x.team_number == int.Parse(match.alliances.red.team_keys[1]) && x.event_key == eventcode).FirstOrDefault() };
                                var r3TeamMatch = new TeamMatch() { EventCode = eventcode, PowerCellInner = new int[21], PowerCellOuter = new int[21], PowerCellLower = new int[21], PowerCellMissed = new int[21], MatchNumber = match.match_number, IsQualifying = true, TabletId = "R3", TrackedTeam = db.FRCTeams.Where(x => x.team_number == int.Parse(match.alliances.red.team_keys[2]) && x.event_key == eventcode).FirstOrDefault() };
                                var b1TeamMatch = new TeamMatch() { EventCode = eventcode, PowerCellInner = new int[21], PowerCellOuter = new int[21], PowerCellLower = new int[21], PowerCellMissed = new int[21], MatchNumber = match.match_number, IsQualifying = true, TabletId = "B1", TrackedTeam = db.FRCTeams.Where(x => x.team_number == int.Parse(match.alliances.blue.team_keys[0]) && x.event_key == eventcode).FirstOrDefault() };
                                var b2TeamMatch = new TeamMatch() { EventCode = eventcode, PowerCellInner = new int[21], PowerCellOuter = new int[21], PowerCellLower = new int[21], PowerCellMissed = new int[21], MatchNumber = match.match_number, IsQualifying = true, TabletId = "B2", TrackedTeam = db.FRCTeams.Where(x => x.team_number == int.Parse(match.alliances.blue.team_keys[1]) && x.event_key == eventcode).FirstOrDefault() };
                                var b3TeamMatch = new TeamMatch() { EventCode = eventcode, PowerCellInner = new int[21], PowerCellOuter = new int[21], PowerCellLower = new int[21], PowerCellMissed = new int[21], MatchNumber = match.match_number, IsQualifying = true, TabletId = "B3", TrackedTeam = db.FRCTeams.Where(x => x.team_number == int.Parse(match.alliances.blue.team_keys[2]) && x.event_key == eventcode).FirstOrDefault() };
                                if(db.Matches.Where(x => x.EventCode == eventcode && x.MatchNumber == match.match_number && x.TabletId == "R1").FirstOrDefault() == null)
                                {
                                    db.Matches.Add(r1TeamMatch);
                                }
                                if (db.Matches.Where(x => x.EventCode == eventcode && x.MatchNumber == match.match_number && x.TabletId == "R2").FirstOrDefault() == null)
                                {
                                    db.Matches.Add(r2TeamMatch);
                                }
                                if (db.Matches.Where(x => x.EventCode == eventcode && x.MatchNumber == match.match_number && x.TabletId == "R3").FirstOrDefault() == null)
                                {
                                    db.Matches.Add(r3TeamMatch);
                                }
                                if (db.Matches.Where(x => x.EventCode == eventcode && x.MatchNumber == match.match_number && x.TabletId == "B1").FirstOrDefault() == null)
                                {
                                    db.Matches.Add(b1TeamMatch);
                                }
                                if (db.Matches.Where(x => x.EventCode == eventcode && x.MatchNumber == match.match_number && x.TabletId == "B2").FirstOrDefault() == null)
                                {
                                    db.Matches.Add(b2TeamMatch);
                                }
                                if (db.Matches.Where(x => x.EventCode == eventcode && x.MatchNumber == match.match_number && x.TabletId == "B3").FirstOrDefault() == null)
                                {
                                    db.Matches.Add(b3TeamMatch);
                                }
                                db.SaveChanges();
                            }
                            getTBAData.Content = "Successful";
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matches are available for this event code!");
                        getTBAData.Content = "Failure";
                    }
                    
                }
            }
            
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
