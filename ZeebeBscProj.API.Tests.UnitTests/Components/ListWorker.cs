using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using Xunit;
using ZeebeBscProj.API.Components.Worker;
using ZeebeBscProj.Models.WorkerModels;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Tests.UnitTests.Components
{
    public class ListWorker
    {
        [Fact]
        public void InvokeAsync_returns_a_View_with_IEnumerable_ZeebeWorkerModel()
        {
            //Arrange
            var uut =
                new ListOfWorkerComponent(new Mock<IWorkerRepo>().Object);
            //Act
            var result = uut.InvokeAsync().Result;

            //Arrange
            var viewComponentResult = Assert.IsAssignableFrom<ViewViewComponentResult>(result);
            var model = 
                Assert.IsAssignableFrom<IEnumerable<ZeebeWorkerModel>>(viewComponentResult.ViewData.Model);
        }
    }
}
