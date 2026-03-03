using ReqnrollTestProject.Pages;

namespace ReqnrollTestProject.Services;

public interface ICalculatorPagesService
{
    CalculatorPage MainPage { get; }
}

public class CalculatorService(CalculatorPage homePage) : ICalculatorPagesService
{
    public CalculatorPage MainPage { get; } = homePage;
}
