namespace BlazorAuto.WithServices.Core.Models
{
    public class Product : ModelBase
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
