<table border="0">
  <tr>
    <td><img src="res/rnramp-logo.png" width="80"></td>
    <td><h1>Reqnroll.Amp</h1></td>
  </tr>
</table>

Reqnroll.Amp is a class library that boosts (amplifies) your test‑writing. Reqnroll is BDD testing environment for C#. Reqnroll.Amp is a tiny class library on top of Reqnroll.



## Features:

- Support for Windows application E2E testing
- Support for Web application E2E testing
- Support for Web API  E2E testing
- Test profiles which can be selected at runtime
- Support of multiple applications under test



## Getting Started

The e2e tests in `test` are best suited to get started. The source code contains tests for all of the features listed above.

| Test Project | Feature | Description | Link |
| -- | -- | -- | -- |
| WebCalculator.Specs | PlayWrightMinimal | Tests the online calculator https://futile-calculator.netlify.app/ | github/ |
| WebCalculator.Specs | PlayWrightProfile | Tests the online calculator with different profiles (e.g. testing in slow motion) | github/ |
| WebCalculator.Specs | PlayWrightProfile | Tests the online calculator with a command line argument that is defined in the test (i.e. as a variable) | github/ |
| WpfCalculator.Specs | FlaUiMinimal | Tests the WpfCalculator.exe | github/ |
| WpfCalculator.Specs | FlaUiWithProfile | Tests the WpfCalculator.exe with different profiles | github/ |
| WpfCalculator.Specs | FlaUiWithProfileAndArgument | Tests the WpfCalculator.exe with a command line argument that is defined in the test (i.e. as a variable) | github/ |
| Wpf2Calculator.Specs | FlaUI | Tests two WpfCalculator.exe at the same time. | github/ |
| WindowsCalculator.Specs | FlaUI | Tests the Windows calculator. | github/ |
| WebCalculatorApi.Specs | HttpClientTestHost | Tests the calculator Web Api by starting a te | github/ |



## Examples

The examples are bigger than tests. The examples do not try to solve "real world problems". Instead, they demonstrate some aspects of e2e testing.



## How it works

by using FlaUIPlayWrightusing HttpClientTest profiles in `reqnroll.ampsettings.json` which can be selected at runtime



Limitations (difference to specflow.action.plugins)

- Uses chrome and PlayWright for Web UI testing
- Uses FlaUI for Windows application testing
- Uses xunit.v3
- Uses Autofac

Personal opinion: Which testing frameworks is an system architecture decision. To later change to a different framework is hard. To write a Selenium driver for example is easy; just copy and modify `PlayWrightDriver`. 


Repository structure
- examples: examples use Futile.Reqnroll.Amp nuget package from nuget.org. Examples are more complex than tests
- tests: test the features and aspects of Reqnroll.Amp. Best entry point to learn
- src: source code of the Reqnroll.Amp library






---

Build, air-gaped

To work offline, use the batch files.
