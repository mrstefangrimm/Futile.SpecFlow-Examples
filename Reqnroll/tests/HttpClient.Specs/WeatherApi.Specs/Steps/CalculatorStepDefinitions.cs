using FluentAssertions;
using Reqnroll;
using WeatherApi.Specs.Services;

namespace WeatherApi.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(WeatherService weatherService)
{
    [Given("forecast from weather api")]
    public void GivenForecastFromWeatherApi()
    {
    }

    [When("api is called")]
    public void WhenApiIsCalled()
    {
    }

    [Then("forecast is in lower letters")]
    public async Task ThenForecastIsInLowerLetters()
    {
        var result = await weatherService.App.GetResult();
        result.Should().NotBeNull();
    }
}
