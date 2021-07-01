using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Enrichers.Correlate;

namespace AspNetCoreSample
{
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
        loggerConfiguration.Enrich.WithCorrelate(serviceProvider);
    }
}
}
