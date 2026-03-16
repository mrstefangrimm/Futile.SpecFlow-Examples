using WeatherApi.Specs.App;

namespace WeatherApi.Specs.Services;

public interface IWeatherService
{
    WeatherApiClient App { get; }
}

public class WeatherService(WeatherApiClient api) : IWeatherService
{
    public WeatherApiClient App { get; } = api;
}
