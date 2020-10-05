using Microsoft.AspNetCore.Mvc;

namespace ZeebeBscProj.API.Tests.UnitTests.Extensions
{
    internal static class ControllerExtension
    {

        internal static void AddValidationError(this Controller controller)
        {
            controller.ModelState.AddModelError("TestError","Fail for test");
        }
    }
}
