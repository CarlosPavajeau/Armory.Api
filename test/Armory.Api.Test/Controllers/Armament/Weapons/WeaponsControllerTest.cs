using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Weapons;
using Armory.Api.Controllers.Armament.Weapons.Requests;
using Armory.Armament.Weapons.Application;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Application.Find;
using Armory.Armament.Weapons.Application.GenerateQR;
using Armory.Armament.Weapons.Application.SearchAll;
using Armory.Armament.Weapons.Application.SearchAllByFlight;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Armory.Api.Test.Controllers.Armament.Weapons
{
    [TestFixture]
    public class WeaponsControllerTest : ApiTest
    {
        [SetUp]
        public void SetUp()
        {
            _controller = new WeaponsController(Mediator.Object, Provider.GetService<IMapper>());
        }

        private readonly IImmutableList<WeaponResponse> _weapons = ImmutableList.Create(new WeaponResponse
        {
            Serial = "00240",
            Type = "Subametralladora",
            Mark = "Beretta",
            Model = "MX4 Storm",
            Caliber = "9 mm",
            NumberOfProviders = 3,
            ProviderCapacity = 30,
            FlightCode = "ESDEF105"
        }, new WeaponResponse
        {
            Serial = "25002233",
            Type = "Fusil",
            Mark = "Nordico",
            Model = "CQ",
            Caliber = "5.56 mm",
            NumberOfProviders = 5,
            ProviderCapacity = 20,
            FlightCode = "ESEG105"
        });

        private WeaponsController _controller;

        private void ShouldHaveSave()
        {
            Mediator.Verify(x => x.Send(It.IsAny<CreateWeaponCommand>(), CancellationToken.None), Times.AtLeastOnce());
        }

        [Test]
        [Order(1)]
        public async Task Should_be_save_weapon()
        {
            Mediator.Setup(x => x.Send(It.IsAny<CreateWeaponCommand>(), CancellationToken.None)).Verifiable();
            Mediator.Setup(x => x.Send(It.IsAny<GenerateWeaponQrQuery>(), CancellationToken.None))
                .ReturnsAsync(new MemoryStream());

            var result = await _controller.RegisterWeapon(new CreateWeaponRequest
            {
                Serial = "00240",
                Type = "Subametralladora",
                Mark = "Beretta",
                Model = "MX4 Storm",
                Caliber = "9 mm",
                NumberOfProviders = 3,
                ProviderCapacity = 30,
                FlightCode = "ESDEF105"
            });

            ShouldHaveSave();

            Assert.NotNull(result);
            Assert.IsInstanceOf<FileStreamResult>(result);
        }

        [Test]
        [Order(2)]
        public async Task Should_be_get_all_weapons()
        {
            Mediator.Setup(x => x.Send(It.IsAny<SearchAllWeaponsQuery>(), CancellationToken.None))
                .ReturnsAsync(_weapons);

            var result = (await _controller.GetWeapons()).Result as OkObjectResult;
            Assert.IsNotNull(result);

            var value = result.Value as IEnumerable<WeaponResponse>;
            Assert.IsNotNull(value);
            Assert.AreEqual(2, value.Count());
        }

        [Test]
        [Order(3)]
        public async Task Should_be_get_all_weapons_by_flight()
        {
            Mediator.Setup(x => x.Send(It.IsAny<SearchAllWeaponsByFlightQuery>(), CancellationToken.None))
                .ReturnsAsync((SearchAllWeaponsByFlightQuery query, CancellationToken _) =>
                    _weapons.Where(w => w.FlightCode == query.FlightCode));

            const string flightCode = "ESEG105";
            var result = (await _controller.GetWeaponsByFlight(flightCode)).Result as OkObjectResult;
            Assert.IsNotNull(result);

            var value = result.Value as IEnumerable<WeaponResponse>;
            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.Count());
        }

        [Test]
        [Order(4)]
        public async Task Should_be_get_weapon()
        {
            Mediator.Setup(x => x.Send(It.IsAny<FindWeaponQuery>(), CancellationToken.None))
                .ReturnsAsync((FindWeaponQuery query, CancellationToken _) =>
                    _weapons.FirstOrDefault(w => w.Serial == query.Serial));

            var result = (await _controller.GetWeapon("00240")).Result as OkObjectResult;
            Assert.IsNotNull(result);

            var value = result.Value as WeaponResponse;
            Assert.IsNotNull(value);
            Assert.AreEqual("00240", value.Serial);
        }

        [Test]
        [Order(5)]
        public async Task Should_not_be_get_weapon()
        {
            const string serial = "111";

            var result = (await _controller.GetWeapon(serial)).Result as NotFoundObjectResult;
            Assert.IsNotNull(result);

            var details = result.Value as ValidationProblemDetails;
            Assert.IsNotNull(details);
            Assert.IsTrue(details.Errors.TryGetValue("WeaponNotFound", out var errors));
            Assert.IsNotEmpty(errors);
            Assert.AreEqual($"No se encontró ningun arma con el número de serie '{serial}'.", errors[0]);
        }
    }
}
