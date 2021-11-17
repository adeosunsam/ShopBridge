using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopBridge_data.Contexts;
using ShopBridge_model;

namespace ShopBridge_api.StartupExtension
{
    public static class IdentityExtension
    {
        public static void ConfigureIdentity(this IServiceCollection service)
        {
            new IdentityBuilder(
                service.AddIdentity<AppUsers, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                }).UserType, typeof(IdentityRole), service)
                .AddEntityFrameworkStores<ShopDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
