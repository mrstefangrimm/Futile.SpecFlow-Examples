using Autofac;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using WeatherApi.Specs.App;
using WeatherApi.Specs.Services;
using WeatherApi.Specs.Steps;

namespace WeatherApi.Specs;

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterConfiguration();
        builder.RegisterAppSettings();

        builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<WeatherService>().As<IWeatherService>().InstancePerLifetimeScope();
        builder.RegisterType<WeatherApiClient>().AsSelf().InstancePerDependency();
        builder.RegisterType<HttpClientDriver>().AsSelf().InstancePerLifetimeScope();
    }
}
