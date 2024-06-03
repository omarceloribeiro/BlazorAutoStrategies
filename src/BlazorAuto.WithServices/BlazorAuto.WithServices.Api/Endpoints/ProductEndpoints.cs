using BlazorAuto.WithServices.ApplicationShared.Interfaces.Services;
using System.Runtime.CompilerServices;

namespace BlazorAuto.WithServices.Api.Endpoints
{
    public static class ProductEndpoints
    {
        
        public static void MapProductEndpoints(this WebApplication? app)
        {
            if (app is null)
                return;
            
            app.MapGet("/api/products", async (IProductAppService x) => { return await x.ReadAllProduct(); })
                .WithName("ReadAllProducts")
                .WithOpenApi();
        }
    }
}
