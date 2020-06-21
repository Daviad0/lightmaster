using Avalonia.Media;
using GalaSoft.MvvmLight.Messaging;
using InTheHand.Net.Sockets;
using LightMasterMVVM.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using Websocket.Client;

namespace LightMasterMVVM.ViewModels
{
    public class TabletViewModel : ViewModelBase
    {
        private List<string> testBTD = new List<string>();
        private string _text = "Test";
        private Dictionary<int, string>[] statusBorderColors = { 
            new Dictionary<int, string>()
            {
                { 11, "Blue" },
                { 12, "Gray" },
                { 13, "Gray" },
                { 21, "Gray" },
                { 22, "Gray" },
                { 23, "Gray" },
            },
            new Dictionary<int, string>()
            {
                { 11, "Gray" },
                { 12, "Blue" },
                { 13, "Gray" },
                { 21, "Gray" },
                { 22, "Gray" },
                { 23, "Gray" },
            },
            new Dictionary<int, string>()
            {
                { 11, "Green" },
                { 12, "Green" },
                { 13, "Green" },
                { 21, "Green" },
                { 22, "DarkOrange" },
                { 23, "Red" },
            },
        };
        private Dictionary<int, string>[] statusBackgroundColors = {
            new Dictionary<int, string>()
            {
                { 11, "LightBlue" },
                { 12, "LightGray" },
                { 13, "LightGray" },
                { 21, "LightGray" },
                { 22, "LightGray" },
                { 23, "LightGray" },
            },
            new Dictionary<int, string>()
            {
                { 11, "LightGray" },
                { 12, "LightBlue" },
                { 13, "LightGray" },
                { 21, "LightGray" },
                { 22, "LightGray" },
                { 23, "LightGray" },
            },
            new Dictionary<int, string>()
            {
                { 11, "LightGreen" },
                { 12, "LightGreen" },
                { 13, "LightGreen" },
                { 21, "LightGreen" },
                { 22, "LightSalmon" },
                { 23, "LightPink" },
            },
        };
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
        public Dictionary<int, string>[] StatusBorderColors
        {
            get => statusBorderColors;
            set => SetProperty(ref statusBorderColors, value);
        }
        public Dictionary<int, string>[] StatusBackgroundColors
        {
            get => statusBackgroundColors;
            set => SetProperty(ref statusBackgroundColors, value);
        }

    }
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            
        }
        private TabletViewModel tabletViewModel = new TabletViewModel();
        private string _text = "Initial text";
        private bool userControlVisible = false;
        public TabletViewModel TabletViewModel
        {
            get => tabletViewModel;
            set => SetProperty(ref tabletViewModel, value);
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
        public void ChangeVisibility()
        {
            tabletViewModel.UserControlVisible = !tabletViewModel.UserControlVisible;
            var exitEvent = new ManualResetEvent(false);
            var url = new Uri("ws://localhost:8080");

            using (var client = new WebsocketClient(url))
            {
                client.ReconnectTimeout = TimeSpan.FromSeconds(30);
                /*client.ReconnectionHappened.Subscribe(info =>
                    Log.Information($"Reconnection happened, type: {info.Type}"));*/

                client.MessageReceived.Subscribe(msg => TabletViewModel.StatusBackgroundColors[0][12] = "Blue");
                client.Start();

                //Task.Run(() => client.Send("{ message }"));

                exitEvent.WaitOne();
            }
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
    }
}
