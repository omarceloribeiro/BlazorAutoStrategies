using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;
using BlazorAuto.WithServices.WebApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//string apiSiteAddress = "https://localhost:7062";
string apiSiteAddress = "https://localhost:7175";
builder.Services.AddSingleton(new HttpClient() { BaseAddress = new Uri(apiSiteAddress) });
builder.Services.AddSingleton<IProductAppService, ProductClientAppService>();

await builder.Build().RunAsync();
