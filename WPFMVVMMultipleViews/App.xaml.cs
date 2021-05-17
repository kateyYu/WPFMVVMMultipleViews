using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMMultipleViews.Views;
using WPFMVVMMultipleViews.Constants;
using WPFMVVMMultipleViews.ViewModels;
using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;

namespace WPFMVVMMultipleViews
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var navigationManager = new NavigationManager(mainWindow);
            navigationManager.Register<LoginView>(NavigationKeys.Login, () => new LoginViewModel(navigationManager));
            navigationManager.Register<MeterToFeetView>(NavigationKeys.MeterToFeet, () => new MeterToFeetViewModel(navigationManager));
            navigationManager.Register<FeetToMeterView>(NavigationKeys.FeetToMeter, () => new FeetToMeterViewModel(navigationManager));

            mainWindow.Show();
            navigationManager.Navigate(NavigationKeys.Login);
        }
    }
}
