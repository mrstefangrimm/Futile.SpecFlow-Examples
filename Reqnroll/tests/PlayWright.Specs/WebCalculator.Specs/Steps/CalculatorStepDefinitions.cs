using FluentAssertions;
using Reqnroll;
using Reqnroll.Amp;
using WebCalculator.Specs.Services;

namespace WebCalculator.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(ICalculatorService calculatorService, PlayWrightDriver driver)
{
    [Given("headless profile is selected")]
    public void GivenHeadlessProfieIsSelected()
    {
        driver.SelectProfile("Futile Calculator headless");
    }

    [Given("profile is selected with slowmo")]
    public void GivenProfileIsSelectedWithSlowmo()
    {
        driver.SelectProfile("Futile Calculator slowmo");
    }

    [Given("the first number is {int}")]
    public async Task GivenTheFirstNumberIs(int p0)
    {
        await calculatorService.MainPage.EnterFirstNumberAsync(p0.ToString());
    }

    [Given("the second number is {int}")]
    public async Task GivenTheSecondNumberIs(int p0)
    {
        await calculatorService.MainPage.EnterSecondNumberAsync(p0.ToString());
    }

    [When("the two numbers are added")]
    public async Task WhenTheTwoNumbersAreAdded()
    {
        await calculatorService.MainPage.ClickAddAsync();
    }

    [Then("the result should be {int}")]
    public async Task ThenTheResultShouldBe(int p0)
    {
        var actualResult = await calculatorService.MainPage.WaitForNonEmptyResultAsync();

        actualResult.Should().Be(p0.ToString());
    }
}
