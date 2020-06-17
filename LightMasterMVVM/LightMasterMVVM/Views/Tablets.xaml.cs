using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LightMasterMVVM.Views
{
    public class Tablets : UserControl
    {
        public Tablets()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
