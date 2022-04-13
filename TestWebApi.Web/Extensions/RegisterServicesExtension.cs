using TestWebApi.Business.Interfacage.Services;
using TestWebApi.Business.Services;
using TestWebApi.DataManagement.Interfacage.Repositories;
using TestWebApi.DataManagement.Repositories;

namespace TestWebApi.Web.Extensions
{
    public static class RegisterServicesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Cors policy for the angular application
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader();
                    builder.WithOrigins("http://localhost:4200");
                });
            });

            // Add generic services
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

            // Add Repositories
            services.AddTransient<IOrdinateurRepository, OrdinateurRepository>();
            services.AddTransient<IMagasinRepository, MagasinRepository>();
            services.AddTransient<IStockRepository, StockRepository>();

            // Add Services
            services.AddTransient<IOrdinateurService, OrdinateurService>();
            services.AddTransient<IMagasinService, MagasinService>();

            return services;
        }
    }
}
