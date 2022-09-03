namespace OnlineShopping.UI.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Size { get; set; } = string.Empty;
        public bool isInStock { get; set; }
        public double Price { get; set; }
    }
}
