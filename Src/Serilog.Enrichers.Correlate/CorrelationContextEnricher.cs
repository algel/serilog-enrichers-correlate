using Correlate;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.Correlate
{
    internal class CorrelationContextEnricher : ICorrelationContextEnricher
    {
        private readonly ICorrelationContextAccessor correlationContextAccessor;

        public CorrelationContextEnricher(ICorrelationContextAccessor correlationContextAccessor)
        {
            this.correlationContextAccessor = correlationContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (this.correlationContextAccessor.CorrelationContext != null)
            {
                logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("CorrelationId", this.correlationContextAccessor.CorrelationContext.CorrelationId));
            }
        }
    }
}
