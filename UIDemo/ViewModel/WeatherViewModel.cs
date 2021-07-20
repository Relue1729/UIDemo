using System.Threading.Tasks;
using UIDemo.Common;
using UIDemo.Common.Interfaces;
using UIDemo.Model;
using static UIDemo.Model.WeatherModel;

namespace UIDemo.ViewModel
{
    class WeatherViewModel : ViewModelBase
    {
        #region Fields & Properties 
        public override IModel Model { get; } = new WeatherModel();

        private WeatherData weatherData;

        private string city = "Город не определен";
        public string City
        {
            get => city;
            private set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        private string weatherInfoString = "N/A";
        public string WeatherInfoString
        {
            get => weatherInfoString;
            private set
            {
                weatherInfoString = value;
                OnPropertyChanged();
            }
        }
        private string weatherIconPath = $"{PathToIcons}{DefaultIconName}";
        public string WeatherIconPath
        {
            get => weatherIconPath;
            set
            {
                if (HelperFunctions.IsFileInResources($"{PathToIcons}{value}.png"))
                {
                       weatherIconPath = $"{PathToIcons}{value}.png";
                }
                else { weatherIconPath = $"{PathToIcons}{DefaultIconName}"; }
                OnPropertyChanged();
            }
        }
        #endregion
        public WeatherViewModel()
        {
            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            City            = await (Model as WeatherModel).GetCityFromApi();
            weatherData     = await (Model as WeatherModel).GetWeatherInfoFromApi(City);
            WeatherIconPath = weatherData.Description;

            var temperature = (int?)weatherData.Temperature;
            var description = weatherData.Description;
            if (description is null && temperature is null) 
            {
                WeatherInfoString = "N/A";
            }
            else
            {
                WeatherInfoString = string.Empty;
                WeatherInfoString += temperature is null ? "" : $"{temperature}° ";
                WeatherInfoString += description is null ? "" : $"{description}";
            }
        }
    }
}