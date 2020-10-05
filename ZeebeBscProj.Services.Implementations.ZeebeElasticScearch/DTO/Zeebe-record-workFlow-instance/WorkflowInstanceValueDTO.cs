using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class WorkflowInstanceValueDTO
    {
        [JsonPropertyName("version")]
        public int    Version                   { get; set; }
        [JsonPropertyName("bpmnProcessId")]
        public string BpmnProcessId             { get; set; }
        [JsonPropertyName("workflowKey")]
        public long WorkflowKey               { get; set; }
        [JsonPropertyName("elementId")]
        public string ElementId                 { get; set; }
        [JsonPropertyName("workflowInstanceKey")]
        public long WorkflowInstanceKey       { get; set; }
        [JsonPropertyName("parentWorkflowInstanceKey")]
        public int    ParentWorkflowInstanceKey { get; set; }
        [JsonPropertyName("bpmnElementType")]
        public string BpmnElementType           { get; set; }
        [JsonPropertyName("flowScopeKey")]
        public long FlowScopeKey              { get; set; }
        [JsonPropertyName("parentElementInstanceKey")]
        public int    ParentElementInstanceKey  { get; set; }
    }
}
