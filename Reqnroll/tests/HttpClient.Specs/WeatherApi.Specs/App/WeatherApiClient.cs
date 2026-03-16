using Reqnroll.Amp;

namespace WeatherApi.Specs.App;

public class WeatherApiClient
{
    private readonly HttpClientDriver _driver;

    public WeatherApiClient(HttpClientDriver driver)
    {
        _driver = driver;
    }
        
    public async Task<string> GetResult()
    {
        var response = await _driver.Stub.GetAsync("");
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
}
