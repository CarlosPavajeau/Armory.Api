using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.Fireteams.Domain;
using Armory.Flights.Domain;
using Armory.People.Domain;
using Armory.Ranks.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Armory.Test.FireTeams.Infrastructure.Persistence
{
    public class FireTeamsRepositoryTest : FireTeamsInfrastructureTestCase
    {
        [Test]
        [Order(1)]
        public async Task Save_ShouldSaveFireTeam()
        {
            var fireTeam = new Fireteam("ESCON1051", "Escuadra de Control Operacional 105", "00011", "ESCON105")
            {
                Flight = new Flight("ESCON105", "Escuadrilla de Control Operacional 105", "0006")
                {
                    SquadCode = "ESDEB105"
                },
                Owner = new Person("00011", "Andres", null, "Gamboa", "Rodriguez", null)
                {
                    Degree = new Degree("SL", 1)
                    {
                        Id = 1,
                        Rank = new Rank("Soldado")
                        {
                            Id = 1
                        }
                    }
                }
            };

            await Repository.Save(fireTeam);
            Assert.Pass();
        }

        [Test]
        [Order(2)]
        public async Task SearchAll_ShouldReturnsAllFireTeams()
        {
            var fireTeams = await Repository.SearchAll();

            fireTeams.Should().HaveCount(1);
        }

        [Test]
        [Order(3)]
        public async Task SearchAllByFlight_ShouldReturnsOnlyFireTeamsOnFlight()
        {
            var fireTeams = await Repository.SearchAllByFlight("ESCON105");

            fireTeams.Should().HaveCount(1);
        }

        [Test]
        [Order(4)]
        public async Task SearchAllByFlight_ShouldReturnsEmpty()
        {
            var fireTeams = await Repository.SearchAllByFlight("ESCON103");

            fireTeams.Should().HaveCount(0);
        }

        [Test]
        [Order(5)]
        public async Task Find_ShouldReturnFireTeam()
        {
            var fireTeam = await Repository.Find("ESCON1051");

            fireTeam.Should().NotBeNull();
            fireTeam.Code.Should().Be("ESCON1051");
        }

        [Test]
        [Order(6)]
        public async Task Find_ShouldReturnNull()
        {
            var fireTeam = await Repository.Find("ESCON101");

            fireTeam.Should().BeNull();
        }
    }
}
