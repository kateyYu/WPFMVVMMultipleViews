﻿using Egor92.MvvmNavigation.Abstractions;
using System.Windows.Input;
using WPFMVVMMultipleViews.Constants;
using WPFMVVMMultipleViews.Commands;

namespace WPFMVVMMultipleViews.ViewModels
{
    public class MeterToFeetViewModel : BaseViewModel, INavigatedToAware
    {
        const double METER_FEET = 3.28;
        #region Fields

        private readonly INavigationManager _navigationManager;

        #endregion

        #region Construction

        public MeterToFeetViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }
        #endregion

        #region PassedParameter

        private string _passedParameter;

        public string PassedParameter
        {
            get { return _passedParameter; }
            set { SetProperty(ref _passedParameter, value); }
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
            _navigationManager.Navigate(NavigationKeys.FeetToMeter, PassedParameter);
        }

        public void OnNavigatedTo(object arg)
        {
            if (!(arg is string))
                return;

            PassedParameter = (string)arg;
        }

        #endregion

        #region Calc

        #endregion
    }
}
