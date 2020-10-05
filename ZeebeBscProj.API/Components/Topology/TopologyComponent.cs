using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.API.Components.Topology
{

    [ViewComponent(Name = "Topology")]
    public class TopologyComponent : ViewComponent
    {
        private readonly ITopologyRepo repo;

        public TopologyComponent(ITopologyRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brokers = await repo.MakeTopologyRequestAsync();
            return View(brokers);
        }
    }

}