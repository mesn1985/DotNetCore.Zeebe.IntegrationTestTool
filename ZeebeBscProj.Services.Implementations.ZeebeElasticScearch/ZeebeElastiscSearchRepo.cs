using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZeebeBscProj.Models.WorkFlowModels;
using ZeebeBscProj.Repositories.Contracts;

[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch
{
    internal class ZeebeElastiscSearchRepo : IElasticSearchZeebeRepo
    {
        private readonly IZeebeElasticSearchClient client;
        public ZeebeElastiscSearchRepo(IZeebeElasticSearchClient client)
        {
            this.client = client;
        }
        public IEnumerable<DeployedWorkFlowModel> GetAllDeployedWorkFlows()
            => client.GetAllDeployedWorkFlows();
    }
}
