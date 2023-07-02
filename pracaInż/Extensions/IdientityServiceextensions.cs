using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.Identity;
using System.Text;

namespace pracaInż.Extensions
{
    public static class IdientityServiceextensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, 
            IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseMySql(config.GetConnectionString("IdentityConnection"),
                    ServerVersion.AutoDetect(config.GetConnectionString("IdentityConnection")));

            });

            services.AddIdentityCore<AppUser>(options =>
            {
                // Opcje identyfikacji
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization();

            return services;
        }
    }
}
