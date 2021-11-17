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
            service.AddTransient<IAuthenticationServices, AuthenticationServices>();
            service.AddScoped<IProductService, ProductService>();

            //Iunitofwork injection
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
