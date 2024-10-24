using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Modules
{
    public static class DataContextModule
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DevFreelaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevFreela"))
                //options.UseInMemoryDatabase("DevFreela")
            );

            return services;
        }
    }
}
