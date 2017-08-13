namespace DegreeConverterV2.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        string _kelvin;
        string _fahrenheit;
        string _Celsius;

        
        #endregion

        #region Properties
        public string Celsius
        {
            get
            {
                return _Celsius;
            }
            set
            {
                if (value != _Celsius)
                {
                    _Celsius= value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Celsius)));
                }
            }
        }
        public string Kelvin
        {
            get
            {
                return _kelvin;
            }
            set
            {
                if (value != _kelvin) {
                    _kelvin = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kelvin)));
                }
            }
        }
        public string Fahrenheit
        {
            get
            {
                return _fahrenheit;
            }
            set
            {
                if (value != _fahrenheit)
                {
                    _fahrenheit = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fahrenheit)));
                }
            }
        }
        #endregion
        
        #region Constructors
        public MainViewModel()
        {

        }
        #endregion
        
        #region Command
        public ICommand ConvertCommand
        {
            get { return new RelayCommand(_Convert); }
        }

        async void _Convert() {
            if (string.IsNullOrEmpty(Celsius))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a numeric value in Celsius...", "Accept");
                return;
            }

            decimal celsius = 0;
            if (!decimal.TryParse(Celsius, out celsius))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a numeric value in Celsius...", "Accept");
                return;
            }

            var fahrenheit = (9 * Convert.ToDouble(celsius) / 5) + 32;
            var kelvin = Convert.ToDouble(celsius) + 273.15;

            Kelvin = String.Format("{0} °K", kelvin);
            Fahrenheit = String.Format("{0} °F", fahrenheit);
        }

        public ICommand CleanCommand
        {
            get { return new RelayCommand(_Clean); }
        }

        private void _Clean()
        {
            Kelvin = null;
            Fahrenheit = null;
            Celsius = null;
        }
        #endregion
    }
}
