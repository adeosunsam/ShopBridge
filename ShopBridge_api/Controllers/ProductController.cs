using Microsoft.AspNetCore.Mvc;
using ShopBridge_dtos;
using ShopBridge_dtos.ProductDto;
using ShopBridge_services.Interfaces;
using System.Threading.Tasks;

namespace ShopBridge_api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductService product, IImageService imageService)
        {
            _product = product;
            _imageService = imageService;
        }
        private readonly IProductService _product;
        private readonly IImageService _imageService;

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetProducts([FromQuery] PagingDto paging)
        {
            var getAllproducts = await _product.GetAllproducts(paging);
            return Ok(getAllproducts);
        }

        [HttpPost]
        [Route("add-product")]
        public async Task<IActionResult> AddProduct(ProductsDto product)
        {
            var addNewProduct = await _product.Addproduct(product);
            return Created("", addNewProduct);
        }

        [HttpDelete]
        [Route("delete-product")]
        public async Task<IActionResult> Deleteproduct(string id)
        {
            var deleteProduct = await _product.DeleteProduct(id);
            return StatusCode(deleteProduct.StatusCode, deleteProduct);
        }

        [HttpPatch]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct(string id, UpdateDto product)
        {
            var updateProduct = await _product.Updateproduct(id, product);
            return Ok(updateProduct);
        }

        [HttpPut]
        [Route("add-image")]
        public async Task<IActionResult> Image(string productId, [FromForm] ImageDTo image)
        {

            var upload = await _imageService.UploadImage(image.Image);

            /* user.ProfilePics = upload.Url.ToString();
             await _userManager.UpdateAsync(user);*/

            return NoContent();
        }
    }
}
