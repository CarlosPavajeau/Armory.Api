using System;
using System.Threading.Tasks;
using Armory.Degrees.Domain;
using Armory.People.Domain;
using Armory.Squads.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Armory.Test.Squads.Infrastructure.Persistence
{
    [TestFixture]
    public class InMemorySquadsRepositoryTest : SquadsInfrastructureTestCase
    {
        [Test]
        [Order(1)]
        public async Task Save_ShouldSaveSquad()
        {
            var squad = new Squad("ESDEB105", "Escuadrón de Seguridad y Defensa de Bases 105", "0006")
            {
                Owner = new Person("0006", "Diego", null, "Angulo", "Roman", Guid.NewGuid().ToString())
                {
                    Degree = new Degree("SL", 1)
                }
            };

            await Repository.Save(squad);
        }

        [Test]
        [Order(2)]
        public async Task SearchAll_ShouldReturnsAllSquads()
        {
            var squads = await Repository.SearchAll();

            squads.Should().HaveCount(1);
        }

        [Test]
        [Order(3)]
        public async Task Find_ShouldReturnSquad()
        {
            var squad = await Repository.Find("ESDEB105");

            squad.Should().NotBeNull();
            squad.Code.Should().Be("ESDEB105");
        }

        [Test]
        [Order(4)]
        public async Task Find_ShouldReturnNull()
        {
            var squad = await Repository.Find("ESDEB1056");

            squad.Should().BeNull();
        }
    }
}
