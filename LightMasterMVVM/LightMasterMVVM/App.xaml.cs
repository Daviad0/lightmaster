using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LightMasterMVVM.Models;
using LightMasterMVVM.Scripts;
using LightMasterMVVM.ViewModels;
using LightMasterMVVM.Views;
using System.Security.Policy;

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
            var previousconfigfile = new ConfigurationData().LoadData();
            ApplicationState.DBPasswordUsed = previousconfigfile.Database.Password;
            ApplicationState.DBUsernameUsed = previousconfigfile.Database.Username;
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
