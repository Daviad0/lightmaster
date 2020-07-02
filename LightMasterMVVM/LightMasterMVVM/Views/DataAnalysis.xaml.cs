using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LightMasterMVVM.Views
{
    public class DataAnalysis : UserControl
    {
        public DataAnalysis()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
