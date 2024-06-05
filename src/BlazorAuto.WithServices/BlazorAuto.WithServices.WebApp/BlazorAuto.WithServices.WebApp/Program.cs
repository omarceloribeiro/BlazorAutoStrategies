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
using BlazorAuto.WithServices.DataEF;
using BlazorAuto.WithServices.DataEF.Repositories;

using BlazorAuto.WithServices.WebApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlazorAuto.WithServices.WebApp.Api.CustomEndpoints;

var builder = WebApplication.CreateBuilder(args);

// EF Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddQuickGridEntityFrameworkAdapter();;

// domain services
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
builder.Services.AddScoped<IProductCategoryDomainService, ProductCategoryDomainService>();

// repsitories
//builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();
//builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryInMemoryRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

// handlers
builder.Services.AddScoped<IRequestHandler<CreateOrUpdateProductRequest, ProductReponse>, CreateProductHandler>();

// app services
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductCategoryAppService, ProductCategoryAppService>();



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

// for some reason this extension method throws error when scaffolding. need to comment that to scaffold work
app.MapCustomProductEndpoints();
app.Run();
