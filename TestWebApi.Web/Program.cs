using Microsoft.EntityFrameworkCore;
using TestWebApi.DataManagement.DbManagement;
using TestWebApi.Web.Extensions;
using TestWebApi.Web.Middlewares;

namespace TestWebApi.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ComputersDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("ComputersDbStr")));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.RegisterServices();

            var app = builder.Build();

            // Inits database with standard data
            CreateDbIfNotExists(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<ApiKeyMiddleware>(); // Api Key management : https://www.c-sharpcorner.com/article/using-api-key-authentication-to-secure-asp-net-core-web-api/
            app.MapControllers();

            app.Run();
        }

        public static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ComputersDbContext>();
                    ComputersDbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                    throw;
                }
            }
        }
    }
}
