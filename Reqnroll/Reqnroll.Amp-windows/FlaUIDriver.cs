using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Tools;
using FlaUI.UIA2;
using FlaUI.UIA3;
using Microsoft.Extensions.Options;

namespace Reqnroll.Amp;

public class FlaUIDriverBase : AmpDriver<Window>, IDisposable
{
    private Application? _application;
    private bool _disposed;

    public FlaUIDriverBase(IOptions<AppSettings> appSettings) : base(appSettings) { }
    
    public ConditionFactory Get => _lazyInstance.Value.Automation.ConditionFactory;

    protected override Window LaunchProfile()
    {
        var flu = _appSettings.Value.FlaUi;

        AutomationBase automation = flu.Settings.UIA switch
        {
            FlaUIA.UIA2 => new UIA2Automation(),
            FlaUIA.UIA3 => new UIA3Automation(),
            _ => throw new InvalidOperationException($"Invalid FlaUI Automation {flu.Settings.UIA}."),
        };

        var profiles = flu.Profiles;
        if (profiles == null || !profiles.Any()) { throw new InvalidOperationException("No FlaUI profile defined"); }

        if (_launchProfileName == null)
        {
            _launchProfileName = profiles.First().Key;
            if (_launchProfileName == null || string.IsNullOrEmpty(_launchProfileName)) { throw new InvalidOperationException($"Invalid FlaUI profile name {_launchProfileName}."); }
        }

        var profile = profiles[_launchProfileName];
        if (profile == null) { throw new InvalidOperationException($"Invalid profile with name {_launchProfileName}."); }

        if (profile.Launch == LaunchCommand.Exe)
        {
            _application = Application.Launch(profile.App, _launchArguments ?? profile.Arguments);
        }
        else if (profile.Launch == LaunchCommand.StoreApp)
        {
            _application = Application.LaunchStoreApp(profile.App, _launchArguments ?? profile.Arguments);
        }
        else
        {
            throw new InvalidOperationException();
        }

        return _application.GetMainWindow(automation);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        if (_application != null)
        {
            _application.Close();
            var application = _application;
            Retry.WhileFalse(() => application.HasExited, TimeSpan.FromSeconds(2), ignoreException: true);
            _application.Dispose();
            _application = null;
        }

        _disposed = true;
    }
}

public class FlaUIDriver : FlaUIDriverBase
{
    public FlaUIDriver(IOptions<AppSettings> appSettings) : base(appSettings) { }
}

public class FlaUIDriver<N> : FlaUIDriverBase
{
    public FlaUIDriver(IOptions<AppSettings> appSettings) : base(appSettings) { }
}
