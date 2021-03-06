using ShopBridge_dtos;
using ShopBridge_dtos.ProductDto;
using ShopBridge_utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge_services.Interfaces
{
    public interface IProductService
    {
        Task<Response<PageResult<IEnumerable<ProductResponseDto>>>> GetAllproducts(PagingDto paging);
        Task<Response<bool>> Addproduct(ProductsDto product);
        Task<Response<bool>> DeleteProduct(string id);
        Task<Response<bool>> Updateproduct(string id, UpdateDto product);
        Task<Response<bool>> UpdateImage(string ProductId, ImageDTo image);
    }
}
