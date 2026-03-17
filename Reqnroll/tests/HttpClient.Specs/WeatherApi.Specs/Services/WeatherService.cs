using WeatherApi.Specs.App;

namespace WeatherApi.Specs.Services;

public class WeatherService(WeatherApiClient api)
{
    public WeatherApiClient App { get; } = api;
}
