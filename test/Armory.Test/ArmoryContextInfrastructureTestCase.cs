using System;
using System.Linq;
using Armory.Api;
using Armory.Shared.Helpers;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Test.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Test
{
    public class ArmoryContextInfrastructureTestCase : InfrastructureTestCase<Startup>, IDisposable
    {
        public void Dispose()
        {
            Finish();
        }

        protected override void Setup()
        {
        }

        protected override Action<IServiceCollection> Services()
        {
            return services =>
            {
                var descriptor =
                    services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ArmoryDbContext>));
                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();


                services.AddAutoMapper(AssemblyHelper.GetInstance(Assemblies.Armory));
                services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Armory));
                services.AddAutoMapper(typeof(Startup));

                var serviceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
                services.AddDbContext<ArmoryDbContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                    options.UseInternalServiceProvider(serviceProvider);
                });
            };
        }
    }
}
