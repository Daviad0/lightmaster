﻿using Avalonia.Media;
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
                { 11, "Gray" },
                { 12, "Gray" },
                { 13, "Gray" },
                { 21, "Gray" },
                { 22, "Gray" },
                { 23, "Gray" },
            },
            new Dictionary<int, string>()
            {
                { 11, "Gray" },
                { 12, "Gray" },
                { 13, "Gray" },
                { 21, "Gray" },
                { 22, "Gray" },
                { 23, "Gray" },
            },
            new Dictionary<int, string>()
            {
                { 11, "Gray" },
                { 12, "Gray" },
                { 13, "Gray" },
                { 21, "Gray" },
                { 22, "Gray" },
                { 23, "Gray" },
            },
        };
        private Dictionary<int, string>[] statusBackgroundColors = {
            new Dictionary<int, string>()
            {
                { 11, "LightGray" },
                { 12, "LightGray" },
                { 13, "LightGray" },
                { 21, "LightGray" },
                { 22, "LightGray" },
                { 23, "LightGray" },
            },
            new Dictionary<int, string>()
            {
                { 11, "LightGray" },
                { 12, "LightGray" },
                { 13, "LightGray" },
                { 21, "LightGray" },
                { 22, "LightGray" },
                { 23, "LightGray" },
            },
            new Dictionary<int, string>()
            {
                { 11, "LightGray" },
                { 12, "LightGray" },
                { 13, "LightGray" },
                { 21, "LightGray" },
                { 22, "LightGray" },
                { 23, "LightGray" },
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

            var client = new WebsocketClient(url);
            client.ReconnectTimeout = null;
            /*client.ReconnectionHappened.Subscribe(info =>
                Log.Information($"Reconnection happened, type: {info.Type}"));*/

            client.MessageReceived.Subscribe(msg => {
                string rawdata = msg.Text;
                int tabletindex = 0;
                if (rawdata.StartsWith("R1"))
                {
                    tabletindex = 21;
                }
                if (rawdata.StartsWith("R2"))
                {
                    tabletindex = 22;
                }
                if (rawdata.StartsWith("R3"))
                {
                    tabletindex = 23;
                }
                if (rawdata.StartsWith("B1"))
                {
                    tabletindex = 11;
                }
                if (rawdata.StartsWith("B2"))
                {
                    tabletindex = 12;
                }
                if (rawdata.StartsWith("B3"))
                {
                    tabletindex = 13;
                }
                TabletViewModel.StatusBackgroundColors[0][tabletindex] = "LightBlue";
                TabletViewModel.StatusBorderColors[0][tabletindex] = "Blue";

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
    }
}
