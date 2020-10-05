using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ZeebeBscProj.API.Controllers;
using ZeebeBscProj.API.Tests.UnitTests.Extensions;
using ZeebeBscProj.Models.WorkFlowModels;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Tests.UnitTests.Controllers
{
    public class WorkFlow : UnitTestBase
    {
        
        [Fact]
        public void IndexDeployWorkFlow_Returns_View()
        {
            //Arrange
            var uut = new WorkFlowController(Mock<IWorkflowRepo>().Object);

            //Act
            var result = uut.IndexDeployWorkFlow();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

        }
        
        [Fact]
        public void RequestWorkFlowInstance_Returns_BadRequest_When_ModelState_Is_Invalid()
        {
            //Arrange
            var uut = new WorkFlowController(Mock<IWorkflowRepo>().Object);
            uut.AddValidationError();

            //Act
            var result = uut
                         .RequestWorkFlowInstance(Create<WorkFlowInstanceRequest>()).Result;

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }
        [Fact] // Exception should by handled by Asp.net and error pages
        public void RequestWorkFlowInstance_Throws_Excpetion_Upwards()
        {
            //Arrange
            var clientMock = new Mock<IWorkflowRepo>();
            clientMock.Setup(
                repo => 
                    repo.RequestWorkFlowInstanceAsync(Any<WorkFlowInstanceRequest>(), Any<string>()))
                      .Throws<Exception>();
            var uut = new WorkFlowController(clientMock.Object);

            //Act & Assert
            Assert.Throws<AggregateException>(() => 
                                         uut.RequestWorkFlowInstance(new Mock<WorkFlowInstanceRequest>().Object).Result);
        }
        [Fact]
        public void DeployWorkFlow__Returns_Redirect_To_Index_When_ModelState_Is_valid()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(file => file.Length).Returns(2);
            var uut = new WorkFlowController(Mock<IWorkflowRepo>().Object);

            //Act
            var result = uut.DeployWorkFlow(fileMock.Object).Result;

            //Assert
            var redirectActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("IndexDeployWorkFlow", redirectActionResult.ActionName);
            Assert.Null(redirectActionResult.ControllerName);
        }
        [Fact]
        public void DeployWorkFlow__Returns_BadRequst_When_ModelState_Is_Invalid()
        {
            //Arrange
            var fileMock = Mock<IFormFile>();
            fileMock.Setup(file => file.Length).Returns(0);
            var uut = new WorkFlowController(Mock<IWorkflowRepo>().Object);

            //Act
            var result = uut.DeployWorkFlow(fileMock.Object).Result;

            //Assert
            var redirectActionResult = Assert.IsType<BadRequestResult>(result);
           
        }
        [Fact]
        public void DeployWorkFlow_Throws_Exception_Upwards()
        {
            //Arrange
            var clientMock = Mock<IWorkflowRepo>();
            var fileMock = Mock<IFormFile>();

            fileMock.Setup(file => file.Length).Returns(2);
            clientMock.Setup(repo => repo
                                 .DeployWorkFlow(Any<byte[]>(), Any<string>()))
                      .Throws<Exception>();
            var uut = new WorkFlowController(clientMock.Object);

            //Act & Assert
            Assert.Throws<AggregateException>(()=>uut.DeployWorkFlow(fileMock.Object).Result);

        }
    }
}
