# Serilog.Enrichers.Correlate

[Serilog](https://github.com/serilog/serilog) enricher for [Correlate](https://github.com/skwasjer/Correlate). 

Adds the CorrelationId property by populating the value from ICorrelationContextAccessor.

## Installation

Install Serilog.Enrichers.Correlate via the Nuget package manager or `dotnet` cli.

```powershell
dotnet add package Serilog.Enrichers.Correlate
```
[![Nuget](https://img.shields.io/nuget/v/Serilog.Enrichers.Correlate.svg)](https://www.nuget.org/packages?q=Serilog.Enrichers.Correlate)
[![Nuget](https://img.shields.io/nuget/dt/Serilog.Enrichers.Correlate.svg)](https://www.nuget.org/packages?q=Serilog.Enrichers.Correlate)

## Correlation ID flow

The Correlate framework provides an ambient correlation context scope, that makes it easy to track a Correlation ID passing through (micro)services.

This library specifically provides a enricher for [Serilog](https://github.com/serilog/serilog) and adds the CorrelationId property to each log event with the value from correlation context provided by [Correlate](https://github.com/skwasjer/Correlate).

## Usage ###

Register in service collection

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddCorrelate()
        .AddCorrelationContextEnricher();
}
```

and configure logger

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog(ConfigureLogger)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

    private static void ConfigureLogger(HostBuilderContext context, IServiceProvider serviceProvider, LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration
            .WriteTo.Console()
            .Enrich.WithCorrelate(serviceProvider);
    }
}
```



## More info

See [Correlate](https://github.com/skwasjer/Correlate) documentation for further integration with ASP.NET Core, `IHttpClientFactory` and for other extensions/libraries.

See [Serilog](https://github.com/serilog/serilog) documentation for simple .NET logging with fully-structured events
