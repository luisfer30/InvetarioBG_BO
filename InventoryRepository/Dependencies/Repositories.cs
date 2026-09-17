using InventoryRepository.Context;
using InventoryRepository.Converter;
using InventoryRepository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryRepository.Dependencies
{
    public static class Repositories
    {
        public static void RepositoriesDI(this IServiceCollection services, IConfiguration config)
        {
           services.AddDbContext<InventoryContext>(options =>
           {
               options.UseSqlServer(config.GetConnectionString("Stock"));
           });

            services.AddTransient(typeof(BaseRepository<>));

            services.AddAutoMapper(am => am.AddProfile<AutoMapperProfiler>());
            
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<ProductoRepository>();
            services.AddScoped<ProveedorRepository>();
            services.AddScoped<StockRepository>();
        }
    }
}
