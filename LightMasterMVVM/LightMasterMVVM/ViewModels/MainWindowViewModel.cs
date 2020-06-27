using Avalonia.Media;
using GalaSoft.MvvmLight.Messaging;
using InTheHand.Net.Sockets;
using LightMasterMVVM.DbAssets;
using LightMasterMVVM.Models;
using LightMasterMVVM.Views;
using Newtonsoft.Json;
using Npgsql;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using Websocket.Client;

namespace LightMasterMVVM.ViewModels
{
    public class MatchViewModel : ViewModelBase
    {
        private string testText = "abc";
        private TeamMatchView red1CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView red2CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView red3CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView blue1CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView blue2CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView blue3CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private bool userControlVisible = true;
        public bool UserControlVisible
        {
            get => userControlVisible;
            set => SetProperty(ref userControlVisible, value);
        }
        public string TestText
        {
            get => testText;
            set => SetProperty(ref testText, value);
        }
        public TeamMatchView Red1CurrentMatch
        {
            get => red1CurrentMatch;
            set => SetProperty(ref red1CurrentMatch, value);
        }
        public TeamMatchView Red2CurrentMatch
        {
            get => red2CurrentMatch;
            set => SetProperty(ref red2CurrentMatch, value);
        }
        public TeamMatchView Red3CurrentMatch
        {
            get => red3CurrentMatch;
            set => SetProperty(ref red3CurrentMatch, value);
        }
        public TeamMatchView Blue1CurrentMatch
        {
            get => blue1CurrentMatch;
            set => SetProperty(ref blue1CurrentMatch, value);
        }
        public TeamMatchView Blue2CurrentMatch
        {
            get => blue2CurrentMatch;
            set => SetProperty(ref blue2CurrentMatch, value);
        }
        public TeamMatchView Blue3CurrentMatch
        {
            get => blue3CurrentMatch;
            set => SetProperty(ref blue3CurrentMatch, value);
        }
    }
    public class TabletViewModel : ViewModelBase
    {
        private List<string> testBTD = new List<string>();
        private string _text = "Test";
        private ObservableCollection<string> bluetoothBorderColors = new ObservableCollection<string>(new string[6] { "Gray", "Gray", "Gray", "Gray", "Gray", "Gray" }.ToList());
        private ObservableCollection<string> cableBorderColors = new ObservableCollection<string>(new string[6] { "Gray", "Gray", "Gray", "Gray", "Gray", "Gray" }.ToList());
        private ObservableCollection<string> batteryBorderColors = new ObservableCollection<string>(new string[6] { "Gray", "Gray", "Gray", "Gray", "Gray", "Gray" }.ToList());
        private ObservableCollection<string> bluetoothBackgroundColors = new ObservableCollection<string>(new string[6] { "LightGray", "LightGray", "LightGray", "LightGray", "LightGray", "LightGray" }.ToList());
        private ObservableCollection<string> cableBackgroundColors = new ObservableCollection<string>(new string[6] { "LightGray", "LightGray", "LightGray", "LightGray", "LightGray", "LightGray" }.ToList());
        private ObservableCollection<string> batteryBackgroundColors = new ObservableCollection<string>(new string[6] { "LightGray", "LightGray", "LightGray", "LightGray", "LightGray", "LightGray" }.ToList());
        private ObservableCollection<string> batteryAmounts = new ObservableCollection<string>(new string[6] { "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized" }.ToList());
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        public List<string> TestBTD
        {
            get => testBTD;
            set => SetProperty(ref testBTD, value);
        }
        private bool userControlVisible = false;
        public bool UserControlVisible
        {
            get => userControlVisible;
            set => SetProperty(ref userControlVisible, value);
        }
        public ObservableCollection<string> BluetoothBorderColors
        {
            get => bluetoothBorderColors;
            set => SetProperty(ref bluetoothBorderColors, value);
        }
        public ObservableCollection<string> CableBorderColors
        {
            get => cableBorderColors;
            set => SetProperty(ref cableBorderColors, value);
        }
        public ObservableCollection<string> BatteryBorderColors
        {
            get => batteryBorderColors;
            set => SetProperty(ref batteryBorderColors, value);
        }
        public ObservableCollection<string> BluetoothBackgroundColors
        {
            get => bluetoothBackgroundColors;
            set => SetProperty(ref bluetoothBackgroundColors, value);
        }
        public ObservableCollection<string> CableBackgroundColors
        {
            get => cableBackgroundColors;
            set => SetProperty(ref cableBackgroundColors, value);
        }
        public ObservableCollection<string> BatteryBackgroundColors
        {
            get => batteryBackgroundColors;
            set => SetProperty(ref batteryBackgroundColors, value);
        }
        public ObservableCollection<string> BatteryAmounts
        {
            get => batteryAmounts;
            set => SetProperty(ref batteryAmounts, value);
        }
        public void SetTest()
        {
            bluetoothBackgroundColors[0] = "Red";
            Text = "WORK";
        }

    }
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            
        }
        public int currentMatchNum = 1;
        private string matchNumString = "Match 1";
        private TabletViewModel tabletViewModel = new TabletViewModel();
        private MatchViewModel matchViewModel = new MatchViewModel();
        private string _text = "Initial text";
        private bool userControlVisible = false;
        public TabletViewModel TabletViewModel
        {
            get => tabletViewModel;
            set => SetProperty(ref tabletViewModel, value);
        }
        public string MatchNumString
        {
            get => matchNumString;
            set => SetProperty(ref matchNumString, value);
        }
        public MatchViewModel MatchViewModel
        {
            get =>  matchViewModel;
            set => SetProperty(ref matchViewModel, value);
        }

        public string Text
        {
            get => _text;
            // SetProperty will trigger PropertyChanged event so the view is notified
            set => SetProperty(ref _text, value);
        }
        public bool UserControlVisible
        {
            get => userControlVisible;
            set => SetProperty(ref userControlVisible, value);
        }

        // Unlike WPF avalonia supports binding commands to view model methods. You can still use ICommand though
        public void ChangeText(object text)
        {
            Text = (string)text;
        }
        public void StartCheck()
        {
            Console.WriteLine(matchViewModel.Blue1CurrentMatch.ScoutName.ToString());
            var exitEvent = new ManualResetEvent(false);
            var url = new Uri("ws://localhost:8080");

            var client = new WebsocketClient(url);
            client.ReconnectTimeout = null;
            /*client.ReconnectionHappened.Subscribe(info =>
                Log.Information($"Reconnection happened, type: {info.Type}"));*/

            client.MessageReceived.Subscribe(msg => {
                string rawdata = msg.Text;
                int tabletindex = 0;
                if (rawdata.StartsWith("R1"))
                {
                    tabletindex = 3;
                }
                else if (rawdata.StartsWith("R2"))
                {
                    tabletindex = 4;
                }
                else if (rawdata.StartsWith("R3"))
                {
                    tabletindex = 5;
                }
                else if (rawdata.StartsWith("B1"))
                {
                    tabletindex = 0;
                }
                else if (rawdata.StartsWith("B2"))
                {
                    tabletindex = 1;
                }
                else if (rawdata.StartsWith("B3"))
                {
                    tabletindex = 2;
                }

                if (rawdata.Substring(3).StartsWith("S:"))
                {
                    //S = Score
                    TabletViewModel.BluetoothBackgroundColors[tabletindex] = "LightBlue";
                    TabletViewModel.BluetoothBorderColors[tabletindex] = "Blue";
                    var jsontodeserialize = rawdata.Substring(5);
                    using(var db = new ScoutingContext())
                    {
                        var itemtouse = JsonConvert.DeserializeObject<TeamMatch>(jsontodeserialize);
                        try
                        {
                            var previousitem = db.Matches.Where(x => x.TabletId == itemtouse.TabletId && x.MatchNumber == itemtouse.MatchNumber && x.EventCode == itemtouse.EventCode).FirstOrDefault();
                            if(previousitem == null)
                            {
                                itemtouse.MatchID = new Random().Next(1, 1000);
                                db.Matches.Add(itemtouse);
                            }
                            else
                            {
                                itemtouse.MatchID = previousitem.MatchID;
                                db.Entry(previousitem).CurrentValues.SetValues(itemtouse);
                            }
                           
                            
                        }
                        catch(NpgsqlException ex)
                        {
                            itemtouse.MatchID = new Random().Next(1, 1000);
                            db.Matches.Add(itemtouse);
                        }
                        
                        db.SaveChanges();
                    }
                }
                else if (rawdata.Substring(3).StartsWith("B:"))
                {
                    //B = Battery Level
                    var batterylevel = float.Parse(rawdata.Substring(5)) * 100;
                    if(batterylevel > 80)
                    {
                        TabletViewModel.BatteryBackgroundColors[tabletindex] = "LightGreen";
                        TabletViewModel.BatteryBorderColors[tabletindex] = "Green";
                    }
                    else if(batterylevel > 30 && batterylevel <= 80)
                    {
                        TabletViewModel.BatteryBackgroundColors[tabletindex] = "LightSalmon";
                        TabletViewModel.BatteryBorderColors[tabletindex] = "DarkOrange";
                    }
                    else
                    {
                        TabletViewModel.BatteryBackgroundColors[tabletindex] = "LightPink";
                        TabletViewModel.BatteryBorderColors[tabletindex] = "IndianRed";
                    }
                    
                }
                else if (rawdata.Substring(3).StartsWith("D:"))
                {
                    //D = Successful Disconnection
                    TabletViewModel.BluetoothBackgroundColors[tabletindex] = "LightGray";
                    TabletViewModel.BluetoothBorderColors[tabletindex] = "Gray";
                }
                else if (rawdata.Substring(3).StartsWith("E:"))
                {
                    //E = Immedient Communication
                    TabletViewModel.BluetoothBackgroundColors[tabletindex] = "LightSalmon";
                    TabletViewModel.BluetoothBorderColors[tabletindex] = "DarkOrange";
                }


                Console.WriteLine(msg.Text);
            });
            client.DisconnectionHappened.Subscribe(msg => {
                Console.WriteLine("Uh oh! I disconnected!");
            });
            client.Start();

            //Task.Run(() => client.Send("{ message }"));
        }
        public void GetBluetoothDevices()
        {
            BluetoothClient client = new BluetoothClient();
            List<string> items = new List<string>();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices(255, true,true,true);
            foreach (BluetoothDeviceInfo d in devices)
            {
                items.Add(d.DeviceName);
                Console.WriteLine(d.DeviceName);
            }
            tabletViewModel.TestBTD = items;
        }
        public void SeeMatches()
        {
            tabletViewModel.UserControlVisible = false;
            matchViewModel.UserControlVisible = true;
            using(var db = new ScoutingContext())
            {
                var r1selectedmatch = db.Matches.Where(x => x.TabletId == "R1" && x.EventCode == "test_env").FirstOrDefault();
                if(r1selectedmatch == null)
                {
                    MatchViewModel.Red1CurrentMatch = new TeamMatchView();
                }
                else
                {
                    var matchtoput = new TeamMatchView();
                    matchtoput.A_InitiationLine = r1selectedmatch.A_InitiationLine;
                    matchtoput.DisabledSeconds = r1selectedmatch.DisabledSeconds;
                    matchtoput.EventCode = r1selectedmatch.EventCode;
                    matchtoput.E_Balanced = r1selectedmatch.E_Balanced;
                    matchtoput.E_ClimbAttempt = r1selectedmatch.E_ClimbAttempt;
                    matchtoput.E_ClimbSuccess = r1selectedmatch.E_ClimbSuccess;
                    matchtoput.E_Park = r1selectedmatch.E_Park;
                    matchtoput.MatchNumber = r1selectedmatch.MatchNumber;
                    matchtoput.NumCycles = r1selectedmatch.NumCycles;
                    matchtoput.ScoutName = r1selectedmatch.ScoutName;
                    matchtoput.TeamNumber = r1selectedmatch.TeamNumber;
                    matchtoput.T_ControlPanelPosition = r1selectedmatch.T_ControlPanelPosition;
                    matchtoput.T_ControlPanelRotation = r1selectedmatch.T_ControlPanelRotation;
                    if (r1selectedmatch.PowerCellMissed != null)
                    {
                        matchtoput.APowerCellInner = r1selectedmatch.PowerCellInner[0];
                        matchtoput.APowerCellOuter = r1selectedmatch.PowerCellOuter[0];
                        matchtoput.APowerCellLower = r1selectedmatch.PowerCellLower[0];
                        matchtoput.APowerCellMissed = r1selectedmatch.PowerCellMissed[0];
                        foreach (var value in r1selectedmatch.PowerCellInner.Skip(1))
                        {
                            matchtoput.TPowerCellInner += value;
                        }
                        foreach (var value in r1selectedmatch.PowerCellOuter.Skip(1))
                        {
                            matchtoput.TPowerCellOuter += value;
                        }
                        foreach (var value in r1selectedmatch.PowerCellLower.Skip(1))
                        {
                            matchtoput.TPowerCellLower += value;
                        }
                        foreach (var value in r1selectedmatch.PowerCellMissed.Skip(1))
                        {
                            matchtoput.TPowerCellMissed += value;
                        }
                    }
                    MatchViewModel.Red1CurrentMatch = matchtoput;
                }
                //RED2
                var r2selectedmatch = db.Matches.Where(x => x.TabletId == "R2" && x.EventCode == "test_env").FirstOrDefault();
                if (r2selectedmatch == null)
                {
                    MatchViewModel.Red2CurrentMatch = new TeamMatchView();
                }
                else
                {
                    var matchtoput = new TeamMatchView();
                    matchtoput.A_InitiationLine = r2selectedmatch.A_InitiationLine;
                    matchtoput.DisabledSeconds = r2selectedmatch.DisabledSeconds;
                    matchtoput.EventCode = r2selectedmatch.EventCode;
                    matchtoput.E_Balanced = r2selectedmatch.E_Balanced;
                    matchtoput.E_ClimbAttempt = r2selectedmatch.E_ClimbAttempt;
                    matchtoput.E_ClimbSuccess = r2selectedmatch.E_ClimbSuccess;
                    matchtoput.E_Park = r2selectedmatch.E_Park;
                    matchtoput.MatchNumber = r2selectedmatch.MatchNumber;
                    matchtoput.NumCycles = r2selectedmatch.NumCycles;
                    matchtoput.ScoutName = r2selectedmatch.ScoutName;
                    matchtoput.TeamNumber = r2selectedmatch.TeamNumber;
                    matchtoput.T_ControlPanelPosition = r2selectedmatch.T_ControlPanelPosition;
                    matchtoput.T_ControlPanelRotation = r2selectedmatch.T_ControlPanelRotation;
                    if (r2selectedmatch.PowerCellMissed != null)
                    {
                        matchtoput.APowerCellInner = r2selectedmatch.PowerCellInner[0];
                        matchtoput.APowerCellOuter = r2selectedmatch.PowerCellOuter[0];
                        matchtoput.APowerCellLower = r2selectedmatch.PowerCellLower[0];
                        matchtoput.APowerCellMissed = r2selectedmatch.PowerCellMissed[0];
                        foreach (var value in r2selectedmatch.PowerCellInner.Skip(1))
                        {
                            matchtoput.TPowerCellInner += value;
                        }
                        foreach (var value in r2selectedmatch.PowerCellOuter.Skip(1))
                        {
                            matchtoput.TPowerCellOuter += value;
                        }
                        foreach (var value in r2selectedmatch.PowerCellLower.Skip(1))
                        {
                            matchtoput.TPowerCellLower += value;
                        }
                        foreach (var value in r2selectedmatch.PowerCellMissed.Skip(1))
                        {
                            matchtoput.TPowerCellMissed += value;
                        }
                    }
                    MatchViewModel.Red2CurrentMatch = matchtoput;
                }
                //RED3
                var r3selectedmatch = db.Matches.Where(x => x.TabletId == "R3" && x.EventCode == "test_env").FirstOrDefault();
                if (r3selectedmatch == null)
                {
                    MatchViewModel.Red3CurrentMatch = new TeamMatchView();
                }
                else
                {
                    var matchtoput = new TeamMatchView();
                    matchtoput.A_InitiationLine = r3selectedmatch.A_InitiationLine;
                    matchtoput.DisabledSeconds = r3selectedmatch.DisabledSeconds;
                    matchtoput.EventCode = r3selectedmatch.EventCode;
                    matchtoput.E_Balanced = r3selectedmatch.E_Balanced;
                    matchtoput.E_ClimbAttempt = r3selectedmatch.E_ClimbAttempt;
                    matchtoput.E_ClimbSuccess = r3selectedmatch.E_ClimbSuccess;
                    matchtoput.E_Park = r3selectedmatch.E_Park;
                    matchtoput.MatchNumber = r3selectedmatch.MatchNumber;
                    matchtoput.NumCycles = r3selectedmatch.NumCycles;
                    matchtoput.ScoutName = r3selectedmatch.ScoutName;
                    matchtoput.TeamNumber = r3selectedmatch.TeamNumber;
                    matchtoput.T_ControlPanelPosition = r3selectedmatch.T_ControlPanelPosition;
                    matchtoput.T_ControlPanelRotation = r3selectedmatch.T_ControlPanelRotation;
                    if (r3selectedmatch.PowerCellMissed != null)
                    {
                        matchtoput.APowerCellInner = r3selectedmatch.PowerCellInner[0];
                        matchtoput.APowerCellOuter = r3selectedmatch.PowerCellOuter[0];
                        matchtoput.APowerCellLower = r3selectedmatch.PowerCellLower[0];
                        matchtoput.APowerCellMissed = r3selectedmatch.PowerCellMissed[0];
                        foreach (var value in r3selectedmatch.PowerCellInner.Skip(1))
                        {
                            matchtoput.TPowerCellInner += value;
                        }
                        foreach (var value in r3selectedmatch.PowerCellOuter.Skip(1))
                        {
                            matchtoput.TPowerCellOuter += value;
                        }
                        foreach (var value in r3selectedmatch.PowerCellLower.Skip(1))
                        {
                            matchtoput.TPowerCellLower += value;
                        }
                        foreach (var value in r3selectedmatch.PowerCellMissed.Skip(1))
                        {
                            matchtoput.TPowerCellMissed += value;
                        }
                    }
                    MatchViewModel.Red3CurrentMatch = matchtoput;
                }
                //BLUE1
                var b1selectedmatch = db.Matches.Where(x => x.TabletId == "B1" && x.EventCode == "test_env").FirstOrDefault();
                if (b1selectedmatch == null)
                {
                    MatchViewModel.Blue1CurrentMatch = new TeamMatchView();
                }
                else
                {
                    var matchtoput = new TeamMatchView();
                    matchtoput.A_InitiationLine = b1selectedmatch.A_InitiationLine;
                    matchtoput.DisabledSeconds = b1selectedmatch.DisabledSeconds;
                    matchtoput.EventCode = b1selectedmatch.EventCode;
                    matchtoput.E_Balanced = b1selectedmatch.E_Balanced;
                    matchtoput.E_ClimbAttempt = b1selectedmatch.E_ClimbAttempt;
                    matchtoput.E_ClimbSuccess = b1selectedmatch.E_ClimbSuccess;
                    matchtoput.E_Park = b1selectedmatch.E_Park;
                    matchtoput.MatchNumber = b1selectedmatch.MatchNumber;
                    matchtoput.NumCycles = b1selectedmatch.NumCycles;
                    matchtoput.ScoutName = b1selectedmatch.ScoutName;
                    matchtoput.TeamNumber = b1selectedmatch.TeamNumber;
                    matchtoput.T_ControlPanelPosition = b1selectedmatch.T_ControlPanelPosition;
                    matchtoput.T_ControlPanelRotation = b1selectedmatch.T_ControlPanelRotation;
                    if (b1selectedmatch.PowerCellMissed != null)
                    {
                        matchtoput.APowerCellInner = b1selectedmatch.PowerCellInner[0];
                        matchtoput.APowerCellOuter = b1selectedmatch.PowerCellOuter[0];
                        matchtoput.APowerCellLower = b1selectedmatch.PowerCellLower[0];
                        matchtoput.APowerCellMissed = b1selectedmatch.PowerCellMissed[0];
                        foreach (var value in b1selectedmatch.PowerCellInner.Skip(1))
                        {
                            matchtoput.TPowerCellInner += value;
                        }
                        foreach (var value in b1selectedmatch.PowerCellOuter.Skip(1))
                        {
                            matchtoput.TPowerCellOuter += value;
                        }
                        foreach (var value in b1selectedmatch.PowerCellLower.Skip(1))
                        {
                            matchtoput.TPowerCellLower += value;
                        }
                        foreach (var value in b1selectedmatch.PowerCellMissed.Skip(1))
                        {
                            matchtoput.TPowerCellMissed += value;
                        }
                    }
                    MatchViewModel.Blue1CurrentMatch = matchtoput;
                }
                //BLUE2
                var b2selectedmatch = db.Matches.Where(x => x.TabletId == "B2" && x.EventCode == "test_env").FirstOrDefault();
                if (b2selectedmatch == null)
                {
                    MatchViewModel.Blue2CurrentMatch = new TeamMatchView();
                }
                else
                {
                    var matchtoput = new TeamMatchView();
                    matchtoput.A_InitiationLine = b2selectedmatch.A_InitiationLine;
                    matchtoput.DisabledSeconds = b2selectedmatch.DisabledSeconds;
                    matchtoput.EventCode = b2selectedmatch.EventCode;
                    matchtoput.E_Balanced = b2selectedmatch.E_Balanced;
                    matchtoput.E_ClimbAttempt = b2selectedmatch.E_ClimbAttempt;
                    matchtoput.E_ClimbSuccess = b2selectedmatch.E_ClimbSuccess;
                    matchtoput.E_Park = b2selectedmatch.E_Park;
                    matchtoput.MatchNumber = b2selectedmatch.MatchNumber;
                    matchtoput.NumCycles = b2selectedmatch.NumCycles;
                    matchtoput.ScoutName = b2selectedmatch.ScoutName;
                    matchtoput.TeamNumber = b2selectedmatch.TeamNumber;
                    matchtoput.T_ControlPanelPosition = b2selectedmatch.T_ControlPanelPosition;
                    matchtoput.T_ControlPanelRotation = b2selectedmatch.T_ControlPanelRotation;
                    if (b2selectedmatch.PowerCellMissed != null)
                    {
                        matchtoput.APowerCellInner = b2selectedmatch.PowerCellInner[0];
                        matchtoput.APowerCellOuter = b2selectedmatch.PowerCellOuter[0];
                        matchtoput.APowerCellLower = b2selectedmatch.PowerCellLower[0];
                        matchtoput.APowerCellMissed = b2selectedmatch.PowerCellMissed[0];
                        foreach (var value in b2selectedmatch.PowerCellInner.Skip(1))
                        {
                            matchtoput.TPowerCellInner += value;
                        }
                        foreach (var value in b2selectedmatch.PowerCellOuter.Skip(1))
                        {
                            matchtoput.TPowerCellOuter += value;
                        }
                        foreach (var value in b2selectedmatch.PowerCellLower.Skip(1))
                        {
                            matchtoput.TPowerCellLower += value;
                        }
                        foreach (var value in b2selectedmatch.PowerCellMissed.Skip(1))
                        {
                            matchtoput.TPowerCellMissed += value;
                        }
                    }
                    MatchViewModel.Blue2CurrentMatch = matchtoput;
                }
                //BLUE3
                var b3selectedmatch = db.Matches.Where(x => x.TabletId == "B3" && x.EventCode == "test_env").FirstOrDefault();
                if (b3selectedmatch == null)
                {
                    MatchViewModel.Blue3CurrentMatch = new TeamMatchView();
                }
                else
                {
                    var matchtoput = new TeamMatchView();
                    
                    matchtoput.A_InitiationLine = b3selectedmatch.A_InitiationLine;
                    matchtoput.DisabledSeconds = b3selectedmatch.DisabledSeconds;
                    matchtoput.EventCode = b3selectedmatch.EventCode;
                    matchtoput.E_Balanced = b3selectedmatch.E_Balanced;
                    matchtoput.E_ClimbAttempt = b3selectedmatch.E_ClimbAttempt;
                    matchtoput.E_ClimbSuccess = b3selectedmatch.E_ClimbSuccess;
                    matchtoput.E_Park = b3selectedmatch.E_Park;
                    matchtoput.MatchNumber = b3selectedmatch.MatchNumber;
                    matchtoput.NumCycles = b3selectedmatch.NumCycles;
                    matchtoput.ScoutName = b3selectedmatch.ScoutName;
                    matchtoput.TeamNumber = b3selectedmatch.TeamNumber;
                    matchtoput.T_ControlPanelPosition = b3selectedmatch.T_ControlPanelPosition;
                    matchtoput.T_ControlPanelRotation = b3selectedmatch.T_ControlPanelRotation;
                    if(b3selectedmatch.PowerCellMissed != null)
                    {
                        matchtoput.APowerCellInner = b3selectedmatch.PowerCellInner[0];
                        matchtoput.APowerCellOuter = b3selectedmatch.PowerCellOuter[0];
                        matchtoput.APowerCellLower = b3selectedmatch.PowerCellLower[0];
                        matchtoput.APowerCellMissed = b3selectedmatch.PowerCellMissed[0];
                        foreach (var value in b3selectedmatch.PowerCellInner.Skip(1))
                        {
                            matchtoput.TPowerCellInner += value;
                        }
                        foreach (var value in b3selectedmatch.PowerCellOuter.Skip(1))
                        {
                            matchtoput.TPowerCellOuter += value;
                        }
                        foreach (var value in b3selectedmatch.PowerCellLower.Skip(1))
                        {
                            matchtoput.TPowerCellLower += value;
                        }
                        foreach (var value in b3selectedmatch.PowerCellMissed.Skip(1))
                        {
                            matchtoput.TPowerCellMissed += value;
                        }
                    }
                    
                    MatchViewModel.Blue3CurrentMatch = matchtoput;
                }
            }
            
        }
        public void SeeTablets()
        {
            matchViewModel.UserControlVisible = false;
            tabletViewModel.UserControlVisible = true;
            
        }
        public void NextMatch()
        {
            currentMatchNum++;
            MatchNumString = "Match " + currentMatchNum.ToString();
        }
        public void PrevMatch()
        {
            if(currentMatchNum > 1)
            {
                currentMatchNum--;
            }
            MatchNumString = "Match " + currentMatchNum.ToString();
        }
    }
}
