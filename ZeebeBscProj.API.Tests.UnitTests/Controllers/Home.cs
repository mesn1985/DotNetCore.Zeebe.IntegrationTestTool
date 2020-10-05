using Microsoft.AspNetCore.Mvc;
using Xunit;
using ZeebeBscProj.API.Controllers;

namespace ZeebeBscProj.API.Tests.UnitTests.Controllers
{
    public class Home
    {
        [Fact]
        public void Index_returns_a_view_with_no_model()
        {
            //Arrange
            var uut = new HomeController();

            //Act
            var result = uut.Index();

            //Act
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.Null(viewResult.Model);
        }
    }
}
