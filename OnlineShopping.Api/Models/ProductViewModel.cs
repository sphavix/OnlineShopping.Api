using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Api.Models
{
    public class ProductViewModel
    {
        [Key]
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
