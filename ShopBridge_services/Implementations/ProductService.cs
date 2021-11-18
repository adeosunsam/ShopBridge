using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShopBridge_dtos;
using ShopBridge_dtos.ProductDto;
using ShopBridge_model;
using ShopBridge_repo.Interfaces;
using ShopBridge_services.Interfaces;
using ShopBridge_utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge_services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public ProductService(IUnitOfWork unit, IMapper mapper, IImageService imageService)
        {
            _unit = unit;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<Response<PageResult<IEnumerable<ProductResponseDto>>>> GetAllproducts(PagingDto paging)
        {
            var products = _unit.Product.GetProducts();
            var item = await products.PaginationAsync<Product, ProductResponseDto>(paging.PageSize, paging.PageNumber, _mapper);
            return Response<PageResult<IEnumerable<ProductResponseDto>>>.Success("All Products on Display", item, StatusCodes.Status200OK);
        }

        public async Task<Response<bool>> Addproduct(ProductsDto product)
        {
            var check = await _unit.Product.GetProductByName(product.ProductName);
            if (check == null)
            {
                var mapData = _mapper.Map<Product>(product);
                await _unit.Product.InsertAsync(mapData);
                await _unit.Save();
                return Response<bool>.Success("Product successfully added", true);
            }
            return Response<bool>.Fail("Product already existed", StatusCodes.Status409Conflict);
        }

        public async Task<Response<bool>> DeleteProduct(string id)
        {
            var check = await _unit.Product.GetProductById(id);
            if (check != null)
            {
                _unit.Product.Delete(check);
                await _unit.Save();
                return Response<bool>.Success("Product successfully deleted", true);
            }
            return Response<bool>.Fail("Product not found", StatusCodes.Status404NotFound);
        }

        public async Task<Response<bool>> Updateproduct(string id, UpdateDto product)
        {
            var check = await _unit.Product.GetProductById(id);
            if (check != null)
            {
                check.ProductName = string.IsNullOrWhiteSpace(product.ProductName) ? check.ProductName : product.ProductName;
                check.ProductPrice = product.ProductPrice == 0 ? check.ProductPrice : product.ProductPrice;
                check.Description = string.IsNullOrWhiteSpace(product.Description) ? check.Description : product.Description;

                _unit.Product.Update(check);
                await _unit.Save();
                return Response<bool>.Success("Product successfully updated", true);
            }
            return Response<bool>.Fail("Product not found", StatusCodes.Status404NotFound);
        }

        public async Task<Response<bool>> UpdateImage(string ProductId, ImageDTo image)
        {
            var check = await _unit.Product.GetProductById(ProductId);
            if (check != null)
            {
                var uploadImage = await _imageService.UploadImage(image.Image);

                check.ThumbNail = uploadImage.Url.ToString();
                _unit.Product.Update(check);
                await _unit.Save();
                return Response<bool>.Success("Product image successfully updated", true);
            }
            return Response<bool>.Fail("Product not found", StatusCodes.Status404NotFound);
        }
    }
}
