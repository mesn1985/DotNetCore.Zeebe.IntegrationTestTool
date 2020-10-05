using Microsoft.AspNetCore.Mvc;
using ZeebeBscProj.API.Extensions;
using ZeebeBscProj.Models.WorkerModels;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Controllers
{

    public class WorkerController : Controller
    {
        private readonly IWorkerRepo repo;
        public WorkerController(IWorkerRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
         => View(new ZeebeWorkerModel().AsDefault());
        

        [HttpPost]
        public IActionResult DeployWorker([FromForm] ZeebeWorkerModel model)
        {
            if (ModelState.IsValid)
            {
                repo.DeployWorker(model);
                return RedirectToAction(nameof(Index));
            }
            return BadRequest(ModelState);
        }
        public IActionResult StopWorker(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            repo.RemoveWorker(name);
            return RedirectToAction(nameof(Index));
        }
    }

}