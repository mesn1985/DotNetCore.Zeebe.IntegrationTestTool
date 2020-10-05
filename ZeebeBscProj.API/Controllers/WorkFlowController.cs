using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZeebeBscProj.API.Extensions;
using ZeebeBscProj.Models.WorkFlowModels;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Controllers
{
    public class WorkFlowController : Controller
    {
        private readonly IWorkflowRepo repo;
        public WorkFlowController(IWorkflowRepo repo) 
            => this.repo = repo;
        [HttpPost]
        public async Task<IActionResult> RequestWorkFlowInstance([FromForm] WorkFlowInstanceRequest workFlowInstanceRequest)
        {
            if (ModelState.IsValid)
            {
               await repo.RequestWorkFlowInstanceAsync(workFlowInstanceRequest);
               return RedirectToAction(nameof(IndexDeployWorkFlow));
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult IndexDeployWorkFlow()
            => View();
        [HttpPost]
        public async Task<IActionResult> DeployWorkFlow(IFormFile file)
        {
            #warning Unchecked file is passed through
            if (file.Length < 1)
                return BadRequest();//TODO more file evaluation is needed

            var fileBytes = await file.ToByteArrayAsync();

            repo.DeployWorkFlow(fileBytes);
            return RedirectToAction(nameof(IndexDeployWorkFlow));

        }
    }
}