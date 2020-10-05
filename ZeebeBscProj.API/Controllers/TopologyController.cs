using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZeebeBscProj.API.Controllers
{ 
    public class TopologyController : Controller
    { 
        [HttpGet]
        public IActionResult Index()
        =>  View();
    }

}