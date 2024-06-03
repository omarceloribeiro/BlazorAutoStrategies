namespace BlazorAuto.WithServices.Core.Models
{
    public class ProductCategory : ModelBase
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int Order { get; set; }
    }
}
