using System;
using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.People.Domain;
using Armory.Ranks.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Armory.Test.People.Infrastructure
{
    [TestFixture]
    public class InMemoryPeopleRepository : PeopleInfrastructureTestCase
    {
        private static readonly string ArmoryUserId = Guid.NewGuid().ToString();

        [Test]
        [Order(1)]
        public async Task Save_ShouldSavePerson()
        {
            var person = new Person("0006", "Diego", null, "Angulo", "Roman", ArmoryUserId)
            {
                Degree = new Degree("SL", 1)
                {
                    Id = 1,
                    Rank = new Rank("Soldado")
                    {
                        Id = 1
                    }
                }
            };

            await Repository.Save(person);
        }

        [Test]
        [Order(2)]
        public async Task SearchAll_ShouldReturnsAllPeople()
        {
            var people = await Repository.SearchAll();

            people.Should().HaveCount(1);
        }

        [Test]
        [Order(3)]
        public async Task SearchAllByRank_ShouldReturnsOnlyPeopleInRank()
        {
            var people = await Repository.SearchAllByRank("Soldado");

            people.Should().HaveCount(1);
        }

        [Test]
        [Order(4)]
        public async Task SearchAllByRank_ShouldReturnsEmpty()
        {
            var people = await Repository.SearchAllByRank("SL");

            people.Should().HaveCount(0);
        }

        [Test]
        [Order(5)]
        public async Task Find_ShouldReturnPerson()
        {
            var person = await Repository.Find("0006");

            person.Should().NotBeNull();
            person.Id.Should().Be("0006");
        }

        [Test]
        [Order(6)]
        public async Task Find_ShouldReturnNull()
        {
            var person = await Repository.Find("0005");

            person.Should().BeNull();
        }

        [Test]
        [Order(7)]
        public async Task FindByArmoryUserId_ShouldReturnPerson()
        {
            var person = await Repository.FindByArmoryUserId(ArmoryUserId);

            person.Should().NotBeNull();
            person.ArmoryUserId.Should().Be(ArmoryUserId);
        }

        [Test]
        [Order(8)]
        public async Task FindByArmoryUserId_ShouldReturnNull()
        {
            var person = await Repository.FindByArmoryUserId(Guid.NewGuid().ToString());

            person.Should().BeNull();
        }
    }
}
