using Wpf2Calculators.Specs.CalculatorApp;

namespace Wpf2Calculators.Specs.Services;

public interface ICalculatorService
{
    void SwitchProfile();
}

public interface ICalculatorServiceOne : ICalculatorService
{
    void SwitchProfile();
    CalculatorMainWindow<ICalculatorServiceOne> MainWindow { get; }
}

public interface ICalculatorServiceTwo : ICalculatorService
{
    void SwitchProfile();
    CalculatorMainWindow<ICalculatorServiceTwo> MainWindow { get; }
}

public class CalculatorServiceOne(CalculatorMainWindow<ICalculatorServiceOne> mainWindow, FlaUIDriver<ICalculatorServiceTwo> driver) : ICalculatorServiceOne
{
    public CalculatorMainWindow<ICalculatorServiceOne> MainWindow { get; } = mainWindow;

    public void SwitchProfile()
    {
        driver.SwitchProfile("Calculator One");
    }
}

public class CalculatorServiceTwo(CalculatorMainWindow<ICalculatorServiceTwo> mainWindow, FlaUIDriver<ICalculatorServiceTwo> driver) : ICalculatorServiceTwo
{
    public CalculatorMainWindow<ICalculatorServiceTwo> MainWindow { get; } = mainWindow;

    public void SwitchProfile()
    {
        driver.SwitchProfile("Calculator Two");
    }
}
