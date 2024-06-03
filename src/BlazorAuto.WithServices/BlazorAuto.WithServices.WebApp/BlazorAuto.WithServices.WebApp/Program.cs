using BlazorAuto.WithServices.Application.Handlers;
using BlazorAuto.WithServices.Application.Services;
using BlazorAuto.WithServices.ApplicationShared.Handlers;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Requests;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;
using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Core.Interfaces.Services;
using BlazorAuto.WithServices.Core.Services;
using BlazorAuto.WithServices.Data.Repositories;
using BlazorAuto.WithServices.WebApp.Api.Endpoints;
using BlazorAuto.WithServices.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// domain services
builder.Services.AddSingleton<IProductDomainService, ProductDomainService>();
builder.Services.AddSingleton<IProductCategoryDomainService, ProductCategoryDomainService>();

// repsitories
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductCategoryRepository, ProductCategoryRepository>();

// handlers
builder.Services.AddSingleton<IRequestHandler<CreateOrUpdateProductRequest, ProductReponse>, CreateProductHandler>();

// app services
builder.Services.AddSingleton<IProductAppService, ProductAppService>();



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorAuto.WithServices.WebApp.Client._Imports).Assembly);

app.MapProductEndpoints();
app.Run();
