using System;
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Armory.Api", Version = "v1"});

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example 'Authorization: Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        ArraySegment<string>.Empty
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Armory.Api v1"));

            return app;
        }

        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            return app;
        }
    }
}
