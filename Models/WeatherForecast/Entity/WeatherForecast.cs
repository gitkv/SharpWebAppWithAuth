namespace WebAppWithAuth.Models.WeatherForecast.Entity
{
    public class WeatherForecast
    {
        private string city { get; }
        private double temperature { get; }
        
        public WeatherForecast(string city, double temperature)
        {
            this.city = city;
            this.temperature = temperature;
        }
    }
}