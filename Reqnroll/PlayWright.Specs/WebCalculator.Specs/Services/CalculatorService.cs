using ReqnrollTestProject.Pages;

namespace ReqnrollTestProject.Services;

public interface ICalculatorService
{
    CalculatorPage MainPage { get; }
}

public class CalculatorService(CalculatorPage homePage) : ICalculatorService
{
    public CalculatorPage MainPage { get; } = homePage;
}
