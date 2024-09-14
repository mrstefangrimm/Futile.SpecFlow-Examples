﻿using Futile.Specflow.Actions.FlaUI;

namespace FlaUI.WpfCalculator.Specs.CalculatorApp;

internal class CalculatorProxy
{
    private readonly FlaUIDriver _driver;
    private readonly CalculatorMainWindowElements _elements;

    public CalculatorProxy(FlaUIDriver driver)
    {
        _driver = driver;
        _elements = new CalculatorMainWindowElements(driver);
    }

    public void SelectProfile(string profileName)
    {
        _driver.SwitchProfile(profileName);
    }

    public void EnterFirstNumber(string number)
    {
        _elements.FirstNumberTextBox.Text += number;
    }

    public void EnterSecondNumber(string number)
    {
        _elements.SecondNumberTextBox.Text += number;
    }

    public void ClickAdd()
    {
        _elements.AddButton.Click();
    }

    public void ClickSubtract()
    {
        _elements.SubtractButton.Click();
    }

    public void ClickMultiply()
    {
        _elements.MultiplyButton.Click();
    }

    public void ClickDivide()
    {
        _elements.DivideButton.Click();
    }

    public string GetResult()
    {
        return _elements.ResultTextBox.Text;
    }
}