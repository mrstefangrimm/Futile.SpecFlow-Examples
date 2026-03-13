using WebCalculator.Specs.App;

namespace ReqnrollTestProject.Services;

public interface ICalculatorService
{
    HomePage MainPage { get; }
}

public class CalculatorService(HomePage homePage) : ICalculatorService
{
    public HomePage MainPage { get; } = homePage;
}
