using System;
using System.Collections.Generic;
using System.Text;
using Armory.Armament.Ammunition.Domain;
using Armory.Armament.Ammunition.Infrastructure.Persistence;
using Armory.Armament.Equipments.Domain;
using Armory.Armament.Equipments.Infrastructure.Persistence;
using Armory.Armament.Explosives.Domain;
using Armory.Armament.Explosives.Infrastructure.Persistence;
using Armory.Armament.Weapons.Domain;
using Armory.Armament.Weapons.Infrastructure.Persistence;
using Armory.Degrees.Domain;
using Armory.Degrees.Infrastructure.Persistence;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using Armory.Formats.AssignedWeaponMagazineFormats.Infrastructure.Persistence;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Infrastructure.Persistence;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Infrastructure.Persistence;
using Armory.People.Domain;
using Armory.People.Infrastructure.Persistence;
using Armory.Ranks.Domain;
using Armory.Ranks.Infrastructure.Persistence;
using Armory.Shared.Domain.Bus.Event;
using Armory.Shared.Domain.ClosedXML;
using Armory.Shared.Domain.Persistence.EntityFramework;
using Armory.Shared.Domain.Persistence.EntityFramework.Transactions;
using Armory.Shared.Helpers;
using Armory.Shared.Infrastructure.Bus.Event;
using Armory.Shared.Infrastructure.ClosedXML;
using Armory.Shared.Infrastructure.Persistence;
using Armory.Shared.Infrastructure.Persistence.EntityFramework;
using Armory.Shared.Infrastructure.Persistence.EntityFramework.Transactions;
using Armory.Squadrons.Domain;
using Armory.Squadrons.Infrastructure.Persistence;
using Armory.Squads.Domain;
using Armory.Squads.Infrastructure.Persistence;
using Armory.Troopers.Domain;
using Armory.Troopers.Infrastructure.Persistence;
using Armory.Users.Domain;
using Armory.Users.Infrastructure.Identity;
using Armory.Users.Infrastructure.Persistence;
using MediatR;
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
                options => options.UseMySql(
                        configuration.GetConnectionString("DefaultConnection"),
                        new MySqlServerVersion(new Version(8, 0, 26)),
                        builder => { builder.CommandTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds); })
                    .UseSnakeCaseNamingConvention()
                    .EnableDetailedErrors(),
                ServiceLifetime.Transient);

            services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Armory));
            services.AddAutoMapper(AssemblyHelper.GetInstance(Assemblies.Armory));

            services.Configure<SecretKey>(configuration.GetSection("SecretKey"));

            services.AddScoped<IArmoryUsersRepository, MySqlArmoryUsersRepository>();
            services.AddScoped<ISquadronsRepository, MySqlSquadronsRepository>();
            services.AddScoped<IPeopleRepository, MySqlPeopleRepository>();
            services.AddScoped<ISquadsRepository, MySqlSquadsRepository>();
            services.AddScoped<IWeaponsRepository, MySqlWeaponsRepository>();
            services.AddScoped<IAmmunitionRepository, MySqlAmmunitionRepository>();
            services.AddScoped<IEquipmentsRepository, MySqlEquipmentsRepository>();
            services.AddScoped<IExplosivesRepository, MySqlExplosivesRepository>();
            services.AddScoped<IRanksRepository, MySqlRanksRepository>();
            services.AddScoped<IDegreesRepository, MySqlDegreesRepository>();
            services.AddScoped<ITroopersRepository, MySqlTroopersRepository>();
            services
                .AddScoped<IWarMaterialAndSpecialEquipmentAssignmentFormatsRepository,
                    MySqlWarMaterialAndSpecialEquipmentAssignmentFormatsRepository>();
            services
                .AddScoped<IWarMaterialDeliveryCertificateFormatsRepository,
                    MySqlWarMaterialDeliveryCertificateFormatsRepository>();
            services
                .AddScoped<IAssignedWeaponMagazineFormatsRepository, MySqlAssignedWeaponMagazineFormatsRepository>();

            services.AddScoped<IUnitWork, UnitWork>();
            services.AddScoped<ITransactionInitializer, TransactionInitializer>();
            services.AddScoped<IWorksheetManager, WorksheetManager>();
            services.AddScoped<IEventBus, InMemoryEventBus>();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Armory.Api", Version = "v1" });

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

        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app, IConfiguration configuration)
        {
            var allowedUrls = configuration.GetSection("AllowedUrls").Get<List<string>>();
            app.UseCors(c =>
                c.WithOrigins(allowedUrls.ToArray()).AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            return app;
        }

        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app, RoleManager<ArmoryRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Developer").Result)
            {
                var developerRole = new ArmoryRole { Name = "Developer" };
                _ = roleManager.CreateAsync(developerRole).Result;
            }

            if (!roleManager.RoleExistsAsync("SquadronLeader").Result)
            {
                var squadronLeader = new ArmoryRole { Name = "SquadronLeader" };
                _ = roleManager.CreateAsync(squadronLeader).Result;
            }

            if (!roleManager.RoleExistsAsync("SquadLeader").Result)
            {
                var squadLeader = new ArmoryRole { Name = "SquadLeader" };
                _ = roleManager.CreateAsync(squadLeader).Result;
            }

            if (!roleManager.RoleExistsAsync("StoreLeader").Result)
            {
                var inventoryLeader = new ArmoryRole { Name = "StoreLeader" };
                _ = roleManager.CreateAsync(inventoryLeader).Result;
            }

            return app;
        }
    }
}
