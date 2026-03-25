# Reqnroll.Amp

Reqnroll.Amp is a class library that boosts (amplifies) your test‑writing.

Features:

- Class for Windows applications based on FlaUI (reference package: Futile.Reqnroll.Amp-windows)
- Class for Web applications based on PlayWright
- Class for Web Apis using HttpClient
- Test profiles in `reqnroll.ampsettings.json` which can be selected at runtime
- Supports multiple applications under test

Examples
- The source code contains unit tests for all of the features listed above. 

Limitations (difference to specflow.action.plugins)
- Uses chrome and PlayWright for Web UI testing
- Uses FlaUI for Windows application testing
- Uses xunit.v3

Personal opinion: Which testing frameworks is an system architure decision. To later change to a different framework is hard. To write a Selenium driver for example is easy; just copy and modify `PlayWrightDriver`. 


Repository structure
- examples: examples use Futile.Reqnroll.Amp nuget package from nuget.org. Examples are more complex than tests
- tests: test the features and aspects of Reqnroll.Amp. Best entry point to learn
- src: source code of the Reqnroll.Amp library


---

Build, air-gaped

To work offline, use the batch files.
