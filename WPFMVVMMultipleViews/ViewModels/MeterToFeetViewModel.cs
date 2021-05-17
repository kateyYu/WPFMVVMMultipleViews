using Egor92.MvvmNavigation.Abstractions;
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

        #region Properties
        private double _inputValue = 1;

        public double InputValue
        {
            get { return _inputValue; }
            set
            {
                SetProperty(ref _inputValue, value);
                Calc();
            }
        }

        private double _convertToValue = METER_FEET;

        public double ConvertToValue
        {
            get { return _convertToValue; }
            set
            {
                SetProperty(ref _convertToValue, value);
            }
        }
        #endregion

        #region Calc
        public void Calc()
        {
            ConvertToValue = InputValue * METER_FEET;
        }
        #endregion
    }
}
