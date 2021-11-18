using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge_dtos
{
    public class ImageDTo
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
