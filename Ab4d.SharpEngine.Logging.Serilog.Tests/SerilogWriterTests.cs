using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using Serilog.Events;
using System.Collections.Generic;

namespace Ab4d.SharpEngine.Logging.Serilog.Tests;

[TestClass]
public sealed class SerilogWriterTests
{
    sealed class TestSink : global::Serilog.Core.ILogEventSink
    {
        public readonly List<LogEvent> LogEvents = new();

        public void Emit(LogEvent logEvent) => LogEvents.Add(logEvent);
    }

    [TestMethod]
    public void Main()
    {
        // Setup

        var testSink = new TestSink();

        global::Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Sink(testSink)
            .CreateLogger();

        SerilogWriter.WriteTo();

        // Test

        Ab4d.SharpEngine.Utilities.Log.WriteLog(Ab4d.SharpEngine.Common.LogLevels.Debug, null, 0, "Debug!");
        Ab4d.SharpEngine.Utilities.Log.WriteLog(Ab4d.SharpEngine.Common.LogLevels.Info, null, 0, "Info!");

        Assert.AreEqual(1, testSink.LogEvents.Count);
        Assert.IsTrue(testSink.LogEvents[0].MessageTemplate.Text.EndsWith("|Info!||"));
    }
}