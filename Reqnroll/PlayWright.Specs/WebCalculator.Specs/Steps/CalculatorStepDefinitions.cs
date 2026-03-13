using FluentAssertions;
using Reqnroll;
using WebCalculator.Specs.Services;

namespace WebCalculator.Specs.Steps;

[Binding]
public class CalculatorStepDefinitions(ICalculatorService pageService)
{
  private readonly ICalculatorService _pageService = pageService;

  [Given("the first number is {int}")]
  public async Task GivenTheFirstNumberIs(int p0)
  {
    await _pageService.MainPage.EnterFirstNumberAsync(p0.ToString());
  }

  [Given("the second number is {int}")]
  public async Task GivenTheSecondNumberIs(int p0)
  {
    await _pageService.MainPage.EnterSecondNumberAsync(p0.ToString());
  }

  [When("the two numbers are added")]
  public async Task WhenTheTwoNumbersAreAdded()
  {
    await _pageService.MainPage.ClickAddAsync();
  }

  [Then("the result should be {int}")]
  public async Task ThenTheResultShouldBe(int p0)
  {
    //delegate to Page Object
    var actualResult = await _pageService.MainPage.WaitForNonEmptyResultAsync();

    actualResult.Should().Be(p0.ToString());
  }

}
