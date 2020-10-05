using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class DeploymentValueDTO
    {
        [JsonPropertyName("deployedWorkflows")]
        public List<DeployedWorkflowDTO> DeployedWorkflows { get; set; }
        [JsonPropertyName("resources")]
        public List<ResourceDTO> Resources { get; set; }
    }
}
