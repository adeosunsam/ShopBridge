﻿using AutoMapper;
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
        public ProductService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<Response<PageResult<IEnumerable<ProductsDto>>>> GetAllproducts(PagingDto paging)
        {
            var products = _unit.Product.GetProducts();
            var item = await products.PaginationAsync<Product, ProductsDto>(paging.PageSize, paging.PageNumber, _mapper);
            return Response<PageResult<IEnumerable<ProductsDto>>>.Success("All Products on Display", item, StatusCodes.Status200OK);
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
        }
    }
}