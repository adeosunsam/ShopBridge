using AutoMapper;
using ShopBridge_dtos.ProductDto;
using ShopBridge_model;

namespace ShopBridge_utilities.MapperClass
{
    public class AutoMapperInitialize : Profile
    {
        public AutoMapperInitialize()
        {
            //product Mapping
            //CreateMap<Product, ProductsDto>();
            CreateMap<Product, ProductsDto>().ReverseMap();
        }
    }
}
