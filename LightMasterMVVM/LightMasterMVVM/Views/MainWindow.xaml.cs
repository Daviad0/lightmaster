using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using LightMasterMVVM.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;

namespace LightMasterMVVM.Views
{
    public class MainWindow : Window
    {
        private MainWindowViewModel control = new MainWindowViewModel();
        private Button nav_see_matches = new Button();
        private Button nav_see_graph = new Button();
        private Button nav_see_tablets = new Button();
        private Button nav_see_tba = new Button();
        private Button nav_try_usb = new Button();
        private Button nav_see_teams = new Button();
        private Border matches = new Border();
        private Border graph = new Border();
        private Border tablets = new Border();
        private Border tba = new Border();
        private Border teams = new Border();
        private string previouslySelectedName = "seeTablets";
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif      
            nav_see_matches = this.Find<Button>("seeMatches");
            nav_see_matches.Click += NavigationChange;
            nav_see_graph = this.Find<Button>("seeGraph");
            nav_see_graph.Click += NavigationChange;
            nav_see_tablets = this.Find<Button>("seeTablets");
            nav_see_tablets.Click += NavigationChange;
            nav_see_tba = this.Find<Button>("seeTBA");
            nav_see_tba.Click += NavigationChange;
            nav_try_usb = this.Find<Button>("tryUSB");
            nav_try_usb.Click += TryUSB;
            nav_see_teams = this.Find<Button>("seeTeams");
            nav_see_teams.Click += NavigationChange;
            matches = this.Find<Border>("matches");
            graph = this.Find<Border>("graphs");
            tablets = this.Find<Border>("tablets");
            tba = this.Find<Border>("tba");
            teams = this.Find<Border>("teams");
            DataContext = control;
            
        }

        private async void NavigationChange(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Button pressedButton = sender as Button;
            if(previouslySelectedName != pressedButton.Name)
            {
                matches.Classes.Remove("show");
                graph.Classes.Remove("show");
                tablets.Classes.Remove("show");
                tba.Classes.Remove("show");
                teams.Classes.Remove("show");
                matches.Classes.Add("hide");
                graph.Classes.Add("hide");
                tablets.Classes.Add("hide");
                tba.Classes.Add("hide");
                teams.Classes.Add("hide");
                await Task.Delay(100);
                matches.Opacity = 0;
                graph.Opacity = 0;
                tablets.Opacity = 0;
                tba.Opacity = 0;
                teams.Opacity = 0;
                matches.IsVisible = false;
                graph.IsVisible = false;
                tablets.IsVisible = false;
                tba.IsVisible = false;
                teams.IsVisible = false;
                await Task.Delay(50);
                switch (pressedButton.Name)
                {
                    case "seeMatches":
                        matches.IsVisible = true;
                        matches.Classes.Remove("hide");
                        matches.Classes.Add("show");
                        await Task.Delay(100);
                        matches.Opacity = 1;
                        break;
                    case "seeGraph":
                        graph.IsVisible = true;
                        graph.Classes.Remove("hide");
                        graph.Classes.Add("show");
                        await Task.Delay(100);
                        graph.Opacity = 1;
                        break;
                    case "seeTablets":
                        tablets.IsVisible = true;
                        tablets.Classes.Remove("hide");
                        tablets.Classes.Add("show");
                        await Task.Delay(100);
                        tablets.Opacity = 1;
                        break;
                    case "seeTBA":
                        tba.IsVisible = true;
                        tba.Classes.Remove("hide");
                        tba.Classes.Add("show");
                        await Task.Delay(100);
                        tba.Opacity = 1;
                        break;
                    case "seeTeams":
                        teams.IsVisible = true;
                        teams.Classes.Remove("hide");
                        teams.Classes.Add("show");
                        await Task.Delay(100);
                        teams.Opacity = 1;
                        break;
                }
                previouslySelectedName = pressedButton.Name;
            }
        }
        private async void TryUSB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            control.TryUSB();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
        }
    }
}
