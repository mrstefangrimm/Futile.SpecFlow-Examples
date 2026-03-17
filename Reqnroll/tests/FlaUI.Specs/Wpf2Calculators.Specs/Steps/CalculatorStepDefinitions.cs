using FlaUI.Core.Tools;
using FluentAssertions;
using Reqnroll;
using Wpf2Calculators.Specs.Services;

namespace Wpf2Calculators.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(ICalculatorService<Ports.One> calculatorOne, ICalculatorService<Ports.Two> calculatorTwo)
{
    private readonly ICalculatorService<Ports.One> _calculatorOne = calculatorOne;
    private readonly ICalculatorService<Ports.Two> _calculatorTwo = calculatorTwo;

    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int p0)
    {
        _calculatorOne.SwitchProfile();
        _calculatorTwo.SwitchProfile();

        _calculatorOne.MainWindow.EnterFirstNumber(p0.ToString());
        _calculatorTwo.MainWindow.EnterFirstNumber(p0.ToString());
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int p0)
    {
        _calculatorOne.MainWindow.EnterSecondNumber(p0.ToString());
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _calculatorOne.MainWindow.ClickAdd();
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int p0)
    {
        var actualResult = _calculatorOne.MainWindow.GetResult();
        var actualInt = double.Parse(actualResult).ToInt();

        actualInt.Should().Be(p0);
    }
}
