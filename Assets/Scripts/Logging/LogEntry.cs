using JetBrains.Annotations;
using System;

public class LogEntry
{
    public LogLevel Level { get; set; }
    public DateTime Time { get; set; }
    public string Message { get; set; }
    [CanBeNull] public string Stacktrace { get; set; }
}