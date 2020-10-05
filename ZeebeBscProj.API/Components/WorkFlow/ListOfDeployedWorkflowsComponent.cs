using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Components.WorkFlow
{
    [ViewComponent(Name = "ListOfDeployedWorkflow")]
    public class ListOfDeployedWorkflowsComponent : ViewComponent
    {
        private readonly IElasticSearchZeebeRepo repo;

        public ListOfDeployedWorkflowsComponent(IElasticSearchZeebeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
            => View(repo.GetAllDeployedWorkFlows().OrderBy(wf => wf.Version));

        
        
    }
}
