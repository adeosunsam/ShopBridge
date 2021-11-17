using System.ComponentModel.DataAnnotations;

namespace ShopBridge_dtos.ProductDto
{
    public class ProductsDto
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double ProductPrice { get; set; }
    }
}
