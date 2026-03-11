using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using Wpf2Calculators.Specs.CalculatorApp;
using Wpf2Calculators.Specs.Services;
using Wpf2Calculators.Specs.Steps;

namespace Wpf2Calculators.Specs;

public static class Ports
{
    public struct One { }
    public struct Two { }
}

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
        builder.RegisterType<CalculatorMainWindow<Ports.One>>().AsSelf().InstancePerDependency();
        builder.RegisterType<CalculatorMainWindow<Ports.Two>>().AsSelf().InstancePerDependency();
    }

    private static void RegisterPagesHandler(this ContainerBuilder builder)
    {
        builder.RegisterType<CalculatorServiceOne>().As<ICalculatorService<Ports.One>>().InstancePerLifetimeScope();
        builder.RegisterType<CalculatorServiceTwo>().As<ICalculatorService<Ports.Two>>().InstancePerLifetimeScope();
        builder.RegisterType<FlaUIDriver<Ports.One>>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<FlaUIDriver<Ports.Two>>().AsSelf().InstancePerLifetimeScope();
    }

    private static void RegisterPageDependencyService(this ContainerBuilder builder)
    {
        builder.RegisterType<PageDependencyService>().As<IPageDependencyService>().InstancePerLifetimeScope();
    }
}
