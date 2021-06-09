using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Bus.Query;
using Armory.Shared.Infrastructure.Bus.Command;
using Armory.Shared.Infrastructure.Bus.Event;
using Armory.Shared.Infrastructure.Bus.Query;
using Armory.Users.Domain;
using Armory.Users.Infrastructure.Identity;
using Armory.Users.Infrastructure.Persistence;
using Armory.Users.Infrastructure.Persistence.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IArmoryUserRepository, MySqlArmoryUserRepository>();
            services.AddScoped<InMemoryApplicationEventBus, InMemoryApplicationEventBus>();
            services.AddScoped<IEventBus, InMemoryApplicationEventBus>();

            services.AddIdentity<ArmoryUser, ArmoryRole>()
                .AddEntityFrameworkStores<ArmoryUserDbContext>()
                .AddErrorDescriber<SpanishIdentityErrorDescriber>()
                .AddDefaultTokenProviders();

            services.AddScoped<ArmoryUserDbContext, ArmoryUserDbContext>();
            services.AddDbContext<ArmoryUserDbContext>(
                options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);

            services.AddScoped<ICommandBus, InMemoryCommandBus>();
            services.AddScoped<IQueryBus, InMemoryQueryBus>();

            services.Configure<SecretKey>(configuration.GetSection("SecretKey"));

            return services;
        }
    }
}
