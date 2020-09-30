using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LightMasterMVVM.Models;
using System;

namespace LightMasterMVVM.Views
{
    public class SignIn : Window
    {
        private Button close_window = new Button();
        private Button finish_setup = new Button();
        public SignIn()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            close_window = this.Find<Button>("HideWindow");
            close_window.Click += Close_window_Click;
            finish_setup = this.Find<Button>("FinishApplication");
            finish_setup.IsEnabled = false;
            finish_setup.Click += Finish_setup_Click;
            this.CanResize = false;
            this.ClientSize = new Size(450, 300);
            this.HasSystemDecorations = false;
            
            this.PointerPressed += SignIn_PointerPressed;
        }

        private void Finish_setup_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
            ApplicationState.DBUsernameUsed = "strategy_member";
            ApplicationState.DBPasswordUsed = "strategy";
            ApplicationState.PushDBCreds();
        }

        private void SignIn_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }
        private void Close_window_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
