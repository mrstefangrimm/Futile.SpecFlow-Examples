using Microsoft.Extensions.Options;
using Microsoft.Playwright;

namespace Reqnroll.Amp;

public class PlayWrightDriverBase : IAsyncDisposable
{
    private IOptions<AppSettings> _appSettings;

    private IPage? _application;
    private string? _launchProfileName;
    private string? _launchProfileArguments;

    private readonly Lazy<Task<IPage>> _currentLazy;
    private bool _disposed;

    public PlayWrightDriverBase(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings;
        _currentLazy = new Lazy<Task<IPage>>(LaunchProfile);
    }

    public void SwitchProfile(string name, string? launchProfileArguments = null)
    {
        if (_currentLazy.IsValueCreated)
        {
            throw new InvalidOperationException("switch profile on launched application is not possible.");
        }

        _launchProfileName = name;
        _launchProfileArguments = launchProfileArguments;
    }

    public IPage Current => _currentLazy.Value.Result;

    private async Task<IPage> LaunchProfile()
    {
        var apiSettings = _appSettings.Value.Playwright;

        var profiles = apiSettings.Profiles;
        if (profiles == null || !profiles.Any()) { throw new InvalidOperationException("No FlaUI profile defined"); }

        if (_launchProfileName == null)
        {
            _launchProfileName = profiles.First().Key;
            if (_launchProfileName == null || string.IsNullOrEmpty(_launchProfileName)) { throw new InvalidOperationException($"Invalid FlaUI profile name {_launchProfileName}."); }
        }

        var profile = profiles[_launchProfileName];
        if (profile == null) { throw new InvalidOperationException($"Invalid profile with name {_launchProfileName}."); }


        var playwright = await Playwright.CreateAsync().ConfigureAwait(false);
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 200,
            ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
        }).ConfigureAwait(false);

        _application = await browser.NewPageAsync().ConfigureAwait(false);

        await _application.GotoAsync(_launchProfileArguments ?? profile.Url);

        return _application;
    }  

    ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (_disposed)
        {
            return ValueTask.CompletedTask;
        }

        if (_application != null && !_application.IsClosed)
        {
            _application.CloseAsync();
            _application = null;
        }

        _disposed = true;

        return ValueTask.CompletedTask;
    }
}

public class PlayWrightDriver : PlayWrightDriverBase
{
    public PlayWrightDriver(IOptions<AppSettings> appSettings) : base(appSettings) { }
}

public class PlayWrightDriver<N> : PlayWrightDriverBase
{
    public PlayWrightDriver(IOptions<AppSettings> appSettings) : base(appSettings) { }
}
