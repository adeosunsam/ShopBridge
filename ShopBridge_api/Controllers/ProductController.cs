﻿using Microsoft.AspNetCore.Mvc;
using ShopBridge_dtos;
using ShopBridge_dtos.ProductDto;
using ShopBridge_services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductService product)
        {
            _product = product;
        }
        private readonly IProductService _product;

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetProducts([FromQuery]PagingDto paging)
        {
            var getAllproducts = await _product.GetAllproducts(paging);
            return Ok(getAllproducts);
        }

        [HttpPost]
        [Route("add-product")]
        public async Task<IActionResult> AddProduct(ProductsDto product)
        {
            var addNewProduct = await _product.Addproduct(product);
            return Ok(addNewProduct);
        }
    }
}