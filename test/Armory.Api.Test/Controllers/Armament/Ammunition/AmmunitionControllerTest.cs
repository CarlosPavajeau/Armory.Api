using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Ammunition;
using Armory.Api.Controllers.Armament.Ammunition.Requests;
using Armory.Armament.Ammunition.Application;
using Armory.Armament.Ammunition.Application.Create;
using Armory.Armament.Ammunition.Application.Find;
using Armory.Armament.Ammunition.Application.SearchAll;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Armory.Api.Test.Controllers.Armament.Ammunition
{
    [TestFixture]
    public class AmmunitionControllerTest : ApiTest
    {
        [SetUp]
        public void SetUp()
        {
            _controller = new AmmunitionController(Mediator.Object, Provider.GetService<IMapper>());
        }

        private AmmunitionController _controller;

        private void ShouldHaveSave()
        {
            Mediator.Verify(x => x.Send(It.IsAny<CreateAmmunitionCommand>(), CancellationToken.None),
                Times.AtLeastOnce());
        }

        [Test]
        [Order(1)]
        public async Task Register_A_Valid_Ammunition()
        {
            Mediator.Setup(x => x.Send(It.IsAny<CreateAmmunitionCommand>(), CancellationToken.None)).Verifiable();

            var result = await _controller.RegisterAmmunition(new CreateAmmunitionRequest
            {
                Code = "ESCOM105",
                Type = "Guerra",
                Mark = "Indumil",
                Caliber = "5.56MM",
                Series = "NA",
                QuantityAvailable = 10
            });

            ShouldHaveSave();

            Assert.IsNotNull(result);
        }

        [Test]
        [Order(2)]
        public async Task Get_All_Ammunition()
        {
            Mediator.Setup(x => x.Send(It.IsAny<SearchAllAmmunitionQuery>(), CancellationToken.None)).ReturnsAsync(
                new List<AmmunitionResponse>
                {
                    new("ESCOM105", "Guerra", "Indumil", "5.56MM", "NA", "NA", 10)
                });

            var result = (await _controller.GetAmmunition()).Result as OkObjectResult;
            Assert.IsNotNull(result);

            var value = result.Value as IEnumerable<AmmunitionResponse>;
            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.Count());
            Assert.AreEqual("NA", value.ElementAt(0).Series);
        }

        [Test]
        [Order(3)]
        public async Task Get_An_Existent_Ammunition()
        {
            Mediator.Setup(x => x.Send(It.IsAny<FindAmmunitionQuery>(), CancellationToken.None))
                .ReturnsAsync((FindAmmunitionQuery query, CancellationToken _) =>
                    query.Code != "ESCOM105"
                        ? null
                        : new AmmunitionResponse("ESCOM105", "Guerra", "Indumil", "5.56MM", "NA", "NA", 10)
                );

            var result = (await _controller.GetAmmunition("ESCOM105")).Result as OkObjectResult;
            Assert.IsNotNull(result);

            var value = result.Value as AmmunitionResponse;
            Assert.IsNotNull(value);
            Assert.AreEqual("ESCOM105", value.Code);
        }

        [Test]
        [Order(4)]
        public async Task Get_A_Non_Existent_Degree()
        {
            var result = (await _controller.GetAmmunition("ESCOM106")).Result as NotFoundObjectResult;
            Assert.IsNotNull(result);

            var validationDetails = result.Value as ValidationProblemDetails;
            Assert.IsNotNull(validationDetails);
            Assert.IsTrue(validationDetails.Errors.TryGetValue("AmmunitionNotFound", out var errors));
            Assert.IsNotEmpty(errors);
            Assert.AreEqual("No se encontró ninguna munición con el código 'ESCOM106'.", errors[0]);
        }
    }
}
