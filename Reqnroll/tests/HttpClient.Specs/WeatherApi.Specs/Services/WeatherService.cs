using WeatherApi.Specs.App;

namespace WeatherApi.Specs.Services;

public interface IWeatherService
{
    WeatherApp App { get; }
}

public class WeatherService(WeatherApp api) : IWeatherService
{
    public WeatherApp App { get; } = api;
}
