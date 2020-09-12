using InTheHand.Net.Sockets;
using LightMasterMVVM.DbAssets;
using LightMasterMVVM.Models;
using Newtonsoft.Json;
using Npgsql;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OxyPlot.Axes;
    using OxyPlot.Series;
using Websocket.Client;
using OxyPlot.Avalonia;
using LightMasterMVVM.Scripts;
using LightMasterMVVM.Views;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore.Internal;
using Avalonia.Threading;
using System.Runtime.CompilerServices;
using iMobileDevice.iDevice;
using iMobileDevice;
using iMobileDevice.Lockdown;
using System.IO.Ports;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using Avalonia.Controls.Primitives;
using System.Reflection;
using QRCoder;
using System.Drawing;
using Avalonia.Data.Converters;
using System.Globalization;
using Avalonia.Media.Imaging;
using Avalonia;
using Avalonia.Platform;

namespace LightMasterMVVM.ViewModels
{
    public class CreateGraphViewModel: ViewModelBase
    {
        public ObservableCollection<TrackedProperty> OrderedBy
        {
            get => orderedBy;
            set => SetProperty(ref orderedBy, value);
        }
        public ObservableCollection<TrackedProperty> TrackBy
        {
            get => trackBy;
            set => SetProperty(ref trackBy, value);
        }
        public ObservableCollection<TrackedProperty> AllOrderOptions
        {
            get => allOrderOptions;
            set => SetProperty(ref allOrderOptions, value);
        }
        public ObservableCollection<TrackedProperty> AllTrackOptions
        {
            get => allTrackOptions;
            set => SetProperty(ref allTrackOptions, value);
        }
        private ObservableCollection<TrackedProperty> orderedBy = new ObservableCollection<TrackedProperty>();
        private ObservableCollection<TrackedProperty> trackBy = new ObservableCollection<TrackedProperty>();
        private ObservableCollection<TrackedProperty> allOrderOptions = new ObservableCollection<TrackedProperty>()
        {
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Team Number", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Inner PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Outer PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Lower PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Missed PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "A Inner PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "A Outer PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "A Lower PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "A Missed PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "T Inner PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "T Outer PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "T Lower PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "T Missed PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Scored PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Shot PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Park Rate", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Climb Rate", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Balance Rate", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Disabled (s)", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Defense Rate", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "# of Cycles", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Cycle Time", Show = true, Ascending = true, Descending = false}

        };
        private ObservableCollection<TrackedProperty> allTrackOptions = new ObservableCollection<TrackedProperty>()
        {
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Inner PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Outer PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Lower PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Missed PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "A Inner PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "A Outer PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "A Lower PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "A Missed PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "T Inner PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "T Outer PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "T Lower PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "T Missed PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Scored PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Total Shot PC", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Park Rate", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Climb Rate", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Balance Rate", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Disabled (s)", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Defense Rate", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "# of Cycles", Show = true, Ascending = true, Descending = false},
            new TrackedProperty() { OrderNum = 0, OrderTypeProperty = "Cycle Time (s)", Show = true, Ascending = true, Descending = false}

        };
        public void SetOrderSortValue(string propertyName)
        {
            if(OrderedBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault().Ascending)
            {
                var itemtochange = OrderedBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault();
                OrderedBy.Remove(itemtochange);
                itemtochange.Descending = true;
                itemtochange.Ascending = false;
                OrderedBy.Add(itemtochange);
            }
            else
            {
                var itemtochange = OrderedBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault();
                OrderedBy.Remove(itemtochange);
                itemtochange.Descending = false;
                itemtochange.Ascending = true;
                OrderedBy.Add(itemtochange);
            }
            int i = 0;
            foreach (var fixordernum in OrderedBy.OrderBy(x => x.OrderNum))
            {
                fixordernum.OrderNum = i;
                i++;
            }

            OrderedBy = new ObservableCollection<TrackedProperty>(OrderedBy.OrderBy(x => x.OrderNum).ToList());

        }
        public void AddOrderProperty(string propertyName)
        {
            if(!OrderedBy.Any(x => x.OrderTypeProperty == propertyName))
            {
                OrderedBy.Add(new TrackedProperty() { OrderNum = OrderedBy.Count, OrderTypeProperty = propertyName, Show = true, Ascending = false, Descending = true });
                var oldAllItem = AllOrderOptions.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault();
                var newAllItem = oldAllItem;
                newAllItem.Show = false;
                AllOrderOptions[AllOrderOptions.IndexOf(oldAllItem)] = newAllItem;
                OrderedBy = new ObservableCollection<TrackedProperty>(OrderedBy.OrderBy(x => x.OrderNum).ToList());
            }
        }
        public void AddTrackProperty(string propertyName)
        {
            if (!TrackBy.Any(x => x.OrderTypeProperty == propertyName))
            {
                TrackBy.Add(new TrackedProperty() { OrderNum = TrackBy.Count, OrderTypeProperty = propertyName });
                var oldAllItem = AllTrackOptions.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault();
                var newAllItem = oldAllItem;
                newAllItem.Show = false;
                AllTrackOptions[AllTrackOptions.IndexOf(oldAllItem)] = newAllItem;
                TrackBy = new ObservableCollection<TrackedProperty>(TrackBy.OrderBy(x => x.OrderNum).ToList());
            }
        }
        public void RemoveOrderProperty(string propertyName)
        {
            var oldAllItem = AllOrderOptions.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault();
            var newAllItem = oldAllItem;
            newAllItem.Show = true;
            AllOrderOptions[AllOrderOptions.IndexOf(oldAllItem)] = newAllItem;
            OrderedBy.Remove(OrderedBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault());
            int i = 0;
            foreach(var fixordernum in OrderedBy.OrderBy(x => x.OrderNum))
            {
                fixordernum.OrderNum = i;
                i++;
            }
           
            OrderedBy = new ObservableCollection<TrackedProperty>(OrderedBy.OrderBy(x => x.OrderNum).ToList());
        }
        public void RemoveTrackProperty(string propertyName)
        {
            var oldAllItem = AllTrackOptions.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault();
            var newAllItem = oldAllItem;
            newAllItem.Show = true;
            AllTrackOptions[AllTrackOptions.IndexOf(oldAllItem)] = newAllItem;
            TrackBy.Remove(TrackBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault());
            int i = 0;
            foreach (var fixordernum in TrackBy.OrderBy(x => x.OrderNum))
            {
                fixordernum.OrderNum = i;
                i++;
            }
            
            TrackBy = new ObservableCollection<TrackedProperty>(TrackBy.OrderBy(x => x.OrderNum).ToList());
        }
        public void ChangeOrderOfOrderPropertyUp(string propertyName)
        {
            try
            {
                OrderedBy.OrderBy(x => x.OrderNum).ToArray()[OrderedBy.IndexOf(OrderedBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault()) - 1].OrderNum = OrderedBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault().OrderNum;
                var itemtochange = OrderedBy.FirstOrDefault(x => x.OrderTypeProperty == propertyName);
                itemtochange.OrderNum -= 1;
                OrderedBy = new ObservableCollection<TrackedProperty>(OrderedBy.OrderBy(x => x.OrderNum).ToList());
            }
            catch(Exception ex)
            {

            }

        }
        public void ChangeOrderOfOrderPropertyDown(string propertyName)
        {
            try
            {
                OrderedBy.OrderBy(x => x.OrderNum).ToArray()[OrderedBy.IndexOf(OrderedBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault()) + 1].OrderNum = OrderedBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault().OrderNum;
                var itemtochange = OrderedBy.FirstOrDefault(x => x.OrderTypeProperty == propertyName);
                itemtochange.OrderNum += 1;
                OrderedBy = new ObservableCollection<TrackedProperty>(OrderedBy.OrderBy(x => x.OrderNum).ToList());
            }
            catch (Exception ex)
            {

            }
        }
        public void ChangeOrderOfTrackPropertyUp(string propertyName)
        {
            try
            {
                TrackBy.OrderBy(x => x.OrderNum).ToArray()[TrackBy.IndexOf(TrackBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault()) - 1].OrderNum = TrackBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault().OrderNum;
                var itemtochange = TrackBy.FirstOrDefault(x => x.OrderTypeProperty == propertyName);
                itemtochange.OrderNum -= 1;
                TrackBy = new ObservableCollection<TrackedProperty>(TrackBy.OrderBy(x => x.OrderNum).ToList());
            }
            catch (Exception ex)
            {

            }
        }
        public void ChangeOrderOfTrackPropertyDown(string propertyName)
        {
            try
            {
                TrackBy.OrderBy(x => x.OrderNum).ToArray()[TrackBy.IndexOf(TrackBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault()) + 1].OrderNum = TrackBy.Where(x => x.OrderTypeProperty == propertyName).FirstOrDefault().OrderNum;
                var itemtochange = TrackBy.FirstOrDefault(x => x.OrderTypeProperty == propertyName);
                itemtochange.OrderNum += 1;
                TrackBy = new ObservableCollection<TrackedProperty>(TrackBy.OrderBy(x => x.OrderNum).ToList());
            }
            catch (Exception ex)
            {

            }
        }
        public void CreateGraph()
        {
            //INJECT MODEL INSTEAD OF STRINGS TO DO ASCENDING AND DESCENDING
            NavMessenger.OnCreateNewGraph(trackBy.ToArray(), orderedBy.ToArray());
        }
    }
    public class MatchDetailsViewModel: ViewModelBase
    {
        public void Back()
        {
            NavMessenger.OnFromMatchDetails(fromPage);
        }
        public OriginalPage fromPage;
        private int matchNum = 0;
        public int MatchNum
        {
            get => matchNum;
            set => SetProperty(ref matchNum, value);
        }
        private TeamMatchView red1Match = new TeamMatchView();
        private TeamMatchView red2Match = new TeamMatchView();
        private TeamMatchView red3Match = new TeamMatchView();
        private TeamMatchView blue1Match = new TeamMatchView();
        private TeamMatchView blue2Match = new TeamMatchView();
        private TeamMatchView blue3Match = new TeamMatchView();
        private bool red1NC = true;
        private bool red2NC = true;
        private bool red3NC = true;
        private bool blue1NC = true;
        private bool blue2NC = true;
        private bool blue3NC = true;
        private bool red1C = false;
        private bool red2C = false;
        private bool red3C = false;
        private bool blue1C = false;
        private bool blue2C = false;
        private bool blue3C = false;
        public bool Red1NC
        {
            get => red1NC;
            set => SetProperty(ref red1NC, value);
        }
        public bool Red2NC
        {
            get => red2NC;
            set => SetProperty(ref red2NC, value);
        }
        public bool Red3NC
        {
            get => red3NC;
            set => SetProperty(ref red3NC, value);
        }
        public bool Blue1NC
        {
            get => blue1NC;
            set => SetProperty(ref blue1NC, value);
        }
        public bool Blue2NC
        {
            get => blue2NC;
            set => SetProperty(ref blue2NC, value);
        }
        public bool Blue3NC
        {
            get => blue3NC;
            set => SetProperty(ref blue3NC, value);
        }
        public bool Red1C
        {
            get => red1C;
            set => SetProperty(ref red1C, value);
        }
        public bool Red2C
        {
            get => red2C;
            set => SetProperty(ref red2C, value);
        }
        public bool Red3C
        {
            get => red3C;
            set => SetProperty(ref red3C, value);
        }
        public bool Blue1C
        {
            get => blue1C;
            set => SetProperty(ref blue1C, value);
        }
        public bool Blue2C
        {
            get => blue2C;
            set => SetProperty(ref blue2C, value);
        }
        public bool Blue3C
        {
            get => blue3C;
            set => SetProperty(ref blue3C, value);
        }
        public TeamMatchView Red1Match
        {
            get => red1Match;
            set => SetProperty(ref red1Match, value);
        }
        public TeamMatchView Red2Match
        {
            get => red2Match;
            set => SetProperty(ref red2Match, value);
        }
        public TeamMatchView Red3Match
        {
            get => red3Match;
            set => SetProperty(ref red3Match, value);
        }
        public TeamMatchView Blue1Match
        {
            get => blue1Match;
            set => SetProperty(ref blue1Match, value);
        }
        public TeamMatchView Blue2Match
        {
            get => blue2Match;
            set => SetProperty(ref blue2Match, value);
        }
        public TeamMatchView Blue3Match
        {
            get => blue3Match;
            set => SetProperty(ref blue3Match, value);
        }
        public MatchDetailsViewModel(int matchnum, OriginalPage calledPage)
        {
            try
            {
                fromPage = calledPage;
                var testmatch = matchnum;
                GetEventCode getCode = new GetEventCode();
                using (var db = new ScoutingContext())
                {
                    var red1match = db.Matches.Where(x => x.TabletId == "R1" && x.EventCode == getCode.EventCode() && x.MatchNumber == testmatch).FirstOrDefault();
                    var red2match = db.Matches.Where(x => x.TabletId == "R2" && x.EventCode == getCode.EventCode() && x.MatchNumber == testmatch).FirstOrDefault();
                    var red3match = db.Matches.Where(x => x.TabletId == "R3" && x.EventCode == getCode.EventCode() && x.MatchNumber == testmatch).FirstOrDefault();
                    var blue1match = db.Matches.Where(x => x.TabletId == "B1" && x.EventCode == getCode.EventCode() && x.MatchNumber == testmatch).FirstOrDefault();
                    var blue2match = db.Matches.Where(x => x.TabletId == "B2" && x.EventCode == getCode.EventCode() && x.MatchNumber == testmatch).FirstOrDefault();
                    var blue3match = db.Matches.Where(x => x.TabletId == "B3" && x.EventCode == getCode.EventCode() && x.MatchNumber == testmatch).FirstOrDefault();
                    if (red1match == null)
                    {
                        Red1C = false;
                        Red1NC = true;
                    }
                    else if (red1match.ClientSubmitted == false)
                    {
                        Red1C = false;
                        Red1NC = true;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = red1match.PowerCellInner[0], APowerCellOuter = red1match.PowerCellOuter[0], APowerCellLower = red1match.PowerCellLower[0], APowerCellMissed = red1match.PowerCellMissed[0], E_Park = red1match.E_Park, E_Balanced = red1match.E_Balanced, E_ClimbSuccess = red1match.E_ClimbSuccess, DisabledSeconds = red1match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(red1match.team_instance_id).team_number };
                        Red1Match = replacementTMV;
                    }
                    else
                    {
                        Red1C = true;
                        Red1NC = false;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = red1match.PowerCellInner[0], APowerCellOuter = red1match.PowerCellOuter[0], APowerCellLower = red1match.PowerCellLower[0], APowerCellMissed = red1match.PowerCellMissed[0], E_Park = red1match.E_Park, E_Balanced = red1match.E_Balanced, E_ClimbSuccess = red1match.E_ClimbSuccess, DisabledSeconds = red1match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(red1match.team_instance_id).team_number };
                        replacementTMV.AShotAccuracy = (int)Math.Round(((double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter) / (double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter + replacementTMV.APowerCellMissed)) * 100);
                        replacementTMV.TPowerCellInner = red1match.PowerCellInner.Sum() - replacementTMV.APowerCellInner;
                        replacementTMV.TPowerCellOuter = red1match.PowerCellOuter.Sum() - replacementTMV.APowerCellOuter;
                        replacementTMV.TPowerCellLower = red1match.PowerCellLower.Sum() - replacementTMV.APowerCellLower;
                        replacementTMV.TPowerCellMissed = red1match.PowerCellMissed.Sum() - replacementTMV.APowerCellMissed;
                        replacementTMV.CycleTime = red1match.CycleTime;
                        replacementTMV.NumCycles = red1match.NumCycles;
                        replacementTMV.TShotAccuracy = (int)Math.Round(((double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter) / (double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellMissed)) * 100);
                        if ((replacementTMV.APowerCellInner + replacementTMV.APowerCellOuter + replacementTMV.APowerCellLower + replacementTMV.APowerCellMissed) <= 0)
                        {
                            replacementTMV.AShotAccuracy = 0;
                        }
                        if ((replacementTMV.TPowerCellInner + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellMissed) <= 0)
                        {
                            replacementTMV.TShotAccuracy = 0;
                        }
                        Red1Match = replacementTMV;
                    }

                    if (red2match == null)
                    {
                        Red2C = false;
                        Red2NC = true;
                    }
                    else if (red2match.ClientSubmitted == false)
                    {
                        Red2C = false;
                        Red2NC = true;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = red2match.PowerCellInner[0], APowerCellOuter = red2match.PowerCellOuter[0], APowerCellLower = red2match.PowerCellLower[0], APowerCellMissed = red2match.PowerCellMissed[0], E_Park = red2match.E_Park, E_Balanced = red2match.E_Balanced, E_ClimbSuccess = red2match.E_ClimbSuccess, DisabledSeconds = red2match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(red2match.team_instance_id).team_number };
                        Red2Match = replacementTMV;
                    }
                    else
                    {
                        Red2C = true;
                        Red2NC = false;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = red2match.PowerCellInner[0], APowerCellOuter = red2match.PowerCellOuter[0], APowerCellLower = red2match.PowerCellLower[0], APowerCellMissed = red2match.PowerCellMissed[0], E_Park = red2match.E_Park, E_Balanced = red2match.E_Balanced, E_ClimbSuccess = red2match.E_ClimbSuccess, DisabledSeconds = red2match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(red2match.team_instance_id).team_number };
                        replacementTMV.AShotAccuracy = (int)Math.Round(((double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter) / (double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter + replacementTMV.APowerCellMissed)) * 100);
                        replacementTMV.TPowerCellInner = red2match.PowerCellInner.Sum() - replacementTMV.APowerCellInner;
                        replacementTMV.TPowerCellOuter = red2match.PowerCellOuter.Sum() - replacementTMV.APowerCellOuter;
                        replacementTMV.TPowerCellLower = red2match.PowerCellLower.Sum() - replacementTMV.APowerCellLower;
                        replacementTMV.TPowerCellMissed = red2match.PowerCellMissed.Sum() - replacementTMV.APowerCellMissed;
                        replacementTMV.CycleTime = red2match.CycleTime;
                        replacementTMV.NumCycles = red2match.NumCycles;
                        replacementTMV.TShotAccuracy = (int)Math.Round(((double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter) / (double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellMissed)) * 100);
                        if ((replacementTMV.APowerCellInner + replacementTMV.APowerCellOuter + replacementTMV.APowerCellLower + replacementTMV.APowerCellMissed) <= 0)
                        {
                            replacementTMV.AShotAccuracy = 0;
                        }
                        if ((replacementTMV.TPowerCellInner + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellMissed) <= 0)
                        {
                            replacementTMV.TShotAccuracy = 0;
                        }
                        Red2Match = replacementTMV;
                    }

                    if (red3match == null)
                    {
                        Red3C = false;
                        Red3NC = true;
                    }
                    else if (red3match.ClientSubmitted == false)
                    {
                        Red3C = false;
                        Red3NC = true;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = red3match.PowerCellInner[0], APowerCellOuter = red3match.PowerCellOuter[0], APowerCellLower = red3match.PowerCellLower[0], APowerCellMissed = red3match.PowerCellMissed[0], E_Park = red3match.E_Park, E_Balanced = red3match.E_Balanced, E_ClimbSuccess = red3match.E_ClimbSuccess, DisabledSeconds = red3match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(red3match.team_instance_id).team_number };
                        Red3Match = replacementTMV;
                    }
                    else
                    {
                        Red3C = true;
                        Red3NC = false;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = red3match.PowerCellInner[0], APowerCellOuter = red3match.PowerCellOuter[0], APowerCellLower = red3match.PowerCellLower[0], APowerCellMissed = red3match.PowerCellMissed[0], E_Park = red3match.E_Park, E_Balanced = red3match.E_Balanced, E_ClimbSuccess = red3match.E_ClimbSuccess, DisabledSeconds = red3match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(red3match.team_instance_id).team_number };
                        replacementTMV.AShotAccuracy = (int)Math.Round(((double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter) / (double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter + replacementTMV.APowerCellMissed)) * 100);
                        replacementTMV.TPowerCellInner = red3match.PowerCellInner.Sum() - replacementTMV.APowerCellInner;
                        replacementTMV.TPowerCellOuter = red3match.PowerCellOuter.Sum() - replacementTMV.APowerCellOuter;
                        replacementTMV.TPowerCellLower = red3match.PowerCellLower.Sum() - replacementTMV.APowerCellLower;
                        replacementTMV.TPowerCellMissed = red3match.PowerCellMissed.Sum() - replacementTMV.APowerCellMissed;
                        replacementTMV.CycleTime = red3match.CycleTime;
                        replacementTMV.NumCycles = red3match.NumCycles;
                        replacementTMV.TShotAccuracy = (int)Math.Round(((double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter) / (double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellMissed)) * 100);
                        if ((replacementTMV.APowerCellInner + replacementTMV.APowerCellOuter + replacementTMV.APowerCellLower + replacementTMV.APowerCellMissed) <= 0)
                        {
                            replacementTMV.AShotAccuracy = 0;
                        }
                        if ((replacementTMV.TPowerCellInner + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellMissed) <= 0)
                        {
                            replacementTMV.TShotAccuracy = 0;
                        }
                        Red3Match = replacementTMV;
                    }

                    if (blue1match == null)
                    {
                        Blue1C = false;
                        Blue1NC = true;
                    }
                    else if (blue1match.ClientSubmitted == false)
                    {
                        Blue1C = false;
                        Blue1NC = true;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = blue1match.PowerCellInner[0], APowerCellOuter = blue1match.PowerCellOuter[0], APowerCellLower = blue1match.PowerCellLower[0], APowerCellMissed = blue1match.PowerCellMissed[0], E_Park = blue1match.E_Park, E_Balanced = blue1match.E_Balanced, E_ClimbSuccess = blue1match.E_ClimbSuccess, DisabledSeconds = blue1match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(blue1match.team_instance_id).team_number };
                        Blue1Match = replacementTMV;
                    }
                    else
                    {
                        Blue1C = true;
                        Blue1NC = false;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = blue1match.PowerCellInner[0], APowerCellOuter = blue1match.PowerCellOuter[0], APowerCellLower = blue1match.PowerCellLower[0], APowerCellMissed = blue1match.PowerCellMissed[0], E_Park = blue1match.E_Park, E_Balanced = blue1match.E_Balanced, E_ClimbSuccess = blue1match.E_ClimbSuccess, DisabledSeconds = blue1match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(blue1match.team_instance_id).team_number };
                        replacementTMV.AShotAccuracy = (int)Math.Round(((double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter) / (double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter + replacementTMV.APowerCellMissed)) * 100);
                        replacementTMV.TPowerCellInner = blue1match.PowerCellInner.Sum() - replacementTMV.APowerCellInner;
                        replacementTMV.TPowerCellOuter = blue1match.PowerCellOuter.Sum() - replacementTMV.APowerCellOuter;
                        replacementTMV.TPowerCellLower = blue1match.PowerCellLower.Sum() - replacementTMV.APowerCellLower;
                        replacementTMV.TPowerCellMissed = blue1match.PowerCellMissed.Sum() - replacementTMV.APowerCellMissed;
                        replacementTMV.CycleTime = blue1match.CycleTime;
                        replacementTMV.NumCycles = blue1match.NumCycles;
                        replacementTMV.TShotAccuracy = (int)Math.Round(((double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter) / (double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellMissed)) * 100);
                        if ((replacementTMV.APowerCellInner + replacementTMV.APowerCellOuter + replacementTMV.APowerCellLower + replacementTMV.APowerCellMissed) <= 0)
                        {
                            replacementTMV.AShotAccuracy = 0;
                        }
                        if ((replacementTMV.TPowerCellInner + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellMissed) <= 0)
                        {
                            replacementTMV.TShotAccuracy = 0;
                        }
                        Blue1Match = replacementTMV;
                    }

                    if (blue2match == null)
                    {
                        Blue2C = false;
                        Blue2NC = true;
                    }
                    else if (blue2match.ClientSubmitted == false)
                    {
                        Blue2C = false;
                        Blue2NC = true;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = blue2match.PowerCellInner[0], APowerCellOuter = blue2match.PowerCellOuter[0], APowerCellLower = blue2match.PowerCellLower[0], APowerCellMissed = blue2match.PowerCellMissed[0], E_Park = blue2match.E_Park, E_Balanced = blue2match.E_Balanced, E_ClimbSuccess = blue2match.E_ClimbSuccess, DisabledSeconds = blue2match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(blue2match.team_instance_id).team_number };
                        Blue2Match = replacementTMV;
                    }
                    else
                    {
                        Blue2C = true;
                        Blue2NC = false;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = blue2match.PowerCellInner[0], APowerCellOuter = blue2match.PowerCellOuter[0], APowerCellLower = blue2match.PowerCellLower[0], APowerCellMissed = blue2match.PowerCellMissed[0], E_Park = blue2match.E_Park, E_Balanced = blue2match.E_Balanced, E_ClimbSuccess = blue2match.E_ClimbSuccess, DisabledSeconds = blue2match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(blue2match.team_instance_id).team_number };
                        replacementTMV.AShotAccuracy = (int)Math.Round(((double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter) / (double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter + replacementTMV.APowerCellMissed)) * 100);
                        replacementTMV.TPowerCellInner = blue2match.PowerCellInner.Sum() - replacementTMV.APowerCellInner;
                        replacementTMV.TPowerCellOuter = blue2match.PowerCellOuter.Sum() - replacementTMV.APowerCellOuter;
                        replacementTMV.TPowerCellLower = blue2match.PowerCellLower.Sum() - replacementTMV.APowerCellLower;
                        replacementTMV.TPowerCellMissed = blue2match.PowerCellMissed.Sum() - replacementTMV.APowerCellMissed;
                        replacementTMV.CycleTime = blue2match.CycleTime;
                        replacementTMV.NumCycles = blue2match.NumCycles;
                        replacementTMV.TShotAccuracy = (int)Math.Round(((double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter) / (double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellMissed)) * 100);
                        if ((replacementTMV.APowerCellInner + replacementTMV.APowerCellOuter + replacementTMV.APowerCellLower + replacementTMV.APowerCellMissed) <= 0)
                        {
                            replacementTMV.AShotAccuracy = 0;
                        }
                        if ((replacementTMV.TPowerCellInner + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellMissed) <= 0)
                        {
                            replacementTMV.TShotAccuracy = 0;
                        }
                        Blue2Match = replacementTMV;
                    }

                    if (blue3match == null)
                    {
                        Blue3C = false;
                        Blue3NC = true;
                    }
                    else if (blue3match.ClientSubmitted == false)
                    {
                        Blue3C = false;
                        Blue3NC = true;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = blue3match.PowerCellInner[0], APowerCellOuter = blue3match.PowerCellOuter[0], APowerCellLower = blue3match.PowerCellLower[0], APowerCellMissed = blue3match.PowerCellMissed[0], E_Park = blue3match.E_Park, E_Balanced = blue3match.E_Balanced, E_ClimbSuccess = blue3match.E_ClimbSuccess, DisabledSeconds = blue3match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(blue3match.team_instance_id).team_number };
                        Blue3Match = replacementTMV;
                    }
                    else
                    {
                        Blue3C = true;
                        Blue3NC = false;
                        var replacementTMV = new TeamMatchView() { APowerCellInner = blue3match.PowerCellInner[0], APowerCellOuter = blue3match.PowerCellOuter[0], APowerCellLower = blue3match.PowerCellLower[0], APowerCellMissed = blue3match.PowerCellMissed[0], E_Park = blue3match.E_Park, E_Balanced = blue3match.E_Balanced, E_ClimbSuccess = blue3match.E_ClimbSuccess, DisabledSeconds = blue3match.DisabledSeconds, TeamNumber = db.FRCTeams.Find(blue3match.team_instance_id).team_number };
                        replacementTMV.AShotAccuracy = (int)Math.Round(((double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter) / (double)(replacementTMV.APowerCellInner + replacementTMV.APowerCellLower + replacementTMV.APowerCellOuter + replacementTMV.APowerCellMissed)) * 100);
                        replacementTMV.TPowerCellInner = blue3match.PowerCellInner.Sum() - replacementTMV.APowerCellInner;
                        replacementTMV.TPowerCellOuter = blue3match.PowerCellOuter.Sum() - replacementTMV.APowerCellOuter;
                        replacementTMV.TPowerCellLower = blue3match.PowerCellLower.Sum() - replacementTMV.APowerCellLower;
                        replacementTMV.TPowerCellMissed = blue3match.PowerCellMissed.Sum() - replacementTMV.APowerCellMissed;
                        replacementTMV.CycleTime = blue3match.CycleTime;
                        replacementTMV.NumCycles = blue3match.NumCycles;
                        replacementTMV.TShotAccuracy = (int)Math.Round(((double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter) / (double)(replacementTMV.TPowerCellInner + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellMissed)) * 100);
                        if ((replacementTMV.APowerCellInner + replacementTMV.APowerCellOuter + replacementTMV.APowerCellLower + replacementTMV.APowerCellMissed) <= 0)
                        {
                            replacementTMV.AShotAccuracy = 0;
                        }
                        if ((replacementTMV.TPowerCellInner + replacementTMV.TPowerCellOuter + replacementTMV.TPowerCellLower + replacementTMV.TPowerCellMissed) <= 0)
                        {
                            replacementTMV.TShotAccuracy = 0;
                        }
                        Blue3Match = replacementTMV;
                    }
                }
            }catch(Exception ex)
            {

            }
            
        }
    }
    public class TeamDetailsViewModel: ViewModelBase
    {
        public OriginalPage fromPage;
        private CompTeamView teamModel = new CompTeamView();
        public void Back()
        {
            NavMessenger.OnFromTeamDetails(fromPage);
        }
        public CompTeamView TeamModel
        {
            get => teamModel;
            set => SetProperty(ref teamModel, value);
        }
        public void ShowMatch(int matchnum)
        {
            NavMessenger.OnShowMatchDetails(matchnum, fromPage);
        }
        public TeamDetailsViewModel(int team_instance_id, OriginalPage calledPage)
        {
            fromPage = calledPage;
            try
            {
                using (var db = new ScoutingContext())
                {
                    var dbteamtest = db.FRCTeams.Find(team_instance_id);
                    CompTeamView compTeamView = new CompTeamView() { team_number = dbteamtest.team_number, rated_tier = dbteamtest.rated_tier };
                    var listofmatchesunderteam = db.Matches.Where(x => x.team_instance_id == dbteamtest.team_instance_id && x.EventCode == dbteamtest.event_key).ToList();
                    var listofcompletedmatches = new List<TeamMatchView>();
                    var listofincompletematches = new List<TeamMatchView>();
                    var listofviewablematches = new ObservableCollection<TeamMatchView>();
                    bool hasmatches = false;
                    int[] allcycletimes = new int[listofmatchesunderteam.Count];
                    int lastshotpccount = 0;
                    int i = 0;
                    int cm = 0;
                    double totalimprovementrating = 0;
                    foreach (var match in listofmatchesunderteam.OrderBy(x => x.MatchNumber))
                    {
                        var matchview = new TeamMatchView();
                        int shotpccount = 0;
                        matchview.A_InitiationLine = match.A_InitiationLine;
                        matchview.DisabledSeconds = match.DisabledSeconds;
                        matchview.EventCode = match.EventCode;
                        matchview.E_Balanced = match.E_Balanced;
                        matchview.E_ClimbAttempt = match.E_ClimbAttempt;
                        matchview.E_ClimbSuccess = match.E_ClimbSuccess;
                        matchview.E_Park = match.E_Park;
                        matchview.MatchNumber = match.MatchNumber;
                        matchview.NumCycles = match.NumCycles;
                        matchview.ScoutName = match.ScoutName;
                        matchview.TeamNumber = dbteamtest.team_number;
                        matchview.T_ControlPanelPosition = match.T_ControlPanelPosition;
                        matchview.T_ControlPanelRotation = match.T_ControlPanelRotation;
                        if (match.AlliancePartners.Length > 1)
                        {
                            try
                            {
                                matchview.PartnersWith = db.FRCTeams.Find(match.AlliancePartners[0]).team_number + ", " + db.FRCTeams.Find(match.AlliancePartners[1]).team_number;
                            }
                            catch (Exception ex)
                            {
                                matchview.PartnersWith = match.AlliancePartners[0] + ", " + match.AlliancePartners[1];
                            }

                        }
                        else
                        {
                            matchview.PartnersWith = "No One?";
                        }

                        matchview.APowerCellInner = match.PowerCellInner[0];
                        matchview.APowerCellOuter = match.PowerCellOuter[0];
                        matchview.APowerCellLower = match.PowerCellLower[0];
                        matchview.APowerCellMissed = match.PowerCellMissed[0];
                        compTeamView.a_pc_inner_avg += match.PowerCellInner[0];
                        compTeamView.a_pc_outer_avg += match.PowerCellOuter[0];
                        compTeamView.a_pc_lower_avg += match.PowerCellLower[0];
                        compTeamView.a_pc_missed_avg += match.PowerCellMissed[0];
                        shotpccount += match.PowerCellInner[0];
                        shotpccount += match.PowerCellOuter[0];
                        shotpccount += match.PowerCellLower[0];
                        shotpccount += match.PowerCellMissed[0];
                        compTeamView.t_num_cycles += match.NumCycles;
                        allcycletimes[i] = match.CycleTime;
                        foreach (var pca in match.PowerCellInner.Skip(1))
                        {
                            compTeamView.t_pc_inner_avg += pca;
                            matchview.TPowerCellInner += pca;
                            shotpccount += pca;
                        }
                        foreach (var pca in match.PowerCellOuter.Skip(1))
                        {
                            compTeamView.t_pc_outer_avg += pca;
                            matchview.TPowerCellOuter += pca;
                            shotpccount += pca;
                        }
                        foreach (var pca in match.PowerCellLower.Skip(1))
                        {
                            compTeamView.t_pc_lower_avg += pca;
                            matchview.TPowerCellLower += pca;
                            shotpccount += pca;
                        }
                        foreach (var pca in match.PowerCellMissed.Skip(1))
                        {
                            compTeamView.t_pc_missed_avg += pca;
                            matchview.TPowerCellMissed += pca;
                            shotpccount += pca;
                        }
                        if (match.ClientSubmitted)
                        {
                            if (cm == 0)
                            {
                                totalimprovementrating += 1;
                                matchview.ImprovementShotPC = "+100%";
                            }
                            else
                            {
                                try
                                {
                                    var improvementrating = (double)((double)shotpccount / (double)lastshotpccount);
                                    if (improvementrating < 1)
                                    {
                                        totalimprovementrating += improvementrating;
                                        matchview.ImprovementShotPC = "-" + (Math.Round(improvementrating * 100)).ToString() + "%";
                                    }
                                    else if (improvementrating > 1)
                                    {
                                        totalimprovementrating += improvementrating;
                                        matchview.ImprovementShotPC = "+" + (Math.Round((improvementrating - 1) * 100)).ToString() + "%";
                                    }
                                    else
                                    {
                                        totalimprovementrating += improvementrating;
                                        matchview.ImprovementShotPC = "+0%";
                                    }
                                    //matchview.ImprovementShotPC = Math.Round((double)(shotpccount / lastshotpccount) * 100).ToString() + "";
                                }
                                catch (Exception ex)
                                {
                                    totalimprovementrating += 1;
                                    matchview.ImprovementShotPC = "---";
                                }
                            }
                            lastshotpccount = shotpccount;
                        }
                        else
                        {
                            matchview.ImprovementShotPC = "---";
                        }

                        if (match.ClientSubmitted)
                        {
                            listofcompletedmatches.Add(matchview);
                            cm++;
                        }
                        else
                        {
                            listofincompletematches.Add(matchview);
                        }
                        listofviewablematches.Add(matchview);
                        hasmatches = true;
                        i++;

                    }
                    if (hasmatches)
                    {
                        if(listofcompletedmatches.Count > 0)
                        {
                            compTeamView.avg_cycle_time = allcycletimes.Min().ToString() + "s to " + allcycletimes.Max().ToString() + "s";
                            compTeamView.a_pc_inner_avg = compTeamView.a_pc_inner_avg / (listofcompletedmatches.ToArray().Length);
                            compTeamView.a_pc_lower_avg = compTeamView.a_pc_lower_avg / (listofcompletedmatches.ToArray().Length);
                            compTeamView.a_pc_missed_avg = compTeamView.a_pc_missed_avg / (listofcompletedmatches.ToArray().Length);
                            compTeamView.a_pc_outer_avg = compTeamView.a_pc_outer_avg / (listofcompletedmatches.ToArray().Length);
                            compTeamView.t_pc_inner_avg = compTeamView.t_pc_inner_avg / (listofcompletedmatches.ToArray().Length);
                            compTeamView.t_pc_lower_avg = compTeamView.t_pc_lower_avg / (listofcompletedmatches.ToArray().Length);
                            compTeamView.t_pc_missed_avg = compTeamView.t_pc_missed_avg / (listofcompletedmatches.ToArray().Length);
                            compTeamView.t_pc_outer_avg = compTeamView.t_pc_outer_avg / (listofcompletedmatches.ToArray().Length);
                            compTeamView.t_num_cycles = compTeamView.t_num_cycles / (listofcompletedmatches.ToArray().Length);
                            compTeamView.improvement_rating = Math.Round(totalimprovementrating / listofcompletedmatches.Count, 2);
                            compTeamView.progress_width = (int)Math.Round(((double)listofcompletedmatches.Count / (double)(listofcompletedmatches.Count + listofincompletematches.Count)) * 694);
                        }
                        else
                        {
                            compTeamView.avg_cycle_time = "None Completed";
                        }
                        
                    }
                    else
                    {
                        compTeamView.improvement_rating = 0;
                        compTeamView.avg_cycle_time = "---";
                        compTeamView.progress_width = 0;
                    }

                    compTeamView.has_matches = hasmatches;
                    compTeamView.team_matches = listofviewablematches;
                    compTeamView.match_progress = (listofcompletedmatches.ToArray().Length.ToString() + " of " + (listofincompletematches.ToArray().Length + listofcompletedmatches.ToArray().Length).ToString());
                    TeamModel = compTeamView;
                }
            }catch(Exception ex)
            {

            }
            
            
        }
    }
    public class CompetitionTeamsViewModel : ViewModelBase
    {
        public void ShowTeam(int team_instance_id)
        {
            NavMessenger.OnShowTeamDetails(team_instance_id, OriginalPage.TeamList);
        }
        private bool userControlVisible = true;
        public bool UserControlVisible
        {
            get => userControlVisible;
            set => SetProperty(ref userControlVisible, value);
        }
        private ObservableCollection<CompTeamView> teams = new ObservableCollection<CompTeamView>();
        public ObservableCollection<CompTeamView> Teams
        {
            get => teams;
            set => SetProperty(ref teams, value);
        }
        public CompetitionTeamsViewModel()
        {
            try
            {
                Teams.Clear();
                using (var db = new ScoutingContext())
                {
                    var listofteams = db.FRCTeams.Where(x => x.event_key == new GetEventCode().EventCode()).ToList();
                    foreach(var dbteamtest in listofteams.OrderBy(x => x.team_number))
                    {
                        CompTeamView compTeamView = new CompTeamView() { team_number = dbteamtest.team_number, rated_tier = dbteamtest.rated_tier };
                        var listofmatchesunderteam = db.Matches.Where(x => x.team_instance_id == dbteamtest.team_instance_id && x.EventCode == dbteamtest.event_key).ToList();
                        var listofcompletedmatches = new List<TeamMatchView>();
                        var listofincompletematches = new List<TeamMatchView>();
                        var listofviewablematches = new ObservableCollection<TeamMatchView>();
                        bool hasmatches = false;
                        int[] allcycletimes = new int[listofmatchesunderteam.Count];
                        int lastshotpccount = 0;
                        int i = 0;
                        int cm = 0;
                        double totalimprovementrating = 0;
                        foreach (var match in listofmatchesunderteam.OrderBy(x => x.MatchNumber))
                        {
                            var matchview = new TeamMatchView();
                            
                            if (match.ClientSubmitted)
                            {
                                listofcompletedmatches.Add(matchview);
                                cm++;
                            }
                            else
                            {
                                listofincompletematches.Add(matchview);
                            }
                            listofviewablematches.Add(matchview);
                            hasmatches = true;
                            i++;

                        }
                        

                        compTeamView.has_matches = hasmatches;
                        compTeamView.team_matches = listofviewablematches;
                        compTeamView.team_instance_id = dbteamtest.team_instance_id;
                        compTeamView.match_progress = (listofcompletedmatches.ToArray().Length.ToString() + " of " + (listofincompletematches.ToArray().Length + listofcompletedmatches.ToArray().Length).ToString());
                        Teams.Add(compTeamView);
                    }
                    
                }
            }catch(Exception ex)
            {

            }
            
        }
    }
    public class NotificationViewModel : ViewModelBase
    {
        private ObservableCollection<NotificationItem> notifications = new ObservableCollection<NotificationItem>()
        {
            new NotificationItem(){ BackgroundColor = "#2a7afa", NotificationText = "Welcome 862 Scouter", NotificationTitle = "Auto Login", NotificationId = 1, NotificationActive = true, timeAdded = DateTime.Now },
            
        };
        public ObservableCollection<NotificationItem> Notifications
        {
            get => notifications;
            set => SetProperty(ref notifications, value);
        }
        public async void CancelNotification(int id)
        {
            Notifications.Remove(Notifications.Where(x => x.NotificationId == id).FirstOrDefault());
        }
        public void SetTest()
        {
            Console.WriteLine("REST");
        }
        public async void AddNotification(string title, string message, string color)
        {
            List<NotificationItem> oldNotifications = Notifications.ToList();
            if(oldNotifications.Count == 4)
            {
                oldNotifications = oldNotifications.OrderBy(x => x.timeAdded).ToList();
                oldNotifications.Remove(oldNotifications.First());
            }
            oldNotifications.Add(new NotificationItem() { BackgroundColor = color, NotificationActive = true, NotificationId = new Random().Next(1, 5000), NotificationText = message, NotificationTitle = title, timeAdded = DateTime.Now });
            ObservableCollection<NotificationItem> newNotifications = new ObservableCollection<NotificationItem>(oldNotifications);
            Notifications = newNotifications;
        }
    }
    public class TBAViewModel : ViewModelBase
    {
        private bool userControlVisible = false;
        public bool UserControlVisible
        {
            get => userControlVisible;
            set => SetProperty(ref userControlVisible, value);
        }
        private int minMatch = 0;
        private int maxMatch = 0;
        public int MinMatch
        {
            get => minMatch;
            set => SetProperty(ref minMatch, value);
        }
        public int MaxMatch
        {
            get => minMatch;
            set => SetProperty(ref minMatch, value);
        }
        public async void TheBlueAlliance()
        {
            var TBACheck = new TBAChecking();
            await TBACheck.CheckCurrentMatchesToDB(MinMatch, MaxMatch);
        }

    }
    public class GraphViewModel : ViewModelBase
    {
        private bool userControlVisible = false;
        public PlotController customController { get; private set; }
        private int graphHeight = 650;
        private PlotModel dataPoints = new PlotModel();
        public int GraphHeight
        {
            get => graphHeight;
            set => SetProperty(ref graphHeight, value);
        }
        public PlotModel DataPoints
        {
            get => dataPoints;
            set => SetProperty(ref dataPoints, value);
        }
        public bool UserControlVisible
        {
            get => userControlVisible;
            set => SetProperty(ref userControlVisible, value);
        }
        public void CreateGraphOfData()
        {
            /*customController = new PlotController();
            customController.UnbindMouseDown(OxyMouseButton.Left);
            customController.BindMouseEnter(PlotCommands.HoverSnapTrack);
            DataPoints = null;
            DataPoints = new PlotModel
            {
                Title = "Total Power Cells",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.RightTop,
                LegendOrientation = LegendOrientation.Vertical,
                LegendBorderThickness = 0
            };
            var lowerpc = new OxyPlot.Series.LineSeries { Title = "Lower Power Cells" };
            var outerpc = new OxyPlot.Series.LineSeries { Title = "Outer Power Cells" };
            var innerpc = new OxyPlot.Series.LineSeries { Title = "Inner Power Cells" };
            var missedpc = new OxyPlot.Series.LineSeries { Title = "Missed Power Cells" };
            lowerpc.Points.Add(new DataPoint(1, 100));
            lowerpc.Points.Add(new DataPoint(2, 100));
            lowerpc.Points.Add(new DataPoint(3, 100));
            lowerpc.Points.Add(new DataPoint(4, 100));
            outerpc.Points.Add(new DataPoint(1, 105));
            outerpc.Points.Add(new DataPoint(2, 105));
            outerpc.Points.Add(new DataPoint(3, 105));
            outerpc.Points.Add(new DataPoint(4, 105));
            innerpc.Points.Add(new DataPoint(1, 110));
            innerpc.Points.Add(new DataPoint(2, 110));
            innerpc.Points.Add(new DataPoint(3, 110));
            innerpc.Points.Add(new DataPoint(4, 110));
            missedpc.Points.Add(new DataPoint(1, 115));
            missedpc.Points.Add(new DataPoint(2, 115));
            missedpc.Points.Add(new DataPoint(3, 115));
            missedpc.Points.Add(new DataPoint(4, 115));
            DataPoints.Series.Add(lowerpc);
            DataPoints.Series.Add(outerpc);
            DataPoints.Series.Add(innerpc);
            DataPoints.Series.Add(missedpc);
            DataPoints.Axes.Add(new OxyPlot.Axes.LinearAxis());
            DataPoints.Axes.Add(new OxyPlot.Axes.LinearAxis());*/
        }
        public GraphViewModel(TrackedProperty[] trackingBy, TrackedProperty[] orderingBy)
        {
            try
            {
                using (var db = new ScoutingContext())
                {
                    customController = new PlotController();
                    customController.UnbindMouseDown(OxyMouseButton.Left);
                    customController.BindMouseEnter(PlotCommands.HoverSnapTrack);
                    DataPoints = new PlotModel
                    {
                        Title = "Test Graph",
                        LegendPlacement = LegendPlacement.Outside,
                        LegendPosition = LegendPosition.RightTop,
                        LegendOrientation = LegendOrientation.Vertical,
                        LegendBorderThickness = 0,
                        DefaultColors = new List<OxyColor>() { OxyColor.FromRgb(255, 255, 255) },
                        PlotAreaBorderColor = OxyColors.White,
                        TitleColor = OxyColors.White,
                        SubtitleColor = OxyColors.White,
                        LegendTextColor = OxyColors.White,
                        LegendTitleColor = OxyColors.White
                    };

                    List<FRCTeamModel> frcTeams = db.FRCTeams.Where(x => x.event_key == new GetEventCode().EventCode()).ToList();
                    List<GraphTeamMatchView> allTeamDataSchemas = new List<GraphTeamMatchView>();


                    foreach (var team in frcTeams)
                    {
                        GraphTeamMatchView modelToAdd = new GraphTeamMatchView();
                        modelToAdd.TeamNumber = team.team_number;
                        var totalinner = 0;
                        var totalouter = 0;
                        var totallower = 0;
                        var totalmissed = 0;
                        var totalshot = 0;
                        var totalscored = 0;
                        int m = 0;
                        List<TeamMatch> teamMatches = db.Matches.Where(x => x.ClientSubmitted == true && x.team_instance_id == team.team_instance_id).ToList();
                        foreach (var match in teamMatches)
                        {
                            int i = 0;
                            foreach (var toadd in match.PowerCellInner)
                            {
                                totalinner += toadd;
                                totalshot += toadd;
                                totalscored += toadd;
                                if (i == 0)
                                {
                                    modelToAdd.AInnerPC += toadd;
                                }
                                else
                                {
                                    modelToAdd.TInnerPC += toadd;
                                }
                                i++;
                            }
                            i = 0;
                            foreach (var toadd in match.PowerCellOuter)
                            {
                                totalouter += toadd;
                                totalshot += toadd;
                                totalscored += toadd;
                                if (i == 0)
                                {
                                    modelToAdd.AOuterPC += toadd;
                                }
                                else
                                {
                                    modelToAdd.TOuterPC += toadd;
                                }
                                i++;
                            }
                            i = 0;
                            foreach (var toadd in match.PowerCellLower)
                            {
                                totallower += toadd;
                                totalshot += toadd;
                                totalscored += toadd;
                                if (i == 0)
                                {
                                    modelToAdd.ALowerPC += toadd;
                                }
                                else
                                {
                                    modelToAdd.TLowerPC += toadd;
                                }
                                i++;
                            }
                            i = 0;
                            foreach (var toadd in match.PowerCellMissed)
                            {
                                totalmissed += toadd;
                                totalshot += toadd;
                                if (i == 0)
                                {
                                    modelToAdd.AMissedPC += toadd;
                                }
                                else
                                {
                                    modelToAdd.TMissedPC += toadd;
                                }
                                i++;
                            }

                            modelToAdd.Disabled += match.DisabledSeconds;
                            modelToAdd.DefenseRate += match.DefenseFor ? 1 : 0;
                            modelToAdd.BalanceRate += match.E_Balanced ? 1 : 0;
                            modelToAdd.ParkRate += match.E_Park ? 1 : 0;
                            modelToAdd.ClimbRate += match.E_ClimbSuccess ? 1 : 0;
                            modelToAdd.CycleTime += match.CycleTime;
                            modelToAdd.NumCycles += match.NumCycles;
                            m++;
                        }
                        modelToAdd.CycleTime = modelToAdd.CycleTime / m;
                        modelToAdd.NumCycles = modelToAdd.NumCycles / m;
                        modelToAdd.TotalInnerPC = totalinner / m;
                        modelToAdd.TotalOuterPC = totalouter / m;
                        modelToAdd.TotalLowerPC = totallower / m;
                        modelToAdd.TotalMissedPC = totalmissed / m;
                        modelToAdd.TotalScoredPC = totalscored / m;
                        modelToAdd.TotalShotPC = totalshot / m;
                        modelToAdd.Disabled = modelToAdd.Disabled / m;
                        modelToAdd.DefenseRate = (double)modelToAdd.DefenseRate / m;
                        modelToAdd.BalanceRate = (double)modelToAdd.BalanceRate / m;
                        modelToAdd.ParkRate = (double)modelToAdd.ParkRate / m;
                        modelToAdd.ClimbRate = (double)modelToAdd.ClimbRate / m;
                        allTeamDataSchemas.Add(modelToAdd);
                    }


                    var barseries = new List<OxyPlot.Series.BarSeries>();

                    var s1 = new OxyPlot.Series.BarSeries { Title = "Lower Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
                    var s2 = new OxyPlot.Series.BarSeries { Title = "Outer Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
                    var s3 = new OxyPlot.Series.BarSeries { Title = "Inner Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
                    var categoryAxis = new OxyPlot.Axes.CategoryAxis { Position = AxisPosition.Left, AxisTickToLabelDistance = 2 };
                    var j = 0;
                    var listofcolors = new object[7] { OxyColors.DeepPink, OxyColors.Violet, OxyColors.DeepSkyBlue, OxyColors.Turquoise, OxyColors.MediumSeaGreen, OxyColors.GreenYellow, OxyColors.Gold };
                    string trackstring = "";
                    var allbarseriesproperties = new List<string>();
                    foreach (var rawtrackingtype in trackingBy.OrderBy(x => x.OrderNum))
                    {

                        OxyPlot.Series.BarSeries newBarSeries = new OxyPlot.Series.BarSeries { Title = rawtrackingtype.OrderTypeProperty, StrokeColor = OxyColors.White, StrokeThickness = 1 };
                        newBarSeries.IsStacked = true;
                        newBarSeries.LabelPlacement = LabelPlacement.Base;
                        newBarSeries.LabelMargin = 5;
                        newBarSeries.FillColor = (OxyColor)listofcolors[j];
                        newBarSeries.LabelMargin = 5;
                        newBarSeries.BaseValue = 1;
                        newBarSeries.TextColor = OxyColors.White;

                        string trackingtype = "";
                        switch (rawtrackingtype.OrderTypeProperty)
                        {
                            case "Total Inner PC":
                                trackingtype = "TotalInnerPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Total Outer PC":
                                trackingtype = "TotalOuterPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Total Lower PC":
                                trackingtype = "TotalLowerPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Total Missed PC":
                                trackingtype = "TotalMissedPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "A Inner PC":
                                trackingtype = "AInnerPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;

                            case "A Outer PC":
                                trackingtype = "AOuterPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "A Lower PC":
                                trackingtype = "ALowerPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "A Missed PC":
                                trackingtype = "AMissedPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "T Inner PC":
                                trackingtype = "TInnerPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "T Outer PC":
                                trackingtype = "TOuterPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "T Lower PC":
                                trackingtype = "TLowerPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "T Missed PC":
                                trackingtype = "TMissedPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Total Shot PC":
                                trackingtype = "TotalShotPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Total Scored PC":
                                trackingtype = "TotalScoredPC";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Park Rate":
                                trackingtype = "ParkRate";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Climb Rate":
                                trackingtype = "ClimbRate";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Balance Rate":
                                trackingtype = "BalanceRate";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Defense Rate":
                                trackingtype = "DefenseRate";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Disabled (s)":
                                trackingtype = "Disabled";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "Cycle Time (s)":
                                trackingtype = "CycleTime";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                            case "# of Cycles":
                                trackingtype = "NumCycles";
                                newBarSeries.LabelFormatString = "{0} PC";
                                break;
                        }
                        barseries.Add(newBarSeries);
                        allbarseriesproperties.Add(trackingtype);

                        j++;
                    }

                    foreach (var rawordertype in orderingBy.OrderBy(x => x.OrderNum))
                    {

                        string trackingtype = "";
                        switch (rawordertype.OrderTypeProperty)
                        {
                            case "Team Number":
                                trackingtype = "TeamNumbers";
                                break;
                            case "Total Inner PC":
                                trackingtype = "TotalInnerPC";
                                break;
                            case "Total Outer PC":
                                trackingtype = "TotalOuterPC";
                                break;
                            case "Total Lower PC":
                                trackingtype = "TotalLowerPC";
                                break;
                            case "Total Missed PC":
                                trackingtype = "TotalMissedPC";

                                break;
                            case "A Inner PC":
                                trackingtype = "AInnerPC";
                                break;
                            case "A Outer PC":
                                trackingtype = "AOuterPC";
                                break;
                            case "A Lower PC":
                                trackingtype = "ALowerPC";
                                break;
                            case "A Missed PC":
                                trackingtype = "AMissedPC";
                                break;
                            case "T Inner PC":
                                trackingtype = "TInnerPC";
                                break;
                            case "T Outer PC":
                                trackingtype = "TOuterPC";
                                break;
                            case "T Lower PC":
                                trackingtype = "TLowerPC";
                                break;
                            case "T Missed PC":
                                trackingtype = "TMissedPC";
                                break;
                            case "Total Shot PC":
                                trackingtype = "TotalShotPC";

                                break;
                            case "Total Scored PC":
                                trackingtype = "TotalScoredPC";

                                break;
                            case "Park Rate":
                                trackingtype = "ParkRate";

                                break;
                            case "Climb Rate":
                                trackingtype = "ClimbRate";

                                break;
                            case "Balance Rate":
                                trackingtype = "BalanceRate";

                                break;
                            case "Defense Rate":
                                trackingtype = "DefenseRate";

                                break;
                            case "Disabled (s)":
                                trackingtype = "Disabled";

                                break;
                            case "Cycle Time (s)":
                                trackingtype = "CycleTime";

                                break;
                            case "# of Cycles":
                                trackingtype = "NumCycles";

                                break;
                        }
                        if (trackstring != "")
                        {
                            trackstring = trackstring + ", ";
                        }
                        if (rawordertype.Ascending)
                        {
                            trackstring = trackstring + trackingtype + " ASC";
                        }
                        else
                        {
                            trackstring = trackstring + trackingtype + " DESC";
                        }
                        


                    }
                    allTeamDataSchemas = OrderByHelper.OrderBy(allTeamDataSchemas, trackstring).ToList();

                    foreach (var team in allTeamDataSchemas)
                    {
                        int b = 0;
                        foreach (var bar in barseries)
                        {
                            PropertyInfo pinfo = typeof(GraphTeamMatchView).GetProperty(allbarseriesproperties[b]);
                            try
                            {
                                barseries.ToArray()[barseries.IndexOf(bar)].Items.Add(new BarItem { Value = (double)pinfo.GetValue(team, null) });
                            }
                            catch (Exception ex)
                            {
                                barseries.ToArray()[barseries.IndexOf(bar)].Items.Add(new BarItem { Value = (int)pinfo.GetValue(team, null) });
                            }

                            b++;
                        }
                        //s1.Items.Add(new BarItem { Value = team.AvgLowerPC });
                        //s2.Items.Add(new BarItem { Value = team.AvgOuterPC });
                        //s3.Items.Add(new BarItem { Value = team.AvgInnerPC });
                        categoryAxis.Labels.Add(team.TeamNumber.ToString());
                        //j++;
                    }
                    GraphHeight = (categoryAxis.Labels.Count * 50) + 100;
                    var valueAxis = new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
                    valueAxis.AxislineThickness = 2;
                    valueAxis.AxislineColor = OxyColors.White;
                    valueAxis.TicklineColor = OxyColors.White;
                    valueAxis.TextColor = OxyColors.White;
                    valueAxis.AxislineStyle = LineStyle.None;
                    categoryAxis.AxislineThickness = 2;
                    categoryAxis.AxislineColor = OxyColors.White;
                    categoryAxis.TicklineColor = OxyColors.White;
                    categoryAxis.TextColor = OxyColors.White;
                    categoryAxis.AxislineStyle = LineStyle.None;
                    foreach (var bar in barseries)
                    {
                        DataPoints.Series.Add(bar);
                    }
                    DataPoints.Axes.Add(categoryAxis);
                    DataPoints.Axes.Add(valueAxis);
                }
            }
            catch(Exception ex)
            {

            }
            
            /*customController = new PlotController();
            customController.UnbindMouseDown(OxyMouseButton.Left);
            customController.BindMouseEnter(PlotCommands.HoverSnack);
            DataPoints = new PlotModel
            {
                Title = "Total Power Cells",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.RightTop,
                LegendOrientation = LegendOrientation.Vertical,
                LegendBorderThickness = 0,
            };

            var s1 = new OxyPlot.Series.BarSeries { Title = "Lower Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s1.IsStacked = true;
            s1.LabelPlacement = LabelPlacement.Inside;
            s1.FillColor = OxyColors.LightYellow;
            s1.LabelMargin = 5;
            s1.TextColor = OxyColors.Black;
            s1.LabelFormatString = "{0} PC";
            s1.Items.Add(new BarItem { Value = 1 });
            s1.Items.Add(new BarItem { Value = 2 });
            s1.Items.Add(new BarItem { Value = 3 });
            s1.Items.Add(new BarItem { Value = 4 });
            s1.Items.Add(new BarItem { Value = 4 });
            s1.Items.Add(new BarItem { Value = 4 });
            s1.Items.Add(new BarItem { Value = 6 });
            s1.Items.Add(new BarItem { Value = 8 });
            s1.Items.Add(new BarItem { Value = 8 });
            s1.Items.Add(new BarItem { Value = 8 });

            var s2 = new OxyPlot.Series.BarSeries { Title = "Outer Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s2.LabelPlacement = LabelPlacement.Inside;
            s2.IsStacked = true;
            s2.LabelMargin = 5;
            s2.LabelFormatString = "{0} PC";
            s2.TextColor = OxyColors.White;
            s2.FillColor = OxyColors.LightSeaGreen;
            s2.Items.Add(new BarItem { Value = 5 });
            s2.Items.Add(new BarItem { Value = 2 });
            s2.Items.Add(new BarItem { Value = 4 });
            s2.Items.Add(new BarItem { Value = 5 });
            s2.Items.Add(new BarItem { Value = 2 });
            s2.Items.Add(new BarItem { Value = 4 });
            s2.Items.Add(new BarItem { Value = 6 });
            s2.Items.Add(new BarItem { Value = 10 });
            s2.Items.Add(new BarItem { Value = 2 });
            s2.Items.Add(new BarItem { Value = 5 });

            var s3 = new OxyPlot.Series.BarSeries { Title = "Inner Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            s3.IsStacked = true;
            s3.FillColor = OxyColors.LightBlue;
            s3.LabelPlacement = LabelPlacement.Inside;
            s3.LabelFormatString = "{0} PC";
            s3.LabelMargin = 5;
            s3.TextColor = OxyColors.Black;
            s3.Items.Add(new BarItem { Value = 1 });
            s3.Items.Add(new BarItem { Value = 2 });
            s3.Items.Add(new BarItem { Value = 3 });
            s3.Items.Add(new BarItem { Value = 4 });
            s3.Items.Add(new BarItem { Value = 4 });
            s3.Items.Add(new BarItem { Value = 4 });
            s3.Items.Add(new BarItem { Value = 6 });
            s3.Items.Add(new BarItem { Value = 6 });
            s3.Items.Add(new BarItem { Value = 3 });
            s3.Items.Add(new BarItem { Value = 10 });

            var categoryAxis = new OxyPlot.Axes.CategoryAxis { Position = AxisPosition.Left, AxisTickToLabelDistance = 2 };
            categoryAxis.Labels.Add("862");
            categoryAxis.Labels.Add("10176");
            categoryAxis.Labels.Add("1023");
            categoryAxis.Labels.Add("254");
            categoryAxis.Labels.Add("254");
            categoryAxis.Labels.Add("254");
            categoryAxis.Labels.Add("254");
            categoryAxis.Labels.Add("254");
            categoryAxis.Labels.Add("254");
            categoryAxis.Labels.Add("254");
            GraphHeight = categoryAxis.Labels.Count * 50;
            var valueAxis = new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            DataPoints.Series.Add(s1);
            DataPoints.Series.Add(s2);
            DataPoints.Series.Add(s3);
            DataPoints.Axes.Add(categoryAxis);
            DataPoints.Axes.Add(valueAxis);*/
        }
        public void SetGraphType()
        {
            using(var db = new ScoutingContext())
            {
                DataPoints.Series.Clear();
                DataPoints.Axes.Clear();

                List<TeamMatch> dbMatches = db.Matches.Where(x => x.ClientSubmitted == true && x.EventCode == new GetEventCode().EventCode()).ToList();
                List<int> selectedTeamNumbers = new List<int>();
                List<AveragePCCountModel> averagePCCountModels = new List<AveragePCCountModel>();

                foreach(var entry in dbMatches)
                {
                    var TrackedTeam = db.FRCTeams.Find(entry.team_instance_id);
                    AveragePCCountModel modelToAdd = new AveragePCCountModel();
                    if (!selectedTeamNumbers.Contains(TrackedTeam.team_number))
                    {
                        modelToAdd.TeamNumber = TrackedTeam.team_number;
                        selectedTeamNumbers.Add(TrackedTeam.team_number);
                        var inner = 0;
                        var outer = 0;
                        var lower = 0;
                        var total = 0;
                        foreach(var toadd in entry.PowerCellInner)
                        {
                            inner += toadd;
                            total += toadd;
                        }
                        foreach (var toadd in entry.PowerCellOuter)
                        {
                            outer += toadd;
                            total += toadd;
                        }
                        foreach (var toadd in entry.PowerCellLower)
                        {
                            lower += toadd;
                            total += toadd;
                        }
                        modelToAdd.AvgInnerPC = inner;
                        modelToAdd.AvgOuterPC = outer;
                        modelToAdd.AvgTotalPC = total;
                        modelToAdd.AvgLowerPC = lower;
                        modelToAdd.Matches++;
                        averagePCCountModels.Add(modelToAdd);
                    }
                    else
                    {
                        modelToAdd = averagePCCountModels.Where(x => x.TeamNumber == TrackedTeam.team_number).FirstOrDefault();
                        modelToAdd.TeamNumber = TrackedTeam.team_number;
                        var inner = modelToAdd.AvgInnerPC * modelToAdd.Matches;
                        var outer = modelToAdd.AvgOuterPC * modelToAdd.Matches;
                        var lower = modelToAdd.AvgLowerPC * modelToAdd.Matches;
                        var total = modelToAdd.AvgTotalPC * modelToAdd.Matches;
                        foreach (var toadd in entry.PowerCellInner)
                        {
                            inner += toadd;
                            total += toadd;
                        }
                        foreach (var toadd in entry.PowerCellOuter)
                        {
                            outer += toadd;
                            total += toadd;
                        }
                        foreach (var toadd in entry.PowerCellLower)
                        {
                            lower += toadd;
                            total += toadd;
                        }
                        modelToAdd.Matches++;
                        modelToAdd.AvgInnerPC = (int)Math.Ceiling((float)inner / (float)modelToAdd.Matches);
                        modelToAdd.AvgOuterPC = (int)Math.Ceiling((float)outer / (float)modelToAdd.Matches);
                        modelToAdd.AvgTotalPC = (int)Math.Ceiling((float)total / (float)modelToAdd.Matches);
                        modelToAdd.AvgLowerPC = (int)Math.Ceiling((float)lower / (float)modelToAdd.Matches);
                        averagePCCountModels.Remove(averagePCCountModels.Where(x => x.TeamNumber == TrackedTeam.team_number).FirstOrDefault());
                        averagePCCountModels.Add(modelToAdd);
                    }
                    
                }

                var s1 = new OxyPlot.Series.BarSeries { Title = "Lower Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
                var s2 = new OxyPlot.Series.BarSeries { Title = "Outer Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
                var s3 = new OxyPlot.Series.BarSeries { Title = "Inner Power Cells", StrokeColor = OxyColors.Black, StrokeThickness = 1 };
                var categoryAxis = new OxyPlot.Axes.CategoryAxis { Position = AxisPosition.Left, AxisTickToLabelDistance = 2 };
                s1.IsStacked = true;
                s1.LabelPlacement = LabelPlacement.Inside;
                s1.FillColor = OxyColors.LightYellow;
                s1.LabelMargin = 5;
                s1.TextColor = OxyColors.Black;
                s1.LabelFormatString = "{0} PC";
                s2.LabelPlacement = LabelPlacement.Inside;
                s2.IsStacked = true;
                s2.LabelMargin = 5;
                s2.LabelFormatString = "{0} PC";
                s2.TextColor = OxyColors.White;
                s2.FillColor = OxyColors.LightSeaGreen;
                s3.IsStacked = true;
                s3.FillColor = OxyColors.LightBlue;
                s3.LabelPlacement = LabelPlacement.Inside;
                s3.LabelFormatString = "{0} PC";
                s3.LabelMargin = 5;
                s3.TextColor = OxyColors.Black;
                var i = 0;
                foreach(var team in averagePCCountModels.OrderByDescending(x => x.AvgTotalPC).ThenByDescending(x => x.AvgInnerPC).ThenByDescending(x => x.AvgOuterPC).ThenByDescending(x => x.AvgOuterPC))
                {
                    
                    s1.Items.Add(new BarItem { Value = team.AvgLowerPC });
                    s2.Items.Add(new BarItem { Value = team.AvgOuterPC });
                    s3.Items.Add(new BarItem { Value = team.AvgInnerPC });
                    categoryAxis.Labels.Add(team.TeamNumber.ToString());
                    i++;
                }
                GraphHeight = (categoryAxis.Labels.Count * 50)+100;
                var valueAxis = new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
                DataPoints.Series.Add(s1);
                DataPoints.Series.Add(s2);
                DataPoints.Series.Add(s3);
                DataPoints.Axes.Add(categoryAxis);
                DataPoints.Axes.Add(valueAxis);
            }
            
        }
    }
    public class Item : BarItem
    {
        public string Label { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
    }
    public class MatchViewModel : ViewModelBase
    {
        
        private string testText = "abc";
        private bool red1MatchNotFilled = false;
        private bool red2MatchNotFilled = false;
        private bool red3MatchNotFilled = false;
        private bool blue1MatchNotFilled = false;
        private bool blue2MatchNotFilled = false;
        private bool blue3MatchNotFilled = false;
        private bool red1MatchEditable = false;
        private bool red2MatchEditable = false;
        private bool red3MatchEditable = false;
        private bool blue1MatchEditable = false;
        private bool blue2MatchEditable = false;
        private bool blue3MatchEditable = false;
        private ObservableCollection<LogEntry> logEntries = new ObservableCollection<LogEntry>();
        public TeamMatch originalR1 = new TeamMatch();
        public TeamMatch originalR2 = new TeamMatch();
        public TeamMatch originalR3 = new TeamMatch();
        public TeamMatch originalB1 = new TeamMatch();
        public TeamMatch originalB2 = new TeamMatch();
        public TeamMatch originalB3 = new TeamMatch();
        private TeamMatchView red1CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView red2CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView red3CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView blue1CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView blue2CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private TeamMatchView blue3CurrentMatch = new TeamMatchView() { ScoutName = "No One" };
        private bool userControlVisible = false;
        public bool UserControlVisible
        {
            get => userControlVisible;
            set => SetProperty(ref userControlVisible, value);
        }
        public ObservableCollection<LogEntry> CurrentLogEntries
        {
            get => logEntries;
            set => SetProperty(ref logEntries, value);
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
        public bool Red1MatchNotFilled
        {
            get => red1MatchNotFilled;
            set => SetProperty(ref red1MatchNotFilled, value);
        }
        public bool Red2MatchNotFilled
        {
            get => red2MatchNotFilled;
            set => SetProperty(ref red2MatchNotFilled, value);
        }
        public bool Red3MatchNotFilled
        {
            get => red3MatchNotFilled;
            set => SetProperty(ref red3MatchNotFilled, value);
        }
        public bool Blue1MatchNotFilled
        {
            get => blue1MatchNotFilled;
            set => SetProperty(ref blue1MatchNotFilled, value);
        }
        public bool Blue2MatchNotFilled
        {
            get => blue2MatchNotFilled;
            set => SetProperty(ref blue2MatchNotFilled, value);
        }
        public bool Blue3MatchNotFilled
        {
            get => blue3MatchNotFilled;
            set => SetProperty(ref blue3MatchNotFilled, value);
        }
        public bool Red1MatchEditable
        {
            get => red1MatchEditable;
            set => SetProperty(ref red1MatchEditable, value);
        }
        public bool Red2MatchEditable
        {
            get => red2MatchEditable;
            set => SetProperty(ref red2MatchEditable, value);
        }
        public bool Red3MatchEditable
        {
            get => red3MatchEditable;
            set => SetProperty(ref red3MatchEditable, value);
        }
        public bool Blue1MatchEditable
        {
            get => blue1MatchEditable;
            set => SetProperty(ref blue1MatchEditable, value);
        }
        public bool Blue2MatchEditable
        {
            get => blue2MatchEditable;
            set => SetProperty(ref blue2MatchEditable, value);
        }
        public bool Blue3MatchEditable
        {
            get => blue3MatchEditable;
            set => SetProperty(ref blue3MatchEditable, value);
        }
        public void GetLogsForCurrentEntry(string identifier)
        {
            TeamMatch selectedForLogs = new TeamMatch();
            switch (identifier)
            {
                case "R1":
                    selectedForLogs = originalR1;
                    break;
                case "R2":
                    selectedForLogs = originalR2;
                    break;
                case "R3":
                    selectedForLogs = originalR3;
                    break;
                case "B1":
                    selectedForLogs = originalB1;
                    break;
                case "B2":
                    selectedForLogs = originalB2;
                    break;
                case "B3":
                    selectedForLogs = originalB3;
                    break;
            }
            try
            {
                List<string> logsToParse = selectedForLogs.TapLogs.ToList();
                List<LogEntry> entriesToDisplay = new List<LogEntry>();
                foreach (var logToParse in logsToParse)
                {

                    int actionTimestamp = int.Parse(logToParse.Split(":")[0]);
                    int minutes = (int)Math.Floor((double)actionTimestamp / (double)60);
                    int seconds = actionTimestamp % 60;
                    string secondsview = "";
                    if (seconds < 10)
                    {
                        secondsview = "0" + seconds.ToString();
                    }
                    else
                    {
                        secondsview = seconds.ToString();
                    }
                    LogEntry newLogEntry = new LogEntry();
                    newLogEntry.TimeFormatted = minutes.ToString() + ":" + secondsview;
                    int actionIdentifier = int.Parse(logToParse.Split(":")[1]);
                    switch (actionIdentifier)
                    {
                        case 1:
                            newLogEntry.Description = "Scouting Entry Started";
                            newLogEntry.Background = "Aqua";
                            break;
                        case 2:
                            newLogEntry.Description = "Scouting Entry Finished";
                            newLogEntry.Background = "Aqua";
                            break;
                        case 9:
                            //TBI
                            newLogEntry.Description = "Scouting Entry Populated from DB, Already Completed";
                            newLogEntry.Background = "Pink";
                            break;
                        case 10:
                            newLogEntry.Description = "Ignore Time Notice";
                            newLogEntry.Background = "Pink";
                            break;
                        case 100:
                            newLogEntry.Description = "Scout Name Changed to " + logToParse.Split(":")[2];
                            newLogEntry.Background = "Purple";
                            break;
                        case 1001:
                            newLogEntry.Description = "Page Changed to 'Ready for Match'";
                            newLogEntry.Background = "Gray";
                            break;
                        case 1002:
                            newLogEntry.Description = "Page Changed to 'Autonomous'";
                            newLogEntry.Background = "Gray";
                            break;
                        case 1003:
                            newLogEntry.Description = "Page Changed to 'Tele-Op'";
                            newLogEntry.Background = "Gray";
                            break;
                        case 1004:
                            newLogEntry.Description = "Page Changed to 'Endgame'";
                            newLogEntry.Background = "Gray";
                            break;
                        case 1005:
                            newLogEntry.Description = "Page Changed to 'After Match'";
                            newLogEntry.Background = "Gray";
                            break;
                        case 1006:
                            newLogEntry.Description = "Page Changed to 'Confirm Form'";
                            newLogEntry.Background = "Gray";
                            break;
                        case 2000:
                            newLogEntry.Description = "Initiation Line Marked as ACHIEVED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 2001:
                            newLogEntry.Description = "Initiation Line Marked as NOT ACHIEVED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 3000:
                            newLogEntry.Description = "Created New Tele-Op Cycle";
                            newLogEntry.Background = "Gray";
                            break;
                        case 3010:
                            newLogEntry.Description = "Control Panel Rotation Marked as ACHIEVED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 3011:
                            newLogEntry.Description = "Control Panel Rotation Marked as NOT ACHIEVED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 3020:
                            newLogEntry.Description = "Control Panel Position Marked as ACHIEVED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 3021:
                            newLogEntry.Description = "Control Panel Position Marked as NOT ACHIEVED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 4000:
                            newLogEntry.Description = "Endgame Parking Marked as PARKED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 4001:
                            newLogEntry.Description = "Endgame Parking Marked as NOT PARKED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 4010:
                            newLogEntry.Description = "Endgame Attempted Marked as ATTEMPTED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 4011:
                            newLogEntry.Description = "Endgame Attempted Marked as NOT ATTEMPTED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 4020:
                            newLogEntry.Description = "Endgame Successful Marked as SUCCESSFUL";
                            newLogEntry.Background = "Gray";
                            break;
                        case 4021:
                            newLogEntry.Description = "Endgame Successful Marked as NOT SUCCESSFUL";
                            newLogEntry.Background = "Gray";
                            break;
                        case 4030:
                            newLogEntry.Description = "Endgame Balanced Marked as CONTRIBUTED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 4031:
                            newLogEntry.Description = "Endgame Balanced Marked as NOT CONTRIBUTED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 8000:
                            newLogEntry.Description = "Shooting Location Changed to " + logToParse.Split(":")[2];
                            newLogEntry.Background = "Gray";
                            break;
                        case 8001:
                            newLogEntry.Description = "Loading Location Changed to " + logToParse.Split(":")[2];
                            newLogEntry.Background = "Gray";
                            break;
                        case 8010:
                            newLogEntry.Description = "Defense For Marked as YES";
                            newLogEntry.Background = "Gray";
                            break;
                        case 8011:
                            newLogEntry.Description = "Defense For Marked as NO";
                            newLogEntry.Background = "Gray";
                            break;
                        case 8020:
                            newLogEntry.Description = "Defense Against Marked as YES";
                            newLogEntry.Background = "Gray";
                            break;
                        case 8021:
                            newLogEntry.Description = "Defense Against Marked as NO";
                            newLogEntry.Background = "Gray";
                            break;
                        case 9000:
                            newLogEntry.Description = "Robot Marked as DISABLED";
                            newLogEntry.Background = "Gray";
                            break;
                        case 9001:
                            newLogEntry.Description = "Robot Marked as NOT DISABLED";
                            newLogEntry.Background = "Gray";
                            break;
                        default:
                            newLogEntry.Description = "Unknown Log";
                            newLogEntry.Background = "Black";
                            break;
                    }
                    entriesToDisplay.Add(newLogEntry);
                }
                CurrentLogEntries = new ObservableCollection<LogEntry>(entriesToDisplay);
            }catch(Exception e)
            {

            }
            

        }
        public void SaveChanges()
        {
            try
            {
                using (var db = new ScoutingContext())
                {
                    TeamMatch newRed1Match = new TeamMatch() { PowerCellInner = new int[21], PowerCellLower = new int[21], PowerCellOuter = new int[21], PowerCellMissed = new int[21] };
                    TeamMatch newRed2Match = new TeamMatch() { PowerCellInner = new int[21], PowerCellLower = new int[21], PowerCellOuter = new int[21], PowerCellMissed = new int[21] };
                    TeamMatch newRed3Match = new TeamMatch() { PowerCellInner = new int[21], PowerCellLower = new int[21], PowerCellOuter = new int[21], PowerCellMissed = new int[21] };
                    TeamMatch newBlue1Match = new TeamMatch() { PowerCellInner = new int[21], PowerCellLower = new int[21], PowerCellOuter = new int[21], PowerCellMissed = new int[21] };
                    TeamMatch newBlue2Match = new TeamMatch() { PowerCellInner = new int[21], PowerCellLower = new int[21], PowerCellOuter = new int[21], PowerCellMissed = new int[21] };
                    TeamMatch newBlue3Match = new TeamMatch() { PowerCellInner = new int[21], PowerCellLower = new int[21], PowerCellOuter = new int[21], PowerCellMissed = new int[21] };
                    newRed1Match.A_InitiationLine = Red1CurrentMatch.A_InitiationLine;
                    newRed1Match.ScoutName = Red1CurrentMatch.ScoutName;
                    newRed1Match.DisabledSeconds = Red1CurrentMatch.DisabledSeconds;
                    newRed1Match.EventCode = originalR1.EventCode;
                    newRed1Match.E_Balanced = Red1CurrentMatch.E_Balanced;
                    newRed1Match.E_ClimbAttempt = Red1CurrentMatch.E_ClimbAttempt;
                    newRed1Match.E_ClimbSuccess = Red1CurrentMatch.E_ClimbSuccess;
                    newRed1Match.E_Park = Red1CurrentMatch.E_Park;
                    newRed1Match.MatchID = originalR1.MatchID;
                    newRed1Match.MatchNumber = originalR1.MatchNumber;
                    newRed1Match.NumCycles = Red1CurrentMatch.NumCycles;
                    if (originalR1.PowerCellMissed != null)
                    {
                        newRed1Match.PowerCellInner = originalR1.PowerCellInner;
                        newRed1Match.PowerCellOuter = originalR1.PowerCellOuter;
                        newRed1Match.PowerCellLower = originalR1.PowerCellLower;
                        newRed1Match.PowerCellMissed = originalR1.PowerCellMissed;
                    }
                    newRed1Match.PowerCellInner[0] = Red1CurrentMatch.APowerCellInner;
                    newRed1Match.PowerCellOuter[0] = Red1CurrentMatch.APowerCellOuter;
                    newRed1Match.PowerCellLower[0] = Red1CurrentMatch.APowerCellLower;
                    newRed1Match.PowerCellMissed[0] = Red1CurrentMatch.APowerCellMissed;
                    newRed1Match.RobotPosition = originalR1.RobotPosition;
                    newRed1Match.TabletId = originalR1.TabletId;
                    newRed1Match.TeamName = originalR1.TeamName;
                    newRed1Match.T_ControlPanelPosition = Red1CurrentMatch.T_ControlPanelPosition;
                    newRed1Match.T_ControlPanelRotation = Red1CurrentMatch.T_ControlPanelRotation;
                    var previousRed1 = db.Matches.Where(x => x.TabletId == newRed1Match.TabletId && x.MatchNumber == newRed1Match.MatchNumber && x.EventCode == newRed1Match.EventCode).FirstOrDefault();
                    if (previousRed1 != null)
                    {
                        db.Matches.Update(newRed1Match);
                    }
                    newRed2Match.A_InitiationLine = Red2CurrentMatch.A_InitiationLine;
                    newRed2Match.ScoutName = Red2CurrentMatch.ScoutName;
                    newRed2Match.DisabledSeconds = Red2CurrentMatch.DisabledSeconds;
                    newRed2Match.EventCode = originalR2.EventCode;
                    newRed2Match.E_Balanced = Red2CurrentMatch.E_Balanced;
                    newRed2Match.E_ClimbAttempt = Red2CurrentMatch.E_ClimbAttempt;
                    newRed2Match.E_ClimbSuccess = Red2CurrentMatch.E_ClimbSuccess;
                    newRed2Match.E_Park = Red2CurrentMatch.E_Park;
                    newRed2Match.MatchID = originalR2.MatchID;
                    newRed2Match.MatchNumber = originalR2.MatchNumber;
                    newRed2Match.NumCycles = Red2CurrentMatch.NumCycles;
                    if (originalR2.PowerCellMissed != null)
                    {
                        newRed2Match.PowerCellInner = originalR2.PowerCellInner;
                        newRed2Match.PowerCellOuter = originalR2.PowerCellOuter;
                        newRed2Match.PowerCellLower = originalR2.PowerCellLower;
                        newRed2Match.PowerCellMissed = originalR2.PowerCellMissed;
                    }
                    newRed2Match.PowerCellInner[0] = Red2CurrentMatch.APowerCellInner;
                    newRed2Match.PowerCellOuter[0] = Red2CurrentMatch.APowerCellOuter;
                    newRed2Match.PowerCellLower[0] = Red2CurrentMatch.APowerCellLower;
                    newRed2Match.PowerCellMissed[0] = Red2CurrentMatch.APowerCellMissed;
                    newRed2Match.RobotPosition = originalR2.RobotPosition;
                    newRed2Match.TabletId = originalR2.TabletId;
                    newRed2Match.TeamName = originalR2.TeamName;
                    newRed2Match.T_ControlPanelPosition = Red2CurrentMatch.T_ControlPanelPosition;
                    newRed2Match.T_ControlPanelRotation = Red2CurrentMatch.T_ControlPanelRotation;
                    var previousRed2 = db.Matches.Where(x => x.TabletId == newRed2Match.TabletId && x.MatchNumber == newRed2Match.MatchNumber && x.EventCode == newRed2Match.EventCode).FirstOrDefault();
                    if (previousRed2 != null)
                    {
                        db.Matches.Update(newRed2Match);
                    }
                    newRed3Match.A_InitiationLine = Red3CurrentMatch.A_InitiationLine;
                    newRed3Match.ScoutName = Red3CurrentMatch.ScoutName;
                    newRed3Match.DisabledSeconds = Red3CurrentMatch.DisabledSeconds;
                    newRed3Match.EventCode = originalR3.EventCode;
                    newRed3Match.E_Balanced = Red3CurrentMatch.E_Balanced;
                    newRed3Match.E_ClimbAttempt = Red3CurrentMatch.E_ClimbAttempt;
                    newRed3Match.E_ClimbSuccess = Red3CurrentMatch.E_ClimbSuccess;
                    newRed3Match.E_Park = Red3CurrentMatch.E_Park;
                    newRed3Match.MatchID = originalR3.MatchID;
                    newRed3Match.MatchNumber = originalR3.MatchNumber;
                    newRed3Match.NumCycles = Red3CurrentMatch.NumCycles;
                    if (originalR3.PowerCellMissed != null)
                    {
                        newRed3Match.PowerCellInner = originalR3.PowerCellInner;
                        newRed3Match.PowerCellOuter = originalR3.PowerCellOuter;
                        newRed3Match.PowerCellLower = originalR3.PowerCellLower;
                        newRed3Match.PowerCellMissed = originalR3.PowerCellMissed;
                    }
                    newRed3Match.PowerCellInner[0] = Red3CurrentMatch.APowerCellInner;
                    newRed3Match.PowerCellOuter[0] = Red3CurrentMatch.APowerCellOuter;
                    newRed3Match.PowerCellLower[0] = Red3CurrentMatch.APowerCellLower;
                    newRed3Match.PowerCellMissed[0] = Red3CurrentMatch.APowerCellMissed;
                    newRed3Match.RobotPosition = originalR3.RobotPosition;
                    newRed3Match.TabletId = originalR3.TabletId;
                    newRed3Match.TeamName = originalR3.TeamName;
                    newRed3Match.T_ControlPanelPosition = Red3CurrentMatch.T_ControlPanelPosition;
                    newRed3Match.T_ControlPanelRotation = Red3CurrentMatch.T_ControlPanelRotation;
                    var previousRed3 = db.Matches.Where(x => x.TabletId == newRed3Match.TabletId && x.MatchNumber == newRed3Match.MatchNumber && x.EventCode == newRed3Match.EventCode).FirstOrDefault();
                    if (previousRed3 != null)
                    {
                        db.Matches.Update(newRed3Match);
                    }
                    newBlue1Match.A_InitiationLine = Blue1CurrentMatch.A_InitiationLine;
                    newBlue1Match.ScoutName = Blue1CurrentMatch.ScoutName;
                    newBlue1Match.DisabledSeconds = Blue1CurrentMatch.DisabledSeconds;
                    newBlue1Match.EventCode = originalB1.EventCode;
                    newBlue1Match.E_Balanced = Blue1CurrentMatch.E_Balanced;
                    newBlue1Match.E_ClimbAttempt = Blue1CurrentMatch.E_ClimbAttempt;
                    newBlue1Match.E_ClimbSuccess = Blue1CurrentMatch.E_ClimbSuccess;
                    newBlue1Match.E_Park = Blue1CurrentMatch.E_Park;
                    newBlue1Match.MatchID = originalB1.MatchID;
                    newBlue1Match.MatchNumber = originalB1.MatchNumber;
                    newBlue1Match.NumCycles = Blue1CurrentMatch.NumCycles;
                    if (originalB1.PowerCellMissed != null)
                    {
                        newBlue1Match.PowerCellInner = originalB1.PowerCellInner;
                        newBlue1Match.PowerCellOuter = originalB1.PowerCellOuter;
                        newBlue1Match.PowerCellLower = originalB1.PowerCellLower;
                        newBlue1Match.PowerCellMissed = originalB1.PowerCellMissed;
                    }
                    newBlue1Match.PowerCellInner[0] = Blue1CurrentMatch.APowerCellInner;
                    newBlue1Match.PowerCellOuter[0] = Blue1CurrentMatch.APowerCellOuter;
                    newBlue1Match.PowerCellLower[0] = Blue1CurrentMatch.APowerCellLower;
                    newBlue1Match.PowerCellMissed[0] = Blue1CurrentMatch.APowerCellMissed;
                    newBlue1Match.RobotPosition = originalB1.RobotPosition;
                    newBlue1Match.TabletId = originalB1.TabletId;
                    newBlue1Match.TeamName = originalB1.TeamName;
                    newBlue1Match.T_ControlPanelPosition = Blue1CurrentMatch.T_ControlPanelPosition;
                    newBlue1Match.T_ControlPanelRotation = Blue1CurrentMatch.T_ControlPanelRotation;
                    var previousBlue1 = db.Matches.Where(x => x.TabletId == newBlue1Match.TabletId && x.MatchNumber == newBlue1Match.MatchNumber && x.EventCode == newBlue1Match.EventCode).FirstOrDefault();
                    if (previousBlue1 != null)
                    {
                        db.Matches.Update(newBlue1Match);
                    }
                    newBlue2Match.A_InitiationLine = Blue2CurrentMatch.A_InitiationLine;
                    newBlue2Match.ScoutName = Blue2CurrentMatch.ScoutName;
                    newBlue2Match.DisabledSeconds = Blue2CurrentMatch.DisabledSeconds;
                    newBlue2Match.EventCode = originalB2.EventCode;
                    newBlue2Match.E_Balanced = Blue2CurrentMatch.E_Balanced;
                    newBlue2Match.E_ClimbAttempt = Blue2CurrentMatch.E_ClimbAttempt;
                    newBlue2Match.E_ClimbSuccess = Blue2CurrentMatch.E_ClimbSuccess;
                    newBlue2Match.E_Park = Blue2CurrentMatch.E_Park;
                    newBlue2Match.MatchID = originalB2.MatchID;
                    newBlue2Match.MatchNumber = originalB2.MatchNumber;
                    newBlue2Match.NumCycles = Blue2CurrentMatch.NumCycles;
                    if (originalB2.PowerCellMissed != null)
                    {
                        newBlue2Match.PowerCellInner = originalB2.PowerCellInner;
                        newBlue2Match.PowerCellOuter = originalB2.PowerCellOuter;
                        newBlue2Match.PowerCellLower = originalB2.PowerCellLower;
                        newBlue2Match.PowerCellMissed = originalB2.PowerCellMissed;
                    }
                    newBlue2Match.PowerCellInner[0] = Blue2CurrentMatch.APowerCellInner;
                    newBlue2Match.PowerCellOuter[0] = Blue2CurrentMatch.APowerCellOuter;
                    newBlue2Match.PowerCellLower[0] = Blue2CurrentMatch.APowerCellLower;
                    newBlue2Match.PowerCellMissed[0] = Blue2CurrentMatch.APowerCellMissed;
                    newBlue2Match.RobotPosition = originalB2.RobotPosition;
                    newBlue2Match.TabletId = originalB2.TabletId;
                    newBlue2Match.TeamName = originalB2.TeamName;
                    newBlue2Match.T_ControlPanelPosition = Blue2CurrentMatch.T_ControlPanelPosition;
                    newBlue2Match.T_ControlPanelRotation = Blue2CurrentMatch.T_ControlPanelRotation;
                    newBlue2Match.team_instance_id = originalB2.team_instance_id;
                    var previousBlue2 = db.Matches.Where(x => x.TabletId == newBlue2Match.TabletId && x.MatchNumber == newBlue2Match.MatchNumber && x.EventCode == newBlue2Match.EventCode).FirstOrDefault();
                    if (previousBlue2 != null)
                    {
                        db.Entry(previousBlue2).CurrentValues.SetValues(newBlue2Match);
                    }
                    newBlue3Match.A_InitiationLine = Blue3CurrentMatch.A_InitiationLine;
                    newBlue3Match.ScoutName = Blue3CurrentMatch.ScoutName;
                    newBlue3Match.DisabledSeconds = Blue3CurrentMatch.DisabledSeconds;
                    newBlue3Match.EventCode = originalB3.EventCode;
                    newBlue3Match.E_Balanced = Blue3CurrentMatch.E_Balanced;
                    newBlue3Match.E_ClimbAttempt = Blue3CurrentMatch.E_ClimbAttempt;
                    newBlue3Match.E_ClimbSuccess = Blue3CurrentMatch.E_ClimbSuccess;
                    newBlue3Match.E_Park = Blue3CurrentMatch.E_Park;
                    newBlue3Match.MatchID = originalB3.MatchID;
                    newBlue3Match.MatchNumber = originalB3.MatchNumber;
                    newBlue3Match.NumCycles = Blue3CurrentMatch.NumCycles;
                    if (originalB3.PowerCellMissed != null)
                    {
                        newBlue3Match.PowerCellInner = originalB3.PowerCellInner;
                        newBlue3Match.PowerCellOuter = originalB3.PowerCellOuter;
                        newBlue3Match.PowerCellLower = originalB3.PowerCellLower;
                        newBlue3Match.PowerCellMissed = originalB3.PowerCellMissed;
                    }
                    newBlue3Match.PowerCellInner[0] = Blue3CurrentMatch.APowerCellInner;
                    newBlue3Match.PowerCellOuter[0] = Blue3CurrentMatch.APowerCellOuter;
                    newBlue3Match.PowerCellLower[0] = Blue3CurrentMatch.APowerCellLower;
                    newBlue3Match.PowerCellMissed[0] = Blue3CurrentMatch.APowerCellMissed;
                    newBlue3Match.RobotPosition = originalB3.RobotPosition;
                    newBlue3Match.TabletId = originalB3.TabletId;
                    newBlue3Match.TeamName = originalB3.TeamName;
                    newBlue3Match.T_ControlPanelPosition = Blue3CurrentMatch.T_ControlPanelPosition;
                    newBlue3Match.T_ControlPanelRotation = Blue3CurrentMatch.T_ControlPanelRotation;
                    var previousBlue3 = db.Matches.Where(x => x.TabletId == newBlue3Match.TabletId && x.MatchNumber == newBlue3Match.MatchNumber && x.EventCode == newBlue3Match.EventCode).FirstOrDefault();
                    if (previousBlue3 != null)
                    {
                        db.Matches.Update(newBlue3Match);
                    }
                    /*try
                    {
                        var previousitem = db.Matches.Where(x => x.TabletId == itemtouse.TabletId && x.MatchNumber == itemtouse.MatchNumber && x.EventCode == itemtouse.EventCode).FirstOrDefault();
                        if (previousitem == null)
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
                    catch (NpgsqlException ex)
                    {
                        itemtouse.MatchID = new Random().Next(1, 1000);
                        db.Matches.Add(itemtouse);
                    }*/

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
    
    public class TabletViewModel : ViewModelBase
    {
        private List<string> testBTD = new List<string>();
        private string _text = "Test";
        private Avalonia.Media.Imaging.Bitmap _QRImage;
        private ObservableCollection<string> bluetoothBorderColors = new ObservableCollection<string>(new string[6] { "Gray", "Gray", "Gray", "Gray", "Gray", "Gray" }.ToList());
        private ObservableCollection<string> cableBorderColors = new ObservableCollection<string>(new string[6] { "Gray", "Gray", "Gray", "Gray", "Gray", "Gray" }.ToList());
        private ObservableCollection<string> batteryBorderColors = new ObservableCollection<string>(new string[6] { "Gray", "Gray", "Gray", "Gray", "Gray", "Gray" }.ToList());
        private ObservableCollection<string> bluetoothBackgroundColors = new ObservableCollection<string>(new string[6] { "LightGray", "LightGray", "LightGray", "LightGray", "LightGray", "LightGray" }.ToList());
        private ObservableCollection<string> cableBackgroundColors = new ObservableCollection<string>(new string[6] { "LightGray", "LightGray", "LightGray", "LightGray", "LightGray", "LightGray" }.ToList());
        private ObservableCollection<string> batteryBackgroundColors = new ObservableCollection<string>(new string[6] { "LightGray", "LightGray", "LightGray", "LightGray", "LightGray", "LightGray" }.ToList());
        private ObservableCollection<string> batteryAmounts = new ObservableCollection<string>(new string[6] { "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized" }.ToList());
        private ObservableCollection<string> lastPings = new ObservableCollection<string>(new string[6] { "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized", "Device Not Initialized" }.ToList());
        public Avalonia.Media.Imaging.Bitmap QRImage
        {
            get => _QRImage;
            set => SetProperty(ref _QRImage, value);
        }
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
        public ObservableCollection<string> LastPings
        {
            get => lastPings;
            set => SetProperty(ref lastPings, value);
        }
        public void SetTest()
        {
            bluetoothBackgroundColors[0] = "Red";
            Text = "WORK";
        }
        public TabletViewModel()
        {
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            var bitmap = new System.Drawing.Bitmap(assets.Open(new Uri("resm:LightMasterMVVM.Assets.LightScoutThick.png")));
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("LRSSQR>862>David Reeves>R1>0000>2", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.FromArgb(15,63,140), Color.White, icon:bitmap, drawQuietZones:false, iconSizePercent:30, iconBorderWidth:10);
            using (MemoryStream memory = new MemoryStream())
            {
                qrCodeImage.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                //AvIrBitmap is our new Avalonia compatible image. You can pass this to your view
                QRImage = new Avalonia.Media.Imaging.Bitmap(memory);
            }

        }

    }
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            
        }
        private int currentMatchNum = 1;
        private string matchNumString = "Match 1";
        private GraphViewModel graphViewModel = new GraphViewModel(new TrackedProperty[0], new TrackedProperty[0]);
        private CompetitionTeamsViewModel competitionTeamsViewModel = new CompetitionTeamsViewModel();
        private TabletViewModel tabletViewModel = new TabletViewModel();
        private NotificationViewModel notificationViewModel = new NotificationViewModel();
        private MatchViewModel matchViewModel = new MatchViewModel();
        private TeamDetailsViewModel teamDetailsViewModel = new TeamDetailsViewModel(-1, OriginalPage.TeamList);
        private CreateGraphViewModel createGraphViewModel = new CreateGraphViewModel();
        private MatchDetailsViewModel matchDetailsViewModel = new MatchDetailsViewModel(1,OriginalPage.TeamList);
        private string _text = "Initial text";
        private TBAViewModel tbaViewModel = new TBAViewModel();
        private bool userControlVisible = false;
        
        public int testInt = 0;
        public int CurrentMatchNum
        {
            get => currentMatchNum;
            set => SetProperty(ref currentMatchNum, value);
        }
        public CreateGraphViewModel CreateGraphViewModel
        {
            get => createGraphViewModel;
            set => SetProperty(ref createGraphViewModel, value);
        }
        public TabletViewModel TabletViewModel
        {
            get => tabletViewModel;
            set => SetProperty(ref tabletViewModel, value);
        }
        public CompetitionTeamsViewModel CompetitionTeamsViewModel
        {
            get => competitionTeamsViewModel;
            set => SetProperty(ref competitionTeamsViewModel, value);
        }
        public NotificationViewModel NotificationViewModel
        {
            get => notificationViewModel;
            set => SetProperty(ref notificationViewModel, value);
        }
        public TBAViewModel TBAViewModel
        {
            get => tbaViewModel;
            set => SetProperty(ref tbaViewModel, value);
        }
        public GraphViewModel GraphViewModel
        {
            get => graphViewModel;
            set => SetProperty(ref graphViewModel, value);
        }
        public TeamDetailsViewModel TeamDetailsViewModel
        {
            get => teamDetailsViewModel;
            set => SetProperty(ref teamDetailsViewModel, value);
        }
        public MatchDetailsViewModel MatchDetailsViewModel
        {
            get => matchDetailsViewModel;
            set => SetProperty(ref matchDetailsViewModel, value);
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
            

            //Task.Run(() => client.Send("{ message }"));
        }
        
        public void GetBluetoothDevices()
        {
            BluetoothClient client = new BluetoothClient();
            List<string> items = new List<string>();
            BluetoothDeviceInfo[] devices = client.DiscoverDevices(255, true, true, true);
            foreach (BluetoothDeviceInfo d in devices)
            {
                items.Add(d.DeviceName);
                Console.WriteLine(d.DeviceName);
            }
            tabletViewModel.TestBTD = items;
        }
        


        public void SeeMatches(int MatchNum)
        {
            GetEventCode eventConfig = new GetEventCode();
            tabletViewModel.UserControlVisible = false;
            matchViewModel.UserControlVisible = true;
            CompetitionTeamsViewModel.UserControlVisible = false;
            TBAViewModel.UserControlVisible = false;
            try
            {
                using (var db = new ScoutingContext())
                {
                    var r1selectedmatch = db.Matches.Where(x => x.TabletId == "R1" && x.EventCode == eventConfig.EventCode() && x.MatchNumber == MatchNum).FirstOrDefault();
                    
                    if (r1selectedmatch == null)
                    {
                        MatchViewModel.Red1CurrentMatch = new TeamMatchView();
                        MatchViewModel.originalR1 = new TeamMatch();
                        MatchViewModel.Red1MatchNotFilled = true;
                        MatchViewModel.Red1MatchEditable = false;
                    }
                    else
                    {
                        var r1TrackedTeam = db.FRCTeams.Find(r1selectedmatch.team_instance_id);
                        MatchViewModel.Red1MatchEditable = true;
                        MatchViewModel.Red1MatchNotFilled = false;
                        MatchViewModel.originalR1 = r1selectedmatch;
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
                        matchtoput.TeamNumber = r1TrackedTeam.team_number;
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
                    var r2selectedmatch = db.Matches.Where(x => x.TabletId == "R2" && x.EventCode == eventConfig.EventCode() && x.MatchNumber == MatchNum).FirstOrDefault();
                    
                    if (r2selectedmatch == null)
                    {
                        MatchViewModel.Red2CurrentMatch = new TeamMatchView();
                        MatchViewModel.originalR2 = new TeamMatch();
                        MatchViewModel.Red2MatchNotFilled = true;
                        MatchViewModel.Red2MatchEditable = false;
                    }
                    else
                    {
                        var r2TrackedTeam = db.FRCTeams.Find(r2selectedmatch.team_instance_id);
                        MatchViewModel.Red2MatchEditable = true;
                        MatchViewModel.Red2MatchNotFilled = false;
                        MatchViewModel.originalR2 = r2selectedmatch;
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
                        matchtoput.TeamNumber = r2TrackedTeam.team_number;
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
                    var r3selectedmatch = db.Matches.Where(x => x.TabletId == "R3" && x.EventCode == eventConfig.EventCode() && x.MatchNumber == MatchNum).FirstOrDefault();
                    
                    if (r3selectedmatch == null)
                    {
                        MatchViewModel.Red3CurrentMatch = new TeamMatchView();
                        MatchViewModel.originalR3 = new TeamMatch();
                        MatchViewModel.Red3MatchNotFilled = true;
                        MatchViewModel.Red3MatchEditable = false;
                    }
                    else
                    {
                        var r3TrackedTeam = db.FRCTeams.Find(r3selectedmatch.team_instance_id);
                        MatchViewModel.Red3MatchNotFilled = false;
                        MatchViewModel.Red3MatchEditable = true;
                        MatchViewModel.originalR3 = r3selectedmatch;
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
                        matchtoput.TeamNumber = r3TrackedTeam.team_number;
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
                    var b1selectedmatch = db.Matches.Where(x => x.TabletId == "B1" && x.EventCode == eventConfig.EventCode() && x.MatchNumber == MatchNum).FirstOrDefault();
                    
                    if (b1selectedmatch == null)
                    {
                        MatchViewModel.Blue1CurrentMatch = new TeamMatchView();
                        MatchViewModel.originalB1 = new TeamMatch();
                        MatchViewModel.Blue1MatchNotFilled = true;
                        MatchViewModel.Blue1MatchEditable = false;
                    }
                    else
                    {
                        var b1TrackedTeam = db.FRCTeams.Find(b1selectedmatch.team_instance_id);
                        MatchViewModel.Blue1MatchNotFilled = false;
                        MatchViewModel.Blue1MatchEditable = true;
                        MatchViewModel.originalB1 = b1selectedmatch;
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
                        matchtoput.TeamNumber = b1TrackedTeam.team_number;
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
                    var b2selectedmatch = db.Matches.Where(x => x.TabletId == "B2" && x.EventCode == eventConfig.EventCode() && x.MatchNumber == MatchNum).FirstOrDefault();
                    
                    if (b2selectedmatch == null)
                    {
                        MatchViewModel.Blue2CurrentMatch = new TeamMatchView();
                        MatchViewModel.originalB2 = new TeamMatch();
                        MatchViewModel.Blue2MatchNotFilled = true;
                        MatchViewModel.Blue2MatchEditable = false;
                    }
                    else
                    {
                        var b2TrackedTeam = db.FRCTeams.Find(b2selectedmatch.team_instance_id);
                        MatchViewModel.Blue2MatchNotFilled = false;
                        MatchViewModel.Blue2MatchEditable = true;
                        MatchViewModel.originalB2 = b2selectedmatch;
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
                        matchtoput.TeamNumber = b2TrackedTeam.team_number;
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
                    var b3selectedmatch = db.Matches.Where(x => x.TabletId == "B3" && x.EventCode == eventConfig.EventCode() && x.MatchNumber == MatchNum).FirstOrDefault();
                    
                    if (b3selectedmatch == null)
                    {
                        MatchViewModel.Blue3CurrentMatch = new TeamMatchView();
                        MatchViewModel.originalB3 = new TeamMatch();
                        MatchViewModel.Blue3MatchNotFilled = true;
                        MatchViewModel.Blue3MatchEditable = false;
                    }
                    else
                    {
                        var b3TrackedTeam = db.FRCTeams.Find(b3selectedmatch.team_instance_id);
                        MatchViewModel.Blue3MatchEditable = true;
                        MatchViewModel.Blue3MatchNotFilled = false;
                        MatchViewModel.originalB3 = b3selectedmatch;
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
                        matchtoput.TeamNumber = b3TrackedTeam.team_number;
                        matchtoput.T_ControlPanelPosition = b3selectedmatch.T_ControlPanelPosition;
                        matchtoput.T_ControlPanelRotation = b3selectedmatch.T_ControlPanelRotation;
                        if (b3selectedmatch.PowerCellMissed != null)
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
            catch (Exception ex)
            {
                MatchViewModel.Red1MatchNotFilled = true;
                MatchViewModel.Red2MatchNotFilled = true;
                MatchViewModel.Red3MatchNotFilled = true;
                MatchViewModel.Blue1MatchNotFilled = true;
                MatchViewModel.Blue2MatchNotFilled = true;
                MatchViewModel.Blue3MatchNotFilled = true;
                MatchViewModel.Red1MatchEditable = false;
                MatchViewModel.Red2MatchEditable = false;
                MatchViewModel.Red3MatchEditable = false;
                MatchViewModel.Blue1MatchEditable = false;
                MatchViewModel.Blue2MatchEditable = false;
                MatchViewModel.Blue3MatchEditable = false;
                MatchViewModel.Red1CurrentMatch = new TeamMatchView();
                MatchViewModel.originalR1 = new TeamMatch();
                MatchViewModel.Red2CurrentMatch = new TeamMatchView();
                MatchViewModel.originalR2 = new TeamMatch();
                MatchViewModel.Red3CurrentMatch = new TeamMatchView();
                MatchViewModel.originalR3 = new TeamMatch();
                MatchViewModel.Blue1CurrentMatch = new TeamMatchView();
                MatchViewModel.originalB1 = new TeamMatch();
                MatchViewModel.Blue2CurrentMatch = new TeamMatchView();
                MatchViewModel.originalB2 = new TeamMatch();
                MatchViewModel.Blue3CurrentMatch = new TeamMatchView();
                MatchViewModel.originalB3 = new TeamMatch();
                Console.WriteLine(ex.ToString());
            }
            GraphViewModel.UserControlVisible = false;

        }
        public void SeeTablets()
        {
            matchViewModel.UserControlVisible = false;
            tabletViewModel.UserControlVisible = true;
            TBAViewModel.UserControlVisible = false;
            GraphViewModel.UserControlVisible = false;
            CompetitionTeamsViewModel.UserControlVisible = false;

            
        }
        public void SeeTBA()
        {
            matchViewModel.UserControlVisible = false;
            tabletViewModel.UserControlVisible = false;
            GraphViewModel.UserControlVisible = false;
            TBAViewModel.UserControlVisible = true;
            CompetitionTeamsViewModel.UserControlVisible = false;

        }
        public void SeeGraph()
        {
            matchViewModel.UserControlVisible = false;
            tabletViewModel.UserControlVisible = false;
            GraphViewModel = new GraphViewModel(new TrackedProperty[0], new TrackedProperty[0]);
            GraphViewModel.UserControlVisible = true;
            TBAViewModel.UserControlVisible = false;
            CompetitionTeamsViewModel.UserControlVisible = false;

        }
        public void SeeTeams()
        {
            matchViewModel.UserControlVisible = false;
            tabletViewModel.UserControlVisible = false;
            GraphViewModel.UserControlVisible = false;
            TBAViewModel.UserControlVisible = false;
            CompetitionTeamsViewModel.UserControlVisible = true;
        }
        
        public void NextMatch()
        {

            CurrentMatchNum++;
            MatchNumString = "Match " + CurrentMatchNum.ToString();
            SeeMatches(CurrentMatchNum);
        }
        public void PrevMatch()
        {
            if (CurrentMatchNum > 1)
            {
                CurrentMatchNum--;
            }
            MatchNumString = "Match " + CurrentMatchNum.ToString();
            SeeMatches(CurrentMatchNum);
        }
    }
}
