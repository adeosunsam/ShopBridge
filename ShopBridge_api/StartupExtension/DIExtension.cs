using Microsoft.Extensions.DependencyInjection;
using ShopBridge_repo.Implementations;
using ShopBridge_repo.Interfaces;
using ShopBridge_services.Implementations;
using ShopBridge_services.Interfaces;

namespace ShopBridge_api.StartupExtension
{
    public static class DIExtension
    {
        public static void ConfigureInjection(this IServiceCollection service)
        {
            //authentication service
            service.AddScoped<IAuthenticationServices, AuthenticationServices>();
            service.AddScoped<IProductService, ProductService>();

            //image service
            service.AddScoped<IImageService, ImageService>();

            //Iunitofwork injection
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
