using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Amp;
using Reqnroll.Autofac;
using WebCalculatorApi.Controllers;
using WebCalculatorApi.Services;
using WebCalculatorApi.Specs.App;
using WebCalculatorApi.Specs.Services;
using WebCalculatorApi.Specs.Steps;

namespace WebCalculatorApi.Specs;

public static class TestStartup
{
    [ScenarioDependencies]
    public static void CreateServices(ContainerBuilder builder)
    {
        builder.RegisterConfiguration();
        builder.RegisterAppSettings();

        builder.RegisterType<CalculatorStepDefinitions>().InstancePerDependency();
        builder.RegisterType<CalculatorService>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<CalculatorApiClient>().AsSelf().InstancePerDependency();
        builder.RegisterType<HttpClientDriver>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<HttpClientFactory>().As<IDriverInstanceFactory<HttpClient>>().InstancePerLifetimeScope();

        var factory = new CustomWebApplicationFactory();
        HttpClientFactory.Instance = factory.CreateClient();
        HttpClientFactory.Instance.BaseAddress = new Uri("http://localhost/api/calculation");
    }
}

internal class HttpClientFactory : IDriverInstanceFactory<HttpClient>
{
    public static HttpClient Instance { get; set; }

    public HttpClient Create()
    {
        return Instance;
    }
}

internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove the real service
            var descriptor = services.Single(d => d.ServiceType == typeof(ICalculationService));
            services.Remove(descriptor);

            // Add your mock
            services.AddSingleton<ICalculationService>(new CalculationMockService());
        });
    }
}

internal class CalculationMockService : ICalculationService
{
    public CalculationResponse Calculate(CalcuationRequest request)
    {
        return request.MathOperation switch
        {
            "Add" => new CalculationResponse(request.FirstNumber + request.SecondNumber),
            "Subtract" => new CalculationResponse(request.FirstNumber - request.SecondNumber),
            "Multiply" => new CalculationResponse(request.FirstNumber * request.SecondNumber),
            "Divide" => request.SecondNumber != 0
                                ? new CalculationResponse(request.FirstNumber * 1d / request.SecondNumber)
                                : throw new DivideByZeroException("Cannot divide by zero."),
            _ => throw new ArgumentException($"Unknown operation: {request.MathOperation}"),
        };
    }
}
