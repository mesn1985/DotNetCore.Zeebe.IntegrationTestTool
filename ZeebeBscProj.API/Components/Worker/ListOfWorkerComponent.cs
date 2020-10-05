using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Components.Worker
{
    [ViewComponent(Name = "ListOfWorker")]
    public class ListOfWorkerComponent : ViewComponent
    {
        private readonly IWorkerRepo repo;

        public  ListOfWorkerComponent(IWorkerRepo repo)
        {
            this.repo = repo;

        }
        public async Task<IViewComponentResult> InvokeAsync()
         =>  View(repo.GetWorkers());
        



    }
}
