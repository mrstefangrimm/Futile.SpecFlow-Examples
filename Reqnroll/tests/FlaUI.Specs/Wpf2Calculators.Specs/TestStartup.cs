using Autofac;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using Wpf2Calculators.Specs.App;
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

        builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<CalculatorServiceOne>().As<ICalculatorService<Ports.One>>().InstancePerLifetimeScope();
        builder.RegisterType<CalculatorServiceTwo>().As<ICalculatorService<Ports.Two>>().InstancePerLifetimeScope();
        builder.RegisterType<CalculatorMainWindow<Ports.One>>().AsSelf().InstancePerDependency();
        builder.RegisterType<CalculatorMainWindow<Ports.Two>>().AsSelf().InstancePerDependency();
        builder.RegisterType<FlaUIDriver<Ports.One>>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<FlaUIDriver<Ports.Two>>().AsSelf().InstancePerLifetimeScope();
    }
}
