using BlazorApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddLogging(logBuilder =>
//{

//    logBuilder.AddProvider(new WasmLoggerProvider());
//    //logBuilder.AddDebug();
//    // logBuilder.AddEventLog(); only supoorted in windows

//    //logBuilder.AddEventSourceLogger();

//    // logBuilder.AddTraceSource("MyLogger"); error service collection cannot be modifed because is readonly

//});

await builder.Build().RunAsync();
