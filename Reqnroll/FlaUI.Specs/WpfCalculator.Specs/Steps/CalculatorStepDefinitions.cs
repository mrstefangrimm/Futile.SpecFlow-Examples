using FlaUI.Core.Tools;
using FluentAssertions;
using Reqnroll;
using WpfCalculator.Specs.Services;

namespace WpfCalculator.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(ICalculatorService calculatorProxy)
{
    private readonly ICalculatorService _pageService = calculatorProxy;

    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int p0)
    {
        _pageService.MainWindow.EnterFirstNumber(p0.ToString());
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int p0)
    {
        _pageService.MainWindow.EnterSecondNumber(p0.ToString());
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
         _pageService.MainWindow.ClickAdd();
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int p0)
    {
        //delegate to Page Object
        var actualResult = _pageService.MainWindow.GetResult();
        var actualInt = double.Parse(actualResult).ToInt();

        actualInt.Should().Be(p0);
    }

}
