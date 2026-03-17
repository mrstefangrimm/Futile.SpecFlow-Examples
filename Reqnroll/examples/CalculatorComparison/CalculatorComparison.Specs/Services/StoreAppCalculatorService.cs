using CalculatorComparison.Specs.Apps;
using Reqnroll.Amp;

namespace CalculatorComparison.Specs.Services;

public class StoreAppCalculatorService(StoreAppCalculatorMainWindow mainWindow, FlaUIDriver<Ports.Windows> driver)
{
    public StoreAppCalculatorMainWindow MainWindow { get; } = mainWindow;

    public void SelectWindowsCalculator()
    {
        driver.SelectProfile("Windows Calculator");
    }
}
