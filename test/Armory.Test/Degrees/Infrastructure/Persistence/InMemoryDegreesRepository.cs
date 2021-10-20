using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.Ranks.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Armory.Test.Degrees.Infrastructure.Persistence
{
    [TestFixture]
    [Order(2)]
    public class InMemoryDegreesRepository : DegreesInfrastructureTestCase
    {
        [Test]
        [Order(1)]
        public async Task Save_ShouldSaveDegree()
        {
            var degree = new Degree("SL", 1);
            degree.Rank = new Rank("Soldado");

            await Repository.Save(degree);
        }

        [Test]
        [Order(2)]
        public async Task SearchAll_ShouldReturnsAllDegrees()
        {
            var degrees = await Repository.SearchAll();

            degrees.Should().HaveCount(1);
        }

        [Test]
        [Order(3)]
        public async Task SearchAllByRank_ShouldReturnsOnlyDegreesOnRank()
        {
            var degrees = await Repository.SearchAllByRank(1);

            degrees.Should().HaveCount(1);
        }

        [Test]
        [Order(4)]
        public async Task SearchAllByRank_ShouldReturnsEmptyList()
        {
            var degrees = await Repository.SearchAllByRank(10);

            degrees.Should().HaveCount(0);
        }

        [Test]
        [Order(5)]
        public async Task Find_ShouldReturnDegree()
        {
            var degree = await Repository.Find(1);

            degree.Should().NotBeNull();
            degree.Id.Should().Be(1);
            degree.Name.Should().Be("SL");
        }

        [Test]
        [Order(6)]
        public async Task Find_ShouldReturnNull()
        {
            var degree = await Repository.Find(10);

            degree.Should().BeNull();
        }
    }
}
