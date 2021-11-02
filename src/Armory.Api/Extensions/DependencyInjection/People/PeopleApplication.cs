using Armory.People.Application.CheckExists;
using Armory.People.Application.Create;
using Armory.People.Application.Delete;
using Armory.People.Application.Find;
using Armory.People.Application.SearchAll;
using Armory.People.Application.SearchAllByRank;
using Armory.People.Application.SearchAllByRole;
using Armory.People.Application.SearchByArmoryUserId;
using Armory.People.Application.Update;
using Armory.People.Application.UpdateDegree;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Api.Extensions.DependencyInjection.People
{
    public static class PeopleApplication
    {
        public static IServiceCollection AddPeopleApplication(this IServiceCollection services)
        {
            services.AddScoped<PersonCreator, PersonCreator>();
            services.AddScoped<PersonDeleter, PersonDeleter>();
            services.AddScoped<PeopleSearcher, PeopleSearcher>();
            services.AddScoped<PeopleByRoleSearcher, PeopleByRoleSearcher>();
            services.AddScoped<PersonByArmoryUserIdSearcher, PersonByArmoryUserIdSearcher>();
            services.AddScoped<PeopleByRankSearcher, PeopleByRankSearcher>();
            services.AddScoped<PersonFinder, PersonFinder>();
            services.AddScoped<PersonUpdater, PersonUpdater>();
            services.AddScoped<PersonExistsChecker, PersonExistsChecker>();
            services.AddScoped<PersonDegreeUpdater, PersonDegreeUpdater>();

            return services;
        }
    }
}
