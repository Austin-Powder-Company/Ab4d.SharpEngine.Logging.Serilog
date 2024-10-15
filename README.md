[![#: SharpEngine](https://camo.githubusercontent.com/0976d0fd92e6a61e359dedd2b7ff36d88cbd168679c80a5668a84d4d4a6fda71/68747470733a2f2f7777772e616234642e636f6d2f696d616765732f5368617270456e67696e652f73686172702d656e67696e655f353132783231382e706e67)](https://www.ab4d.com/SharpEngine.aspx)

Utilities for writing Ab4d.SharpEngine logs to Serilog loggers.

## Usage

Place the following line in your setup code somewhere. After it executes, Ab4d.SharpEngine logs will be written to the static `Serilog.Log.Logger`.

```cs
Ab4d.SharpEngine.Logging.Serilog.SerilogWriter.WriteTo();
```

Alternatively you can specify a `Serilog.ILogger` to write to.

```cs
var myLogger = new LoggerConfiguration().CreateLogger();
Ab4d.SharpEngine.Logging.Serilog.SerilogWriter.WriteTo(myLogger);
```
