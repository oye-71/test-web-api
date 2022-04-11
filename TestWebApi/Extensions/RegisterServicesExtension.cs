using TestWebApi.DataManagement.Interfacage.DbEntities;
using TestWebApi.DataManagement.Interfacage.Repositories;
using TestWebApi.DataManagement.Models;
using TestWebApi.DataManagement.Repositories;

namespace TestWebApi.Web.Extensions
{
    public static class RegisterServicesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
