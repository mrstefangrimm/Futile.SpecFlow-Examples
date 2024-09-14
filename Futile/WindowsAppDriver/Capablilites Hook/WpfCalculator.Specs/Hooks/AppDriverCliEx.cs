// 2023, written by Stefan Grimm

using SpecFlow.Actions.Appium.Configuration.WindowsAppDriver;
using SpecFlow.Actions.WindowsAppDriver;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WpfCalculator.Specs.Hooks;

public class AppDriverCliEx : IAppDriverCli {
  private readonly IWindowsAppDriverConfiguration _windowsAppDriverConfiguration;
  private readonly ICapabilitiesEx _capabilitiesEx;
  private bool _isDisposed;
  private Process? _appDriverProcess;

  private static AppDriverCliEx? _instance;

  public AppDriverCliEx(
      IWindowsAppDriverConfiguration windowsAppDriverConfiguration,
      ICapabilitiesEx capabilitiesEx) {
    _windowsAppDriverConfiguration = windowsAppDriverConfiguration ?? throw new ArgumentNullException();
    _capabilitiesEx = capabilitiesEx ?? throw new ArgumentNullException();
  }

  public void Start() {
    _instance = this;
  }

  public static void StartEx(KeyValuePair<string, string>[] capabilities) {
    _instance?.StartWindowsAppDriver(capabilities);
  }

  private void StartWindowsAppDriver(KeyValuePair<string, string>[] capablilities) {
    var path = _windowsAppDriverConfiguration.WindowsAppDriverPath
                ?? Environment.GetEnvironmentVariable("WINDOWS_APP_DRIVER_EXECUTABLE_PATH")
                ?? null;

    if (path != null) {
      var argument = string.Empty;
      if (_windowsAppDriverConfiguration != null
          && _windowsAppDriverConfiguration.WindowsAppDriverPort != null
          && _windowsAppDriverConfiguration.WindowsAppDriverPort.HasValue) {
        argument = _windowsAppDriverConfiguration.WindowsAppDriverPort.Value.ToString();
      }

      if (_windowsAppDriverConfiguration != null) {
        // Remove extended capabilities from previous scenario.
        foreach (var capabilityKey in _capabilitiesEx.Capabilities) {
          _windowsAppDriverConfiguration.Capabilities.Remove(capabilityKey);
        }
        _capabilitiesEx.Clear();

        // Add capability for this scenario.
        foreach (var capability in capablilities) {
          _capabilitiesEx.Add(capability.Key, capability.Value);
          _windowsAppDriverConfiguration.Capabilities.Add(capability.Key, capability.Value);
        }
      }

      _appDriverProcess = Process.Start(path, argument);

    }
  }

  public void Dispose() {
    if (_isDisposed) return;

    _appDriverProcess?.Kill();

    _instance = null;

    _isDisposed = true;
  }
}
