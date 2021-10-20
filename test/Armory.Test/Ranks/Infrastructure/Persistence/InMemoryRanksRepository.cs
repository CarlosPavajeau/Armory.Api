using System.Threading.Tasks;
using Armory.Ranks.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Armory.Test.Ranks.Infrastructure.Persistence
{
    [TestFixture]
    [Order(1)]
    public class InMemoryRanksRepository : RanksInfrastructureTestCase
    {
        [Test]
        [Order(1)]
        public async Task Save_ShouldSaveRank()
        {
            var rank = new Rank("Soldado");
            await Repository.Save(rank);
        }

        [Test]
        [Order(2)]
        public async Task SearchAll_ShouldReturnsAllRanks()
        {
            var ranks = await Repository.SearchAll();
            ranks.Should().HaveCount(1);
        }

        [Test]
        [Order(3)]
        public async Task Find_ShouldReturnRank()
        {
            var rank = await Repository.Find(1);

            rank.Id.Should().Be(1);
            rank.Name.Should().Be("Soldado");
        }

        [Test]
        [Order(4)]
        public async Task Find_ShouldReturnNull()
        {
            var rank = await Repository.Find(2);

            rank.Should().BeNull();
        }
    }
}
