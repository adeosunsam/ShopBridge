using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ShopBridge_api.GlobalErrorMiddleware;
using ShopBridge_api.StartupExtension;
using ShopBridge_data.Contexts;
using ShopBridge_data.SeederClass;
using ShopBridge_model;

namespace ShopBridge_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //setup database connection for both development and production
            services.AddDbContextAndConfigurations(Environment, Configuration);

            //setup identity extension in case you are looking to extend Policies
            services.ConfigureIdentity();

            services.AddControllers();

            //setup dependency injection
            services.ConfigureInjection();

            //configure automapper
            services.AutoMapperExtension();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopBridge_api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, UserManager<AppUsers> userManager,
            ShopDbContext context, RoleManager<IdentityRole> roleManager)
        {
            var env = app.ApplicationServices.GetService<IWebHostEnvironment>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopBridge_api v1"));

            RbaSeeder.Seeder(userManager, context, roleManager).Wait();

            //setup global error handling middleware
            app.UseMiddleware<ExceptionMiddleware>();

            //get result from a single project
            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
