using FlaUI.Core.AutomationElements;
using Wpf2Calculators.Specs.Services;

namespace Wpf2Calculators.Specs.CalculatorApp;

public class CalculatorMainWindow<T>
{
    private readonly FlaUIDriver<T> _driver;

    public CalculatorMainWindow(FlaUIDriver<T> driver)
    {
        _driver = driver;
    }

    public void EnterFirstNumber(string number)
    {
        FirstNumberTextBox.Text += number;
    }

    public void EnterSecondNumber(string number)
    {
        SecondNumberTextBox.Text += number;
    }

    public void ClickAdd()
    {
        AddButton.Click();
    }

    public string GetResult()
    {
        return ResultTextBox.Text;
    }

    public TextBox FirstNumberTextBox => _driver.Current.FindFirstDescendant("TextBoxFirst").AsTextBox();
    public TextBox SecondNumberTextBox => _driver.Current.FindFirstDescendant("TextBoxSecond").AsTextBox();
    public TextBox ResultTextBox => _driver.Current.FindFirstDescendant("TextBoxResult").AsTextBox();

    public Button AddButton => _driver.Current.FindFirstDescendant("ButtonAdd").AsButton();
    public Button SubtractButton => _driver.Current.FindFirstDescendant("ButtonSubtract").AsButton();
    public Button MultiplyButton => _driver.Current.FindFirstDescendant("ButtonMultiply").AsButton();
    public Button DivideButton => _driver.Current.FindFirstDescendant("ButtonDivide").AsButton();
}
