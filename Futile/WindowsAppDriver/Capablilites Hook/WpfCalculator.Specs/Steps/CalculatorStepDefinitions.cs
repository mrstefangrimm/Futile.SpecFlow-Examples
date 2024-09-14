using FluentAssertions;
using WpfCalculator.Specs.CalculatorApp;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace WpfCalculator.Specs.Steps;

[Binding]
public sealed class CalculatorStepDefinitions {
  private readonly CalculatorForm _calculatorForm;

  public CalculatorStepDefinitions(CalculatorForm calculatorForm) {
    _calculatorForm = calculatorForm;
  }

  [Given(@"no command line arguments")]
  public void GivenNoCommandLineArguments() {
    Hooks.AppDriverCliEx.StartEx(new KeyValuePair<string, string>[0]);
  }

  [Given(@"command line arguments")]
  public void GivenCommandLineArguments() {
    KeyValuePair<string, string>[] args = new[] { KeyValuePair.Create("appArguments", "Test Test") };
    Hooks.AppDriverCliEx.StartEx(args);
  }

  [Given("the first number is (.*)")]
  public void GivenTheFirstNumberIs(int number) {
    _calculatorForm.EnterFirstNumber(number.ToString());
  }

  [Given("the second number is (.*)")]
  public void GivenTheSecondNumberIs(int number) {
    _calculatorForm.EnterSecondNumber(number.ToString());
  }

  [When("the two numbers are added")]
  public void WhenTheTwoNumbersAreAdded() {
    _calculatorForm.ClickAdd();
  }

  [When(@"the two numbers are subtracted")]
  public void WhenTheTwoNumbersAreSubtracted() {
    _calculatorForm.ClickSubtract();
  }

  [When(@"the two numbers are multiplied")]
  public void WhenTheTwoNumbersAreMultiplied() {
    _calculatorForm.ClickMultiply();
  }

  [When(@"the two numbers are divided")]
  public void WhenTheTwoNumbersAreDivided() {
    _calculatorForm.ClickDivide();
  }

  [Then("the result should be (.*)")]
  public void ThenTheResultShouldBe(int result) {
    var actualResult = int.Parse(_calculatorForm.GetResult());

    result.Should().Be(actualResult);
  }

  [Then(@"the command line is shown")]
  public void ThenTheCommandLineIsShown() {
    var result = _calculatorForm.CommandlineArgumentsLabel.Text;
    result.Should().Be("Test Test");
  }

}