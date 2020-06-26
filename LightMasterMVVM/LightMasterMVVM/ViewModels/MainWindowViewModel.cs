using Avalonia.Media;
using GalaSoft.MvvmLight.Messaging;
using InTheHand.Net.Sockets;
using LightMasterMVVM.DbAssets;
using LightMasterMVVM.Models;
using LightMasterMVVM.Views;
using Newtonsoft.Json;
using Npgsql;
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
        private TeamMatch red1CurrentMatch = new TeamMatch();
        private TeamMatch red2CurrentMatch = new TeamMatch();
        private TeamMatch red3CurrentMatch = new TeamMatch();
        private TeamMatch blue1CurrentMatch = new TeamMatch();
        private TeamMatch blue2CurrentMatch = new TeamMatch();
        private TeamMatch blue3CurrentMatch = new TeamMatch();
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
        public TeamMatch Red1CurrentMatch
        {
            get => red1CurrentMatch;
            set => SetProperty(ref red1CurrentMatch, value);
        }
        public TeamMatch Red2CurrentMatch
        {
            get => red2CurrentMatch;
            set => SetProperty(ref red2CurrentMatch, value);
        }
        public TeamMatch Red3CurrentMatch
        {
            get => red3CurrentMatch;
            set => SetProperty(ref red3CurrentMatch, value);
        }
        public TeamMatch Blue1CurrentMatch
        {
            get => blue1CurrentMatch;
            set => SetProperty(ref blue1CurrentMatch, value);
        }
        public TeamMatch Blue2CurrentMatch
        {
            get => blue2CurrentMatch;
            set => SetProperty(ref blue2CurrentMatch, value);
        }
        public TeamMatch Blue3CurrentMatch
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
            get => matchViewModel;
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
