using Microsoft.Extensions.Options;

namespace Reqnroll.Amp;

public class HttpClientDriverBase : AmpDriver<HttpClient>, IDisposable
{
    private HttpClient? _application;
    private bool _disposed;

    public HttpClientDriverBase(IOptions<AmpSettings> appSettings) : base(appSettings) { }

    protected override HttpClient LaunchProfile()
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
        _application.BaseAddress = new Uri(_launchArguments ?? profile.Url);

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
    public HttpClientDriver(IOptions<AmpSettings> appSettings) : base(appSettings) { }
}

public class HttpClientDriver<N> : HttpClientDriverBase
{
    public HttpClientDriver(IOptions<AmpSettings> appSettings) : base(appSettings) { }
}
