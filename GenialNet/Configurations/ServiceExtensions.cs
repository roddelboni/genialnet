using GenialNet.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GenialNet.Api.Configurations
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GenialNetContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
