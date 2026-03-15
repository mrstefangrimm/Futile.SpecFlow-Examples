using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using WpfCalculator.Specs.App;
using WpfCalculator.Specs.Services;
using WpfCalculator.Specs.Steps;

namespace WpfCalculator.Specs;

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
        builder.RegisterType<CalculatorMainWindow>().AsSelf().InstancePerDependency();
    }

    private static void RegisterPagesHandler(this ContainerBuilder builder)
    {
        builder.RegisterType<CalculatorService>().As<ICalculatorService>().InstancePerLifetimeScope();
        builder.RegisterType<FlaUIDriver>().AsSelf().InstancePerLifetimeScope();
    }

    private static void RegisterPageDependencyService(this ContainerBuilder builder)
    {
    }
}
