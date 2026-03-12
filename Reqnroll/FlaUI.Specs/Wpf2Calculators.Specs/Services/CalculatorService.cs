using Reqnroll.Amp;
using Wpf2Calculators.Specs.App;

namespace Wpf2Calculators.Specs.Services;

public interface ICalculatorService<N>
{
    void SwitchProfile();
    CalculatorMainWindow<N> MainWindow { get; }
}

public class CalculatorServiceOne(CalculatorMainWindow<Ports.One> mainWindow, FlaUIDriver<Ports.One> driver) : ICalculatorService<Ports.One>
{
    public CalculatorMainWindow<Ports.One> MainWindow { get; } = mainWindow;

    public void SwitchProfile()
    {
        driver.SwitchProfile("Calculator One");
    }
}

public class CalculatorServiceTwo(CalculatorMainWindow<Ports.Two> mainWindow, FlaUIDriver<Ports.Two> driver) : ICalculatorService<Ports.Two>
{
    public CalculatorMainWindow<Ports.Two> MainWindow { get; } = mainWindow;

    public void SwitchProfile()
    {
        driver.SwitchProfile("Calculator Two");
    }
}
