namespace Core.Models
{
    public class Product
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
