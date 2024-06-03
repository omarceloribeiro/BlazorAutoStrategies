namespace BlazorApp.Client.Services
{
    public class WasmLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new WasmLogger();
        }

        public void Dispose()
        {
            // nothing to dispose
        }
    }
}
