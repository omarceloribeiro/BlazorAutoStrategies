using BlazorAuto.WithServices.ApplicationShared.Handlers.Requests;
using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAuto.WithServices.WebApp.Api.CustomEndpoints
{
    public static class CustomProductEndpoints
    {
        
        public static void MapCustomProductEndpoints(this WebApplication? app)
        {
            if (app is null)
                return;

            app.MapGet("/api/productcategories", async (IProductCategoryAppService x) => { return await x.ReadAll(); })
                .WithName("ReadAllProductCategories");

            app.MapGet("/api/products", async (IProductAppService x) => { return await x.ReadAllProduct(); })
                .WithName("ReadAllProducts");

            app.MapGet("/api/products/{id}", async (IProductAppService x, int id) => { return await x.GetProductById(id); })
                .WithName("ReadProduct");

            app.MapPost("/api/products", async (IProductAppService x, [FromBody]CreateOrUpdateProductRequest productRequest) => 
            {
                if (productRequest.Id > 0)
                {
                    return await x.UpdateProduct(productRequest);
                }
                else
                {
                    return await x.CreateProduct(productRequest);
                }
            })
                .WithName("CreateOrUpdateProduct");

            //app.MapGet("/api/products", async (IProductAppService x) => { return await x.ReadAllProduct(); })
            //    .WithName("ReadAllProducts");

            //app.MapGet("/api/products", async (IProductAppService x) => { return await x.ReadAllProduct(); })
            //    .WithName("ReadAllProducts");
            //.WithOpenApi();
        }
    }
}
