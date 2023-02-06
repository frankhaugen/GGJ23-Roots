using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public static class Logger
    {
        private static readonly DateTime _startTime = DateTime.UtcNow;
        private static readonly DirectoryInfo _logDirectory = Directories.Logs;
        private static readonly FileInfo _logFile = new(Path.Combine(_logDirectory.FullName, $"{_startTime:yyyy-MM-ddTHHmmssfff}.log"));
        
        public static void Log(LogLevel level, string message, [CanBeNull] string stacktrace = null)
        {
            var logEntry = new LogEntry
            {
                Level = level,
                Time = DateTime.UtcNow,
                Message = message,
                Stacktrace = stacktrace
            };
            var json = JsonConvert.SerializeObject(logEntry, Formatting.None);
            
            LogToDebugLog(level, json);
            FileWriter.Append(_logFile, json);
        }
        
        private static void LogToDebugLog(LogLevel level, string logEntry)
        {
            switch (level)
            {
                case LogLevel.Info:
                    Debug.LogWarning(logEntry);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(logEntry);
                    break;
                case LogLevel.Error:
                    Debug.LogError(logEntry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }

        public static void LogInfo(string message) => Log(LogLevel.Info, message);

        public static void LogWarning(string message) => Log(LogLevel.Warning, message);

        public static void LogError(string message) => Log(LogLevel.Error, message);
        
        public static void LogError(Exception exception) => Log(LogLevel.Error, exception.Message, !string.IsNullOrWhiteSpace(exception.StackTrace) ? exception.StackTrace : null);
        
        public static void LogException(Exception exception) => LogError(exception);
    }