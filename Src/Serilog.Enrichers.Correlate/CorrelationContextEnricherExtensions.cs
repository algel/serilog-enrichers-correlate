using System;
using Correlate;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Configuration;
using Serilog.Core;

namespace Serilog.Enrichers.Correlate
{
    public static class CorrelationContextEnricherExtensions
    {
        public static LoggerConfiguration WithCorrelate(this LoggerEnrichmentConfiguration configuration, ICorrelationContextAccessor correlationContextAccessor)
        {
            return configuration.With(new CorrelationContextEnricher(correlationContextAccessor));
        }

        public static LoggerConfiguration WithCorrelate(this LoggerEnrichmentConfiguration configuration,
            IServiceProvider serviceProvider)
        {
            return configuration.With(serviceProvider.GetRequiredService<ICorrelationContextEnricher>());
        }

        public static IServiceCollection AddCorrelationContextEnricher(this IServiceCollection services)
        {
            return services.AddSingleton<ICorrelationContextEnricher, CorrelationContextEnricher>()
                .AddSingleton<ILogEventEnricher>(sp=>sp.GetRequiredService<ICorrelationContextEnricher>());
        }
    }
}