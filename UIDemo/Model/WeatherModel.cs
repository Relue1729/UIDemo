using System.Collections.Generic;
using System.Threading.Tasks;
using UIDemo.Common;
using UIDemo.Common.Interfaces;

namespace UIDemo.Model
{
    class WeatherModel : IModel
    {
        public IDictionary<string, string> Labels => new Dictionary<string,string>();

        public const string PathToIcons     = "/Assets/Images/Weather/";
        public const string DefaultIconName = "Clouds.png";

        public struct WeatherData
        {
            public float?  Temperature { get; set; }
            public string Description { get; set; }
            public WeatherData(float? Temperature, string Description)
            {
                this.Temperature = Temperature;
                this.Description = Description;
            }
        }
        public async Task<string> GetCityFromApi()
        {
            var apiLink = $"http://api.ipstack.com/check?access_key=83bd50db42dc2dcc6858342a24113210";
            var apiResponce = await ApiHandler.GetDynamicJObjectFromApi(apiLink);
            return apiResponce.city ?? "London";
        }
        public async Task<WeatherData> GetWeatherInfoFromApi(string city = "London")
        {
            var apiLink = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=742f72f0dbab8e81bc1a22165e7820da&units=metric";
            var apiResponce = await ApiHandler.GetDynamicJObjectFromApi(apiLink);
            return new WeatherData((float?)apiResponce.main.temp, (string)apiResponce.weather[0].main);
        }
    }
}