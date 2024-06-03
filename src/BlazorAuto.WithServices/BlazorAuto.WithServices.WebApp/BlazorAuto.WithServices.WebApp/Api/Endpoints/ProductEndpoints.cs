using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;

namespace BlazorAuto.WithServices.WebApp.Api.Endpoints
{
    public static class ProductEndpoints
    {
        
        public static void MapProductEndpoints(this WebApplication? app)
        {
            if (app is null)
                return;

            app.MapGet("/api/products", async (IProductAppService x) => { return await x.ReadAllProduct(); })
                .WithName("ReadAllProducts");
                //.WithOpenApi();
        }
    }
}
