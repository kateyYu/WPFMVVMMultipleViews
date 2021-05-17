using Egor92.MvvmNavigation.Abstractions;
using System.Windows.Input;
using WPFMVVMMultipleViews.Commands;
using WPFMVVMMultipleViews.Constants;

namespace WPFMVVMMultipleViews.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region Fields

        private readonly INavigationManager _navigationManager;

        #endregion

        #region Construction

        public LoginViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        #endregion

        #region Parameter

        private string _parameter;

        public string Parameter
        {
            get { return _parameter; }
            set { SetProperty(ref _parameter, value); }
        }

        #endregion

        #region GoMainView

        private ICommand _goMainView;

        public ICommand GoMainView
        {
            get { return _goMainView ?? (_goMainView = new DelegateCommand(GoNext)); }
        }


        private void GoNext()
        {
            _navigationManager.Navigate(NavigationKeys.MeterToFeet, Parameter);
        }

        #endregion
    }
}
