using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShopBridge_utilities.MapperClass;

namespace ShopBridge_api.StartupExtension
{
    public static class MapperExtension
    {
        public static void AutoMapperExtension(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapperInitialize));
        }
    }
}
