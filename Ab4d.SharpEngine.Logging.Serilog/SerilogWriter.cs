using Ab4d.SharpEngine.Common;
using Serilog.Events;

namespace Ab4d.SharpEngine.Logging.Serilog;

public static class SerilogWriter
{
    /// <summary>
    /// Converts a SharpEngine <see cref="Ab4d.SharpEngine.Common.LogLevels"/> to a Serilog <see cref="global::Serilog.Events.LogEventLevel"/>.
    /// </summary>
    public static LogEventLevel ToSerilog(this LogLevels logLevels)
    {
        switch (logLevels)
        {
            default:
            case LogLevels.All:
                return LogEventLevel.Verbose | LogEventLevel.Debug | LogEventLevel.Information | LogEventLevel.Warning | LogEventLevel.Error | LogEventLevel.Fatal;
            case LogLevels.Debug:
                return LogEventLevel.Verbose;
            case LogLevels.License:
            case LogLevels.Info:
                return LogEventLevel.Information;
            case LogLevels.Warn:
                return LogEventLevel.Warning;
            case LogLevels.Error:
                return LogEventLevel.Error;
            case LogLevels.Fatal:
                return LogEventLevel.Fatal;
        }
    }

    /// <summary>
    /// Writes SharpEngine logs to a Serilog logger. 
    /// </summary>
    /// <param name="logger">The <see cref="global::Serilog.ILogger"/> to write to. Defaults to the static <see cref="global::Serilog.Log.Logger"/>.</param>
    public static void WriteTo(global::Serilog.ILogger? logger = null)
    {
        Ab4d.SharpEngine.Utilities.Log.AddLogListener(
            (logLevels, logArea, id, message) =>
            {
                if (logLevels == LogLevels.None)
                    return;

                (logger ?? global::Serilog.Log.Logger).Write(logLevels.ToSerilog(), message);
            });
    }
}
