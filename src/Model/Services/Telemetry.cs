using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;


namespace Spacecowboy.Service.Model.Services;


/// <summary>
/// Provide telemetry services for the Spacecowboy service.
/// </summary>
public class Telemetry : IDisposable
{
    /// <summary>Service name to use for telemetry.</summary>
    public static string ServiceName = ServiceOptions.Service.ToLowerInvariant();

    public ActivitySource ActivitySource { get; } = new ActivitySource(ServiceName);
    private readonly Meter meter = new Meter(ServiceName);


    /// <summary>Constructor.</summary>
    public Telemetry() {}


    /// <summary>Properly dispose of resources.</summary>
    public void Dispose()
    {
        ActivitySource.Dispose();
        meter.Dispose();
    }
}
