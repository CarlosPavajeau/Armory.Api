using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.Fireteams.Domain;
using Armory.Ranks.Domain;
using Armory.Troopers.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Armory.Test.Troopers.Infrastructure.Persistence
{
    [TestFixture]
    public class TroopersRepositoryTest : TroopersInfrastructureTestCase
    {
        [Test]
        [Order(1)]
        public async Task Save_ShouldSaveTroop()
        {
            var troop = new Troop(
                "1007710551",
                "Gedinson",
                "Andres",
                "Castaño",
                "Santa",
                "ESCON1051",
                1)
            {
                Degree = new Degree("SL", 1)
                {
                    Id = 1,
                    Rank = new Rank("Soldado")
                },
                Fireteam = new Fireteam("ESCON1051", "Escuadra", "123", "ESCON1050")
            };

            await Repository.Save(troop);

            Assert.Pass();
        }

        [Test]
        [Order(2)]
        public async Task SearchAll_ShouldReturnsAllTroopers()
        {
            var troopers = await Repository.SearchAll();

            troopers.Should().HaveCount(1);
        }

        [Test]
        [Order(3)]
        public async Task SearchAllByFireTeam_ShouldReturnsOnlyTroopersInFireTeam()
        {
            var troopers = await Repository.SearchAllByFireTeam("ESCON1051");

            troopers.Should().HaveCount(1);
        }

        [Test]
        [Order(4)]
        public async Task SearchAllByFireTeam_ShouldReturnsEmpty()
        {
            var troopers = await Repository.SearchAllByFireTeam("ESCON105");

            troopers.Should().HaveCount(0);
        }

        [Test]
        [Order(5)]
        public async Task Find_ShouldReturnTroop()
        {
            var troop = await Repository.Find("1007710551");

            troop.Should().NotBeNull();
            troop.Id.Should().Be("1007710551");
        }

        [Test]
        [Order(6)]
        public async Task Find_ShouldReturnNull()
        {
            var troop = await Repository.Find("100771055");

            troop.Should().BeNull();
        }
    }
}
