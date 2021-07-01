# Serilog.Enrichers.Correlate
[Serilog](https://github.com/serilog/serilog) enricher for [Correlate](https://github.com/skwasjer/Correlate). 

Adds the CorrelationId property by populating the value from ICorrelationContextAccessor.

## Installation

Install Serilog.Enrichers.Correlate via the Nuget package manager or `dotnet` cli.

```powershell
dotnet add package Serilog.Enrichers.Correlate
```

## Correlation ID flow

The Correlate framework provides an ambient correlation context scope, that makes it easy to track a Correlation ID passing through (micro)services.

This library specifically provides a enricher for [Serilog](https://github.com/serilog/serilog) and adds the CorrelationId property to each log event with the value from correlation context provided by [Correlate](https://github.com/skwasjer/Correlate).

## Usage ###

TBD



## More info

See [Correlate](https://github.com/skwasjer/Correlate) documentation for further integration with ASP.NET Core, `IHttpClientFactory` and for other extensions/libraries.

See [Serilog](https://github.com/serilog/serilog) documentation for simple .NET logging with fully-structured events
