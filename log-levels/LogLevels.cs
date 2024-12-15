using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        var message = logLine.Substring(logLine.IndexOf(':') + 1).Trim();
        return message;
    }

    public static string LogLevel(string logLine)
    {
        var logLevel = logLine.Substring(1, logLine.IndexOf(']') - 1).ToLower();
        return logLevel;
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string logLevel = LogLevel(logLine);
        return $"{message} ({logLevel})";
    }
}
