[![#: SharpEngine](https://raw.githubusercontent.com/Austin-Powder-Company/sharpengine-contrib/master/badge.svg)](https://www.ab4d.com/SharpEngine.aspx)

Utilities for writing SharpEngine logs to Serilog loggers.

## Usage

Place the following line in your setup code somewhere. After it executes, SharpEngine logs will be written to the static `Serilog.Log.Logger`.

```cs
Ab4d.SharpEngine.Logging.Serilog.SerilogWriter.WriteTo();
```

Alternatively you can specify a `Serilog.ILogger` to write to.

```cs
var myLogger = new LoggerConfiguration().CreateLogger();
Ab4d.SharpEngine.Logging.Serilog.SerilogWriter.WriteTo(myLogger);
```