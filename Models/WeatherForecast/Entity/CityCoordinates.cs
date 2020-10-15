namespace WebAppWithAuth.Models.WeatherForecast.Entity
{
    public class CityCoordinates
    {
        public string city { get; private set; }
        public double lat { get; private set;  }
        public double lon { get; private set;  }

        public CityCoordinates(string city, double lat, double lon)
        {
            this.city = city;
            this.lat = lat;
            this.lon = lon;
        }
    }
}