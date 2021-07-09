using System;
using System.Text;
using Armory.Armament.Ammunition.Domain;
using Armory.Armament.Ammunition.Infrastructure.Persistence;
using Armory.Armament.Weapons.Domain;
using Armory.Armament.Weapons.Infrastructure.Persistence;
using Armory.People.Domain;
using Armory.People.Infrastructure;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.Bus.Query;
using Armory.Shared.Infrastructure.Bus.Command;
using Armory.Shared.Infrastructure.Bus.Event;
using Armory.Shared.Infrastructure.Bus.Query;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Squadrons.Domain;
using Armory.Squadrons.Infrastructure.Persistence;
using Armory.Squads.Domain;
using Armory.Squads.Infrastructure.Persistence;
using Armory.Users.Domain;
using Armory.Users.Infrastructure.Identity;
using Armory.Users.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Armory.Api.Extensions
{
    public static class Infrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<InMemoryApplicationEventBus, InMemoryApplicationEventBus>();
            services.AddScoped<IEventBus, InMemoryApplicationEventBus>();

            services.AddIdentity<ArmoryUser, ArmoryRole>()
                .AddEntityFrameworkStores<ArmoryDbContext>()
                .AddErrorDescriber<SpanishIdentityErrorDescriber>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddScoped<ArmoryDbContext, ArmoryDbContext>();
            services.AddDbContext<ArmoryDbContext>(
                options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);

            services.AddScoped<ICommandBus, InMemoryCommandBus>();
            services.AddScoped<IQueryBus, InMemoryQueryBus>();

            services.Configure<SecretKey>(configuration.GetSection("SecretKey"));

            services.AddScoped<IArmoryUserRepository, MySqlArmoryUserRepository>();
            services.AddScoped<ISquadronRepository, MySqlSquadronRepository>();
            services.AddScoped<IPersonRepository, MySqlPersonRepository>();
            services.AddScoped<ISquadRepository, MySqlSquadRepository>();
            services.AddScoped<IWeaponsRepository, MySqlWeaponsRepository>();
            services.AddScoped<IAmmunitionRepository, MySqlAmmunitionRepository>();

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

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(configuration["SecretKey:Key"]);

            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(c =>
            {
                c.RequireHttpsMetadata = false;
                c.SaveToken = true;
                c.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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

        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app, RoleManager<ArmoryRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Developer").Result)
            {
                var developerRole = new ArmoryRole {Name = "Developer"};
                var result = roleManager.CreateAsync(developerRole).Result;
            }

            if (!roleManager.RoleExistsAsync("SquadronLeader").Result)
            {
                var squadronLeader = new ArmoryRole {Name = "SquadronLeader"};
                var result = roleManager.CreateAsync(squadronLeader).Result;
            }

            if (!roleManager.RoleExistsAsync("SquadLeader").Result)
            {
                var squadLeader = new ArmoryRole {Name = "SquadLeader"};
                var result = roleManager.CreateAsync(squadLeader).Result;
            }

            if (!roleManager.RoleExistsAsync("StoreLeader").Result)
            {
                var inventoryLeader = new ArmoryRole {Name = "StoreLeader"};
                var result = roleManager.CreateAsync(inventoryLeader).Result;
            }

            return app;
        }
    }
}
