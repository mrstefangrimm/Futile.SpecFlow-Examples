using Reqnroll.Amp;

namespace WeatherApi.Specs.App;

public class WeatherApp
{
    private readonly HttpClientDriver _driver;

    public WeatherApp(HttpClientDriver driver)
    {
        _driver = driver;
    }
        
    public async Task<string> GetResult()
    {
        var response = await _driver.Current.GetAsync("");
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
}
