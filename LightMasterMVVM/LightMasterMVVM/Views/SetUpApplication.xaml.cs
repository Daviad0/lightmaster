using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LightMasterMVVM.Scripts;
using System;
using System.Security.Cryptography;

namespace LightMasterMVVM.Views
{
    public class SetUpApplication : Window
    {
        private Button close_window = new Button();
        private Button finish_setup = new Button();
        private TextBox teamNumberInput = new TextBox();
        private TextBox keyScouterInput = new TextBox();
        private TextBox eventCodeInput = new TextBox();
        public SetUpApplication()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.CanResize = false;
            this.ClientSize = new Size(500, 500);
            this.HasSystemDecorations = false;
            close_window = this.Find<Button>("HideWindow");
            close_window.Click += Close_window_Click;
            finish_setup = this.Find<Button>("FinishApplication");
            finish_setup.IsEnabled = false;
            finish_setup.Click += Finish_setup_Click;
            teamNumberInput = this.Find<TextBox>("teamNumberInput");
            teamNumberInput.GetObservable(TextBox.TextProperty).Subscribe(text => { FormInputChanged(); });
            keyScouterInput = this.Find<TextBox>("keyScouterInput");
            keyScouterInput.GetObservable(TextBox.TextProperty).Subscribe(text => { FormInputChanged(); });
            eventCodeInput = this.Find<TextBox>("eventCodeInput");
            eventCodeInput.GetObservable(TextBox.TextProperty).Subscribe(text => { FormInputChanged(); });
            keyScouterInput.BorderBrush = Brush.Parse("#2a7afa");
            eventCodeInput.BorderBrush = Brush.Parse("#2a7afa");
            teamNumberInput.BorderBrush = Brush.Parse("#2a7afa");
            keyScouterInput.Foreground = Brush.Parse("#2a7afa");
            eventCodeInput.Foreground = Brush.Parse("#2a7afa");
            teamNumberInput.Foreground = Brush.Parse("#2a7afa");
            this.PointerPressed += SetUpApplication_PointerPressed;
        }

        private void FormInputChanged()
        {
            var formvalid = true;
            if(keyScouterInput.Text == null || keyScouterInput.Text == "")
            {
                formvalid = false;
                keyScouterInput.BorderBrush = Brush.Parse("#ff1919");
                keyScouterInput.Foreground = Brush.Parse("#ff1919");
            }
            else
            {
                keyScouterInput.BorderBrush = Brush.Parse("#2a7afa");
                keyScouterInput.Foreground = Brush.Parse("#2a7afa");
            }
            if (eventCodeInput.Text == null || eventCodeInput.Text == "")
            {
                formvalid = false;
                eventCodeInput.BorderBrush = Brush.Parse("#ff1919");
                eventCodeInput.Foreground = Brush.Parse("#ff1919");
            }
            else
            {
                eventCodeInput.BorderBrush = Brush.Parse("#2a7afa");
                eventCodeInput.Foreground = Brush.Parse("#2a7afa");
            }
            try
            {
                int.Parse(teamNumberInput.Text);
                teamNumberInput.BorderBrush = Brush.Parse("#2a7afa");
                teamNumberInput.Foreground = Brush.Parse("#2a7afa");
            }
            catch(Exception ex)
            {
                formvalid = false;
                teamNumberInput.BorderBrush = Brush.Parse("#ff1919");
                teamNumberInput.Foreground = Brush.Parse("#ff1919");
            }
            if (formvalid)
            {
                finish_setup.IsEnabled = true;
            }
            else
            {
                finish_setup.IsEnabled = false;
            }
        }

        private void Finish_setup_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var mainwindow = new MainWindow();
            IClassicDesktopStyleApplicationLifetime desktop = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;
            desktop.MainWindow = mainwindow;
            
            var configdatafile = new ConfigurationData();
            configdatafile.SaveData("TeamNumber", int.Parse(teamNumberInput.Text));
            configdatafile.SaveData("KeyScouter", keyScouterInput.Text);
            configdatafile.SaveData("EventCode", eventCodeInput.Text);
            this.Hide();
            mainwindow.Show();
            mainwindow.WindowState = WindowState.Maximized;

        }

        private void SetUpApplication_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }

        private void Close_window_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var confirmationtoclose = new ConfirmDialogue();
            confirmationtoclose.ShowDialog(this);
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}
