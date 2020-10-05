using System.Collections.Generic;
using ZeebeBscProj.Models.WorkFlowModels;

namespace ZeebeBscProj.Repositories.Contracts
{
    public interface IElasticSearchZeebeRepo
    {
        IEnumerable<DeployedWorkFlowModel> GetAllDeployedWorkFlows();
    }
}
