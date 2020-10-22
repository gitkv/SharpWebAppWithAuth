namespace WebAppWithAuth.Models.WeatherForecast.Entity
{
    public class WeatherForecast
    {
        public string city { get; }
        public double temperature { get; }
        
        public WeatherForecast(string city, double temperature)
        {
            this.city = city;
            this.temperature = temperature;
        }
    }
}