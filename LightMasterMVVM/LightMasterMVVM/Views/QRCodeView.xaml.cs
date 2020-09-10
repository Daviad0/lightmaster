using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LightMasterMVVM.Views
{
    public class QRCodeView : UserControl
    {
        public QRCodeView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
