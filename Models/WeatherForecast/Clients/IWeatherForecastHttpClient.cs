using System.Threading.Tasks;
using WebAppWithAuth.Models.WeatherForecast.Enum;

namespace WebAppWithAuth.Models.WeatherForecast.Clients
{
    public interface IWeatherForecastHttpClient
    {
        public Task<Entity.WeatherForecast> getWeatherByCity(WeatherCitiesEnum city);
    }
}