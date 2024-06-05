using BlazorAuto.WithServices.Api.Endpoints;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Requests;
using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using BlazorAuto.WithServices.ApplicationShared.Handlers;
using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;
using BlazorAuto.WithServices.Core.Interfaces.Services;
using BlazorAuto.WithServices.Core.Interfaces.Repository;
using BlazorAuto.WithServices.Data.Repositories;
using BlazorAuto.WithServices.Core.Services;
using BlazorAuto.WithServices.Application.Handlers;
using BlazorAuto.WithServices.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// domain services
builder.Services.AddSingleton<IProductDomainService, ProductDomainService>();
builder.Services.AddSingleton<IProductCategoryDomainService, ProductCategoryDomainService>();

// repsitories
builder.Services.AddSingleton<IProductRepository, ProductInMemoryRepository>();
builder.Services.AddSingleton<IProductCategoryRepository, ProductCategoryInMemoryRepository>();

// handlers
builder.Services.AddSingleton<IRequestHandler<CreateOrUpdateProductRequest, ProductReponse>, CreateProductHandler>();

// app services
builder.Services.AddSingleton<IProductAppService, ProductAppService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapProductEndpoints();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
