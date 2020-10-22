namespace WebAppWithAuth.Models.WeatherForecast.Entity
{
    public class CityCoordinates
    {
        public string city { get; }
        public double lat { get; }
        public double lon { get; }

        public CityCoordinates(string city, double lat, double lon)
        {
            this.city = city;
            this.lat = lat;
            this.lon = lon;
        }
    }
}