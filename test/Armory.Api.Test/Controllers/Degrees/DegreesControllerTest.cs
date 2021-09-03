using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armory.Api.Controllers.Degrees;
using Armory.Api.Controllers.Degrees.Requests;
using Armory.Degrees.Application;
using Armory.Degrees.Application.Create;
using Armory.Degrees.Application.Find;
using Armory.Degrees.Application.SearchAll;
using Armory.Degrees.Application.SearchAllByRank;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Armory.Api.Test.Controllers.Degrees
{
    [TestFixture]
    public class DegreesControllerTest : ApiTest
    {
        [SetUp]
        public void SetUp()
        {
            _controller = new DegreesController(Mediator.Object, Provider.GetService<IMapper>());
        }

        private DegreesController _controller;

        private void ShouldHaveSave()
        {
            Mediator.Verify(x => x.Send(It.IsAny<CreateDegreeCommand>(), CancellationToken.None), Times.AtLeastOnce());
        }

        [Test]
        [Order(1)]
        public async Task Register_A_Valid_Degree()
        {
            Mediator.Setup(x => x.Send(It.IsAny<CreateDegreeCommand>(), CancellationToken.None)).Verifiable();

            var result = await _controller.RegisterDegree(new CreateDegreeRequest
            {
                Name = "Estudiante 1",
                RankId = 1
            });

            ShouldHaveSave();

            Assert.IsNotNull(result);
        }

        [Test]
        [Order(2)]
        public async Task Get_All_Degrees()
        {
            Mediator.Setup(x => x.Send(It.IsAny<SearchAllDegreesQuery>(), CancellationToken.None)).ReturnsAsync(
                new List<DegreeResponse>
                {
                    new() { Id = 1, Name = "Estudiante 1", RankName = "Estudiante" }
                });

            var result = await _controller.GetDegrees();
            Assert.IsNotNull(result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var value = okResult.Value as IEnumerable<DegreeResponse>;
            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.Count());
        }

        [Test]
        [Order(3)]
        public async Task Get_All_Degrees_By_Rank()
        {
            Mediator.Setup(x => x.Send(It.IsAny<SearchAllDegreesByRankQuery>(), CancellationToken.None)).ReturnsAsync(
                new List<DegreeResponse>
                {
                    new() { Id = 1, Name = "Estudiante 1", RankName = "Estudiante" }
                });

            var result = await _controller.GetDegreesByRank(1);
            Assert.IsNotNull(result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var value = okResult.Value as IEnumerable<DegreeResponse>;
            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.Count());
        }

        [Test]
        [Order(4)]
        public async Task Get_An_Existent_Degree()
        {
            Mediator.Setup(x => x.Send(It.IsAny<FindDegreeQuery>(), CancellationToken.None))
                .ReturnsAsync((FindDegreeQuery query, CancellationToken _) =>
                    query.Id != 1
                        ? null
                        : new DegreeResponse { Id = 1, Name = "Estudiante 1", RankName = "Estudiante" });

            var result = await _controller.GetDegree(1);
            Assert.IsNotNull(result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var value = okResult.Value as DegreeResponse;
            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.Id);
        }

        [Test]
        [Order(5)]
        public async Task Get_A_Non_Existent_Degree()
        {
            var result = await _controller.GetDegree(2);
            Assert.IsNotNull(result);

            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);

            var validationDetails = notFoundResult.Value as ValidationProblemDetails;
            Assert.IsNotNull(validationDetails);
            Assert.IsTrue(validationDetails.Errors.TryGetValue("DegreeNotFound", out var errors));
            Assert.IsTrue(errors.Any());
            Assert.AreEqual("No se encontró ningun grado con el código '2'.", errors[0]);
        }
    }
}
