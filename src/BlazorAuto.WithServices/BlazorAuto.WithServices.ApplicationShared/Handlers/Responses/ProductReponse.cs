namespace BlazorAuto.WithServices.ApplicationShared.Handlers.Responses
{
    //public record ProductReponse(int Id, string Name, string Description, decimal Price, int CategoryId, string CategoryTitle);
    public record ProductReponse(int Id, string Name, string Description, decimal Price, ProductCategoryResponse category);
    public record ProductCategoryResponse(int Id, string Title);
    //{
    //    //public int Id { get; set; }
    //    //public string Name { get; set; } = string.Empty;
    //    //public string Description { get; set; } = string.Empty;
    //    //public decimal Price { get; set; }
    //    //public int CategoryId { get; set; }
    //    //public string CategoryTitle { get; set; } = string.Empty;
    //}
}
