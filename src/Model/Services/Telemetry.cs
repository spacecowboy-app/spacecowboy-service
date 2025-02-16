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

    /// <summary>Counter for the total number of sessions created.</summary>
    private Counter<long> SessionsTotal { get; }

    /// <summary>Counter for the current number of active sessions.</summary>
    private UpDownCounter<long> SessionsActive { get; }


    /// <summary>Constructor.</summary>
    public Telemetry()
    {
        SessionsTotal = meter.CreateCounter<long>("spacecowboy.sessions.total", "Total number of sessions created.");
        SessionsActive = meter.CreateUpDownCounter<long>("spacecowboy.sessions.active", "Current number of active sessions.");
    }


    /// <summary>Increment the number of sessions created.</summary>
    /// <param name="count">Number of sessions to increment by (default 1).</param>
    public void IncrementSessions(int count = 1)
    {
        if (count < 0) {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be a positive integer.");
        }
        SessionsTotal.Add(count);
        SessionsActive.Add(count);
    }


    /// <summary>Decrement the number of active sessions.</summary>
    /// <param name="count">Number of sessions to decrement by (default 1).</param>
    public void DecrementSessions(int count = 1)
    {
        if (count < 0) {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be a positive integer.");
        }
        SessionsActive.Add(-count);
    }


    /// <summary>Properly dispose of resources.</summary>
    public void Dispose()
    {
        ActivitySource.Dispose();
        meter.Dispose();
    }
}
