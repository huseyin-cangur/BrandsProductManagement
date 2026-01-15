

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence
{
    public static class PersistenceServiceRegistiration
    {
         public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BrandsProductManagement")));

        
            return services;

        }
    }
}