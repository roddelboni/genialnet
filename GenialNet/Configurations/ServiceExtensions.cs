using GenialNet.Data.Context;
using GenialNet.Data.Repositories;
using GenialNet.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GenialNet.Api.Configurations
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GenialNetContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ReadContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ReadConnection")));

            services.AddDbContext<WriteContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WriteConnection")));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoFornecedorRepository, ProdutoFornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        }
    }
}
