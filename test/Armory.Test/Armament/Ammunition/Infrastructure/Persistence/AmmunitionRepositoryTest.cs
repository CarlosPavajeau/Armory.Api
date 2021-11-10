using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Armory.Test.Armament.Ammunition.Infrastructure.Persistence
{
    public class AmmunitionRepositoryTest : AmmunitionInfrastructureTestCase
    {
        [Test]
        [Order(1)]
        public async Task Save_Should_Save_Ammunition()
        {
            var ammunition = new Armory.Armament.Ammunition.Domain.Ammunition("Guerra", "INDUMIL", "9 mm", "L20", 100)
            {
                FlightCode = "ESDEF105"
            };

            await Repository.Save(ammunition);
            Assert.Pass();
        }

        [Test]
        [Order(2)]
        public async Task SearchAll_Should_Return_All_Ammunition()
        {
            var result = await Repository.SearchAll();

            result.Should().NotBeNull().And.HaveCount(1);
        }

        [Test]
        [Order(3)]
        public async Task SearchAllByFlightCode_Should_Return_All_Ammunition_By_FlightCode()
        {
            var result = await Repository.SearchAllByFlight("ESDEF105");

            result.Should().NotBeNull().And.HaveCount(1);
        }

        [Test]
        [Order(4)]
        public async Task Find_Should_Return_Ammunition()
        {
            var result = await Repository.Find("L20");

            result.Should().NotBeNull();
        }

        [Test]
        [Order(5)]
        public async Task Find_Should_Return_Null_When_Ammunition_Not_Found()
        {
            var result = await Repository.Find("L21");

            result.Should().BeNull();
        }
    }
}
