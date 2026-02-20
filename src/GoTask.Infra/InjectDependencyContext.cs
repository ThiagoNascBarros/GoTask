using GoTask.Domain.Data.Interface;
using GoTask.Domain.Security.Cryptography;
using GoTask.Domain.Security.Token;
using GoTask.Infra.DataAcess;
using GoTask.Infra.DataAcess.Repository;
using GoTask.Infra.Security.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoTask.Infra
{
    public static class InjectDependencyContext
    {

        public static void Injection(this IServiceCollection services, IConfiguration config)
        {
            AddContext(services, config);
            AddToken(services, config);
            AddServices(services);
        }

        private static void AddContext(this IServiceCollection services, IConfiguration config)
        {
            var stringConnection = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<GoTaskDbContext>(options =>
                options.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection)));
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        }

        private static void AddToken(this IServiceCollection services, IConfiguration config)
        {
            var experationTimeMinutes = config.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
            var signinKey = config.GetValue<string>("Settings:Jwt:SignInKey");

            services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(experationTimeMinutes, signinKey!));
        }
    }
}
