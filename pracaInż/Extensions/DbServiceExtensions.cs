using Microsoft.EntityFrameworkCore;
using pracaInż.Data;

namespace pracaInż.Extensions
{
    public static class DbServiceExtensions
    {
        public static IServiceCollection AddDBServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<AppDbcontext>(options =>
            {
                options.UseMySql(config.GetConnectionString("ProjektDB"),
                    ServerVersion.AutoDetect(config.GetConnectionString("ProjektDB")));
            });


            return services;
        }
    }
}
