using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LightMasterMVVM.Scripts;
using LightMasterMVVM.ViewModels;
using LightMasterMVVM.Views;

namespace LightMasterMVVM
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                if(new ConfigurationData().LoadData().TeamNumber != 0)
                {
                    desktop.MainWindow = new MainWindow
                    {

                    };
                }
                else
                {
                    desktop.MainWindow = new SetUpApplication
                    {

                    };
                }
                
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
