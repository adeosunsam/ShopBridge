using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge_dtos.ProductDto
{
    public class ProductResponseDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double ProductPrice { get; set; }
        public string ThumbNail { get; set; }
    }
}
