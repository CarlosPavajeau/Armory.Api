using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armory.Api.Controllers.Ranks;
using Armory.Api.Controllers.Ranks.Requests;
using Armory.Ranks.Application;
using Armory.Ranks.Application.Create;
using Armory.Ranks.Application.Find;
using Armory.Ranks.Application.SearchAll;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Armory.Api.Test.Controllers.Ranks
{
    [TestFixture]
    public class RanksControllerTest : ApiTest
    {
        [SetUp]
        public void SetUp()
        {
            _controller = new RanksController(Mediator.Object, Provider.GetService<IMapper>());
        }

        private RanksController _controller;

        [Test]
        [Order(1)]
        public async Task Register_A_Valid_Rank()
        {
            Mediator.Setup(x => x.Send(It.IsAny<CreateRankCommand>(), CancellationToken.None)).Verifiable();

            var result = await _controller.RegisterRank(new CreateRankRequest
            {
                Name = "Estudiante"
            });

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        [Order(2)]
        public async Task Register_An_Invalid_Rank()
        {
            Mediator.Setup(x => x.Send(It.IsAny<CreateRankCommand>(), CancellationToken.None))
                .Throws(new DbUpdateException());

            var result = await _controller.RegisterRank(new CreateRankRequest());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        [Order(3)]
        public async Task Get_All_Ranks()
        {
            Mediator.Setup(x => x.Send(It.IsAny<SearchAllRanksQuery>(), CancellationToken.None)).ReturnsAsync(
                new List<RankResponse>
                {
                    new() { Id = 1, Name = "Estudiante" }
                });

            var result = await _controller.GetRanks();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<IEnumerable<RankResponse>>(okResult.Value);

            var value = okResult.Value as IEnumerable<RankResponse>;
            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.Count());
        }

        [Test]
        [Order(4)]
        public async Task Get_An_Existent_Rank()
        {
            Mediator.Setup(x => x.Send(It.IsAny<FindRankQuery>(), CancellationToken.None))
                .ReturnsAsync((FindRankQuery query, CancellationToken _) =>
                    query.Id == 2 ? null : new RankResponse { Id = 1, Name = "Estudiante" });

            var result = await _controller.GetRank(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<RankResponse>(okResult.Value);

            var value = okResult.Value as RankResponse;
            Assert.IsNotNull(value);
            Assert.AreEqual(1, value.Id);
        }

        [Test]
        [Order(5)]
        public async Task Get_A_Non_Existent_Rank()
        {
            var result = await _controller.GetRank(2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);

            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.IsNotNull(notFoundResult);

            var validationDetails = notFoundResult.Value as ValidationProblemDetails;
            Assert.IsNotNull(validationDetails);
            Assert.IsTrue(validationDetails.Errors.TryGetValue("RankNotFound", out var errors));
            Assert.IsTrue(errors.Any());
            Assert.AreEqual("No se encontró ningun rango con el código '2'.", errors[0]);
        }
    }
}
