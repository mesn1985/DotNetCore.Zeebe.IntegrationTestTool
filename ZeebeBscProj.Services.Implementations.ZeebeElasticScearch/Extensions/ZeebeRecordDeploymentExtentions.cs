using System.Collections.Generic;
using ZeebeBscProj.Models.WorkFlowModels;
using ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.Extensions
{
    internal static class ZeebeRecordDeploymentExtentions
    {
        public static IEnumerable<DeployedWorkflowDTO> GetAllDeployedWorkFlows(this ZeebeRecordDeploymentDTO record)
        {
            foreach (var hit in record.Hits.AllHits)
                foreach (var workflow in hit.Source.Value.DeployedWorkflows)
                    yield return workflow;
        }
        public static IEnumerable<DeployedWorkFlowModel> AsDeployedWorkFlowModels(
            this IEnumerable<DeployedWorkflowDTO> workflowDTOs)
        {
            foreach (var workflow in workflowDTOs)
                yield return new DeployedWorkFlowModel
                {
                    Version = workflow.Version,
                    ProccesId = workflow.BpmnProcessId,
                    WorkFlowKey = workflow.WorkflowKey.ToString(),
                    RescourceName = workflow.ResourceName
                };


        }

    }
}
