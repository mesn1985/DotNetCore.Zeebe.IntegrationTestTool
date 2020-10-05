using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using Xunit;
using ZeebeBscProj.API.Components.Topology;
using ZeebeBscProj.Models.TopologyRequestModels;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Tests.UnitTests.Components
{
    public class Topology
    {
        [Fact]
        public void InvokeAsync_returns_a_View_With_IEnumerable_Topology_request_model()
        {
            //Arrange
            var uut = new TopologyComponent(new Mock<ITopologyRepo>().Object);

            //Act
            var result = uut.InvokeAsync().Result;

            //Arrange
            var viewComponentResult = Assert.IsAssignableFrom<ViewViewComponentResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ZeebeBroker>>(viewComponentResult.ViewData.Model);
        }
                

        
    }
}
