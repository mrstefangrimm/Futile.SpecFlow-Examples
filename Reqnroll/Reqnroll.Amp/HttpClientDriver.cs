using Microsoft.Extensions.Options;

namespace Reqnroll.Amp;

public class HttpClientDriverBase : IDisposable
{
    private IOptions<AppSettings> _appSettings;

    private HttpClient? _application;
    private string? _launchProfileName;
    private string? _launchProfileArguments;

    private readonly Lazy<HttpClient> _currentLazy;
    private bool _disposed;

    public HttpClientDriverBase(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings;
        _currentLazy = new Lazy<HttpClient>(LaunchProfile);
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

    public HttpClient Current => _currentLazy.Value;

    private HttpClient LaunchProfile()
    {
        var apiSettings = _appSettings.Value.WebApi;

        var profiles = apiSettings.Profiles;
        if (profiles == null || !profiles.Any()) { throw new InvalidOperationException("No FlaUI profile defined"); }

        if (_launchProfileName == null)
        {
            _launchProfileName = profiles.First().Key;
            if (_launchProfileName == null || string.IsNullOrEmpty(_launchProfileName)) { throw new InvalidOperationException($"Invalid FlaUI profile name {_launchProfileName}."); }
        }

        var profile = profiles[_launchProfileName];
        if (profile == null) { throw new InvalidOperationException($"Invalid profile with name {_launchProfileName}."); }

        _application = new HttpClient();
        _application.BaseAddress = new Uri(_launchProfileArguments ?? profile.Url);

        return _application;
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        if (_application != null)
        {
            _application.Dispose();
            _application = null;
        }

        _disposed = true;
    }
}

public class HttpClientDriver : HttpClientDriverBase
{
    public HttpClientDriver(IOptions<AppSettings> appSettings) : base(appSettings) { }
}

public class HttpClientDriver<N> : HttpClientDriverBase
{
    public HttpClientDriver(IOptions<AppSettings> appSettings) : base(appSettings) { }
}
