using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Equipments;
using Armory.Api.Controllers.Armament.Equipments.Requests;
using Armory.Armament.Equipments.Application;
using Armory.Armament.Equipments.Application.Create;
using Armory.Armament.Equipments.Application.Find;
using Armory.Armament.Equipments.Application.SearchAll;
using Armory.Armament.Equipments.Application.SearchAllByFlight;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Armory.Api.Test.Controllers.Armament.Equipments
{
    [TestFixture]
    public class EquipmentsControllerTest : ApiTest
    {
        [SetUp]
        public void SetUp()
        {
            _controller = new EquipmentsController(Mediator.Object, Provider.GetService<IMapper>());
        }

        private EquipmentsController _controller;

        private readonly IImmutableList<EquipmentResponse> _equipments = ImmutableList.Create(new EquipmentResponse
        {
            Serial = "24H-SP3",
            Type = "Chaleco Antiesquirlas",
            Model = "LHL1-PT",
            QuantityAvailable = 25,
            FlightCode = "ESCON105"
        }, new EquipmentResponse
        {
            Serial = "CWF20120769",
            Type = "Placa Antibala",
            Model = "Welcron IV UHMWPE+AL203",
            QuantityAvailable = 16,
            FlightCode = "ESDEF105"
        });

        private void ShouldHaveSave()
        {
            Mediator.Verify(x => x.Send(It.IsAny<CreateEquipmentCommand>(), CancellationToken.None),
                Times.AtLeastOnce());
        }

        [Test]
        [Order(1)]
        public async Task RegisterEquipment_ShouldRegisterEquipment()
        {
            Mediator.Setup(x => x.Send(It.IsAny<CreateEquipmentCommand>(), CancellationToken.None)).Verifiable();

            var result = await _controller.RegisterEquipment(new CreateEquipmentRequest
            {
                Serial = "CWF20120769",
                Type = "Placa Antibala",
                Model = "Welcron IV UHMWPE+AL203",
                QuantityAvailable = 16,
                FlightCode = "ESDEF105"
            });

            ShouldHaveSave();
            Assert.NotNull(result);
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        [Order(2)]
        public async Task GetEquipments_ShouldReturnsAllEquipments()
        {
            Mediator.Setup(x => x.Send(It.IsAny<SearchAllEquipmentsQuery>(), CancellationToken.None))
                .ReturnsAsync(_equipments);

            var result = (await _controller.GetEquipments()).Result as OkObjectResult;

            Assert.IsNotNull(result);
            var value = result.Value as IEnumerable<EquipmentResponse>;
            Assert.IsNotNull(value);
            Assert.IsNotEmpty(value);
        }

        [Test]
        [Order(3)]
        public async Task GetEquipments_ShouldReturnsOnlyEquipmentsOnFlight()
        {
            Mediator.Setup(x => x.Send(It.IsAny<SearchAllEquipmentsByFlightQuery>(), CancellationToken.None))
                .ReturnsAsync((SearchAllEquipmentsByFlightQuery query, CancellationToken _) =>
                    _equipments.Where(e => e.FlightCode == query.FlightCode));

            var result = (await _controller.GetEquipmentsByFlight("ESDEF105")).Result as OkObjectResult;

            Assert.IsNotNull(result);
            var value = result.Value as IEnumerable<EquipmentResponse>;
            Assert.IsNotNull(value);
            var equipments = value as EquipmentResponse[] ?? value.ToArray();
            Assert.IsNotEmpty(equipments);
            Assert.AreEqual(1, equipments.Length);
        }

        [Test]
        [Order(4)]
        public async Task GetEquipment_ShouldReturnAnEquipment()
        {
            Mediator.Setup(x => x.Send(It.IsAny<FindEquipmentQuery>(), CancellationToken.None))
                .ReturnsAsync((FindEquipmentQuery query, CancellationToken _) =>
                    _equipments.FirstOrDefault(e => e.Serial == query.Serial));
            const string serial = "CWF20120769";

            var result = (await _controller.GetEquipment(serial)).Result as OkObjectResult;

            Assert.IsNotNull(result);
            var value = result.Value as EquipmentResponse;
            Assert.IsNotNull(value);
            Assert.AreEqual(serial, value.Serial);
        }

        [Test]
        [Order(5)]
        public async Task GetEquipment_ShouldNotFoundEquipment()
        {
            const string serial = "CWF20120733";

            var result = (await _controller.GetEquipment(serial)).Result as NotFoundObjectResult;

            Assert.IsNotNull(result);
            var details = result.Value as ValidationProblemDetails;
            Assert.IsNotNull(details);
            Assert.IsTrue(details.Errors.TryGetValue("EquipmentNotFound", out var errors));
            Assert.IsNotEmpty(errors);
            Assert.AreEqual($"No se encontró ningun equipo especial o accesorio con el serial '{serial}'.", errors[0]);
        }
    }
}
