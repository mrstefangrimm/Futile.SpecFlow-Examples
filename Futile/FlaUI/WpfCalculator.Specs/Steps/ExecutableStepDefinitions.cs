using FlaUI.WpfCalculator.Specs.CalculatorApp;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace FlaUI.WpfCalculator.Specs.Steps;

[Binding]
internal sealed class ExecutableStepDefinitions
{
    private readonly CalculatorProxy _proxy;

    public ExecutableStepDefinitions(CalculatorProxy proxy)
    {
        _proxy = proxy;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        _proxy.EnterFirstNumber(number.ToString());
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        _proxy.EnterSecondNumber(number.ToString());
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _proxy.ClickAdd();
    }

    [When(@"the two numbers are subtracted")]
    public void WhenTheTwoNumbersAreSubtracted()
    {
        _proxy.ClickSubtract();
    }

    [When(@"the two numbers are multiplied")]
    public void WhenTheTwoNumbersAreMultiplied()
    {
        _proxy.ClickMultiply();
    }

    [When(@"the two numbers are divided")]
    public void WhenTheTwoNumbersAreDivided()
    {
        _proxy.ClickDivide();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        var actualResult = double.Parse(_proxy.GetResult());

        result.Should().Be((int)actualResult);
    }
}