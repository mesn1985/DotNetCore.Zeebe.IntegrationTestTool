using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ZeebeBscProj.API.Controllers;
using ZeebeBscProj.API.Tests.UnitTests.Extensions;
using ZeebeBscProj.Models.WorkerModels;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Tests.UnitTests.Controllers
{
    /// <summary>
    /// A smell when testing controllers, is that modelstate will always
    /// be valid, unless
    /// </summary>
    public class Worker :UnitTestBase
    {
        [Fact]
        public void DeployWorker_redirects_to_deployWorkerView_when_modelstate_is_valid()
        {
            //Arrange
            var uut = new WorkerController(Mock<IWorkerRepo>().Object);
            
            //Act
            var result = uut.DeployWorker(Create<ZeebeWorkerModel>());
           
            //Assert
            var redirectToAction = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index",redirectToAction.ActionName);
            Assert.Null(redirectToAction.ControllerName);
        }
        [Fact]
        public void DeployWorker_returns_bad_request_When_modelstate_is_invalid()
        {
            //Arrange
            var uut = new WorkerController(Mock<IWorkerRepo>().Object);
            uut.AddValidationError();

            //Act
            var result = uut.DeployWorker(Create<ZeebeWorkerModel>());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void DeployWorker_calls_DeployWorker_on_ZeebeClient_when_state_is_valid()
        {
            //Arrange
            var clientMock = Mock<IWorkerRepo>();
            var uut = new WorkerController(clientMock.Object);
            
            //Act
            uut.DeployWorker(Create<ZeebeWorkerModel>());

            //Assert
            clientMock.Verify(client => 
                                  client.DeployWorker(Any<ZeebeWorkerModel>(),Any<string>()),Times.Once);

        }
        /// <summary>
        /// Middleware should handle exceptions when controller throw an exception upwards
        /// </summary>
        [Fact]
        public void DeployWorker__throws_exception_upwards_when_an_exception_is_thrown()
        {
            //Arrange
            var mockZeebeWorkerClient = Mock<IWorkerRepo>();
            mockZeebeWorkerClient.Setup(repo =>
                                            repo.DeployWorker(Any<ZeebeWorkerModel>(),Any<string>()))
                                                        .Throws<Exception>();
            var uut = new WorkerController(mockZeebeWorkerClient.Object);

            //Act && Assert
            Assert.Throws<Exception>(() => uut.DeployWorker(Any<ZeebeWorkerModel>()));
        }
        [Fact]
        public void Index_Returns_View_with_ZeebeModel()
        {
            //Arrange
            var uut = new WorkerController(Mock<IWorkerRepo>().Object);

            //Act
            var result = uut.Index();
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ZeebeWorkerModel>(viewResult.ViewData.Model);
        }
        [Fact]
        public void StopWorker_redirects_to_deployWorkerView_when_name_string_is_not_null_or_Empty_string()
        {
            //Arrange
            var uut = new WorkerController(Mock<IWorkerRepo>().Object);

            //Act
            var result = uut.StopWorker("TestString");

            //Assert
            var redirectToAction = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index",redirectToAction.ActionName);
            Assert.Null(redirectToAction.ControllerName);

        }
        [Fact]
        public void StopWorker_return_badRequest_when_name_string_is_null()
        {
            //Arrange
            var uut = new WorkerController(Mock<IWorkerRepo>().Object);
            //Act
            var result = uut.StopWorker(null);
            //Assert
            Assert.IsType<BadRequestResult>(result);

        }
        [Fact]
        public void StopWorker_return_badRequest_when_name_string_is_empty()
        {
            //Arrange
            var uut = new WorkerController(Mock<IWorkerRepo>().Object);
            //Act
            var result = uut.StopWorker(string.Empty);
            //Assert
            Assert.IsType<BadRequestResult>(result);

        }
    }
}
