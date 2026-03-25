# Reqnroll.Amp

Reqnroll.Amp is a class library that boosts (amplifies) your test‑writing.

Features:

- Class for Windows applications based on FlaUI (reference package: Futile.Reqnroll.Amp-windows)
- Class for Web applications based on PlayWright
- Class for Web Apis using HttpClient
- Test profiles in `reqnroll.ampsettings.json` which can be selected at runtime
- Supports multiple applications under test


Limitations
- Uses chrome and PlayWright for Web UI testing
- Uses FlaUI for Windows application testing
- Uses xunit.v3

Which testing frameworks is an system architure decision. To later change to a different framework is hard. To write a Selenium driver for example is easy; just copy and modify `PlayWrightDriver`. 

---

Build

To work offline, use the batch files.
