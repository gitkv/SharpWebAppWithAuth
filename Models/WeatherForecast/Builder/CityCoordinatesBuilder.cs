using WebAppWithAuth.Models.WeatherForecast.Entity;
using WebAppWithAuth.Models.WeatherForecast.Enum;
using WebAppWithAuth.Models.WeatherForecast.Exception;

namespace WebAppWithAuth.Models.WeatherForecast.Builder
{
    public class CityCoordinatesBuilder
    {
        public static CityCoordinates build(WeatherCitiesEnum city)
        {
            switch (city)
            {
                case WeatherCitiesEnum.Moskow:
                    return new CityCoordinates("Moskow",55.78892895,37.58972168);
            }

            throw new CityIsNotDefined();
        }
    }
}