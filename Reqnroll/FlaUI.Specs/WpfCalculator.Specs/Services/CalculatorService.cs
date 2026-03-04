using FlaUI.WpfCalculator.Specs.CalculatorApp;

namespace WpfCalculator.Specs.Services;

public interface ICalculatorService
{
    CalculatorMainWindow MainWindow { get; }
}

public class CalculatorService(CalculatorMainWindow mainWindow) : ICalculatorService
{
    public CalculatorMainWindow MainWindow { get; } = mainWindow;
}
