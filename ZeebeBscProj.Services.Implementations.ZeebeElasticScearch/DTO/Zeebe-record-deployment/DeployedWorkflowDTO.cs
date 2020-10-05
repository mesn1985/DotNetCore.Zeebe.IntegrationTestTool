using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class DeployedWorkflowDTO
    {
        [JsonPropertyName("version")]
        public int    Version       { get; set; }
        [JsonPropertyName("bpmnProcessId")]
        public string BpmnProcessId { get; set; }
        [JsonPropertyName("workflowKey")]
        public long WorkflowKey   { get; set; }
        [JsonPropertyName("resourceName")]
        public string ResourceName  { get; set; }
    }
}
