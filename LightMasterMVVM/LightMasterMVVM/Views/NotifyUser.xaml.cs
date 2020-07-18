using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LightMasterMVVM.Views
{
    public class NotifyUser : UserControl
    {
        public NotifyUser()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
