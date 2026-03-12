using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        builder.RegisterPages();
        builder.RegisterPagesHandler();
        builder.RegisterPageDependencyService();
        builder.RegisterSteps();
    }

    private static void RegisterSteps(this ContainerBuilder builder)
    {
        builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
    }

    private static void RegisterConfiguration(this ContainerBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("Settings/appsettings.json", false, true)
            .Build();

        builder.RegisterInstance(configuration)
            .As<IConfiguration>()
            .SingleInstance();
    }

    private static void RegisterAppSettings(this ContainerBuilder builder)
    {
        builder.Register(c =>
        {
            var configuration = c.Resolve<IConfiguration>();
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            return Options.Create(appSettings);
        }).As<IOptions<AppSettings>>();
    }    

    private static void RegisterPages(this ContainerBuilder builder)
    {
        builder.RegisterType<WeatherApp>().AsSelf().InstancePerDependency();
    }

    private static void RegisterPagesHandler(this ContainerBuilder builder)
    {
        builder.RegisterType<WeatherService>().As<IWeatherService>().InstancePerLifetimeScope();
        builder.RegisterType<HttpClientDriver>().AsSelf().InstancePerLifetimeScope();
    }

    private static void RegisterPageDependencyService(this ContainerBuilder builder)
    {
    }
}
