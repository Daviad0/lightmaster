using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace LightMasterMVVM.Views
{
    public class ConfirmDialogue : Window
    {
        private Button close_window = new Button();
        private Button cancel_request = new Button();
        private SetUpApplication referringWindow;
        public ConfirmDialogue()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            close_window = this.Find<Button>("HideWindow");
            close_window.Click += Close_window_Click;
            cancel_request = this.Find<Button>("Cancel");
            cancel_request.Click += Cancel_request_Click; ;
            this.ClientSize = new Size(360, 160);
            this.HasSystemDecorations = false;
            this.PointerPressed += ConfirmationNotice_PointerPressed;
            //referringWindow = windowtoclose;
        }

        private void Cancel_request_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void ConfirmationNotice_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }
        private void Close_window_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
            IClassicDesktopStyleApplicationLifetime desktop = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;
            desktop.MainWindow.Close();
            desktop.Shutdown();
        }
    }
}
