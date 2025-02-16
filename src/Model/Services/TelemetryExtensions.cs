using System.Diagnostics;


namespace Spacecowboy.Service.Model.Services;


/// <summary>
/// Telemetry extension methods.
/// </summary>
public static class TelemetryExtensions
{
    private const string SessionId = "spacecowboy.session_id";


    /// <summary>Add session ID to the activity</summary>
    public static Activity AddSession(this Activity activity, string sessionId)
    {
        activity.AddTag(SessionId, sessionId);
        return activity;
    }

}
