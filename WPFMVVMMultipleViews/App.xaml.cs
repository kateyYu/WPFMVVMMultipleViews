using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using System.Windows;
using WPFMVVMMultipleViews.Constants;
using WPFMVVMMultipleViews.ViewModels;
using WPFMVVMMultipleViews.Views;

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
