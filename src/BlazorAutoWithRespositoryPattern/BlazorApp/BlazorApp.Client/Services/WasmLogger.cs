﻿
namespace BlazorApp.Client.Services
{
    public class WasmLogger : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.WriteLine("[WasmLogger] WebAssemblyLog: " + Convert.ToString(state));
        }
    }
}
