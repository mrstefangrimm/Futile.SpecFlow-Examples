using FluentAssertions;
using Reqnroll;
using WeatherApi.Specs.Services;

namespace WeatherApi.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(IWeatherService calculatorProxy)
{
    private readonly IWeatherService _service = calculatorProxy;

    [Given("forecast from weather api")]
    public void GivenForecastFromWeatherApi()
    {
    }

    [When("api is called")]
    public void WhenApiIsCalled()
    {
    }

    [Then("forcast is in lower letters")]
    public async Task ThenForcastIsInLowerLetters()
    {
        var result = await _service.App.GetResult();
        result.Should().NotBeNull();
    }
}
