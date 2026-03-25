using Microsoft.Extensions.Options;
using Microsoft.Playwright;

namespace Reqnroll.Amp;

public class PlayWrightDriverBase : AmpDriver<Task<IPage>>, IDisposable, IAsyncDisposable
{
    private IPage? _application;
    private bool _disposed;

    public PlayWrightDriverBase(IOptions<AmpSettings> appSettings) : base(appSettings) { }

    ~PlayWrightDriverBase()
    {
        Dispose(false);
    }

    protected override async Task<IPage> LaunchProfile()
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
            Headless = profile.Headless,
            SlowMo = profile.SlowMo,
            ExecutablePath = profile.ChromeExecutablePath
        }).ConfigureAwait(false);

        _application = await browser.NewPageAsync().ConfigureAwait(false);

        await _application.GotoAsync(_launchArguments ?? profile.Url);

        return _application;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        if (_application != null && !_application.IsClosed)
        {
            await _application.CloseAsync();
            _application = null;
        }

        _disposed = true;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed || !disposing)
        {
            return;
        }

        if (_application != null && !_application.IsClosed)
        {
            var closingTask = _application.CloseAsync();
            closingTask.Wait(TimeSpan.FromSeconds(5));
            _application = null;
        }

        _disposed = true;
    }
}

public sealed class PlayWrightDriver : PlayWrightDriverBase
{
    public PlayWrightDriver(IOptions<AmpSettings> appSettings) : base(appSettings) { }
}

public sealed class PlayWrightDriver<N> : PlayWrightDriverBase
{
    public PlayWrightDriver(IOptions<AmpSettings> appSettings) : base(appSettings) { }
}
