using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZeebeBscProj.Models.WorkFlowModels;

[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch
{
    internal interface IZeebeElasticSearchClient
    {
         IEnumerable<DeployedWorkFlowModel> GetAllDeployedWorkFlows();
    }
}
