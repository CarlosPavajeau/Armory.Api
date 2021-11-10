using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.Flights.Domain;
using Armory.People.Domain;
using Armory.Ranks.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Armory.Test.Flights.Infrastructure.Persistence
{
    public class FlightsRepositoryTest : FlightsInfrastructureTestCase
    {
        [Test]
        [Order(1)]
        public async Task Save_ShouldSaveFlight()
        {
            var flight = new Flight("ESCON105", "Escuadrilla de Control Operacional 105", "123")
            {
                Commander = new Person("0006", "Diego", null, "Angulo", "Roman", null)
                {
                    Degree = new Degree("SL", 1)
                    {
                        Id = 1,
                        Rank = new Rank("Soldado")
                        {
                            Id = 1
                        }
                    }
                },
                SquadCode = "ESDEB105"
            };

            await Repository.Save(flight);
            Assert.Pass();
        }

        [Test]
        [Order(2)]
        public async Task SearchAll_ShouldReturnsAllFlights()
        {
            var flights = await Repository.SearchAll();

            flights.Should().HaveCount(1);
        }

        [Test]
        [Order(3)]
        public async Task Find_ShouldReturnFlight()
        {
            var flight = await Repository.Find("ESCON105");

            flight.Should().NotBeNull();
            flight.Code.Should().Be("ESCON105");
        }

        [Test]
        [Order(4)]
        public async Task Find_ShouldReturnNull()
        {
            var flight = await Repository.Find("ESCON104");

            flight.Should().BeNull();
        }
    }
}
