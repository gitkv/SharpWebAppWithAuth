using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebAppWithAuth.Models.WeatherForecast.Builder;
using WebAppWithAuth.Models.WeatherForecast.Entity;
using WebAppWithAuth.Models.WeatherForecast.Enum;

namespace WebAppWithAuth.Models.WeatherForecast.Clients.Yandex
{
    public class YandexWeatherForecastClient : IWeatherForecastHttpClient
    {
        private string apiBaseUrl { get; } = "https://api.weather.yandex.ru/";

        private readonly IConfiguration _weatherConfig;

        public YandexWeatherForecastClient(IConfiguration config)
        {
            _weatherConfig = config.GetSection("Weather");
        }

        private string getUri(CityCoordinates cityCoordinates)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return $"/v2/informers?lat={cityCoordinates.lat.ToString(nfi)}&lon={cityCoordinates.lon.ToString(nfi)}";
        }

        public async Task<Entity.WeatherForecast> getWeatherByCity(WeatherCitiesEnum city)
        {
            var cityCoordinates = CityCoordinatesBuilder.build(city);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Add("X-Yandex-API-Key", _weatherConfig["YandexApiKey"]);

                HttpResponseMessage response = await client.GetAsync(getUri(cityCoordinates));
                if (response.IsSuccessStatusCode)
                {
                    dynamic o = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

                    return new Entity.WeatherForecast(cityCoordinates.city, Convert.ToDouble(o.fact.temp));
                }

                throw new HttpRequestException($"returned status code is {response.StatusCode}");
            }
        }
    }
}