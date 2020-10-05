using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class JobValueDTO
    {
        [JsonPropertyName("errorMessage")]
        public string        ErrorMessage              { get; set; }
        [JsonPropertyName("type")]
        public string        Type                      { get; set; }
        [JsonPropertyName("deadline")]
        public long        Deadline                  { get; set; }
        [JsonPropertyName("errorCode")]
        public string        ErrorCode                 { get; set; }
        [JsonPropertyName("bpmnProcessId")]
        public string        BpmnProcessId             { get; set; }
        [JsonPropertyName("workflowKey")]
        public long        WorkflowKey               { get; set; }
        [JsonPropertyName("customHeaders")]
        public CustomHeadersDTO CustomHeaders             { get; set; }
        [JsonPropertyName("worker")]
        public string        Worker                    { get; set; }
        [JsonPropertyName("retries")]
        public int           Retries                   { get; set; }
        [JsonPropertyName("elementId")]
        public string        ElementId                 { get; set; }
        [JsonPropertyName("elementInstanceKey")]
        public long        ElementInstanceKey        { get; set; }
        [JsonPropertyName("workflowDefinitionVersion")]
        public long  WorkflowDefinitionVersion { get; set; }
        [JsonPropertyName("variables")]
        public VariablesDTO     Variables                 { get; set; }
        [JsonPropertyName("workflowInstanceKey")]
        public long        WorkflowInstanceKey       { get; set; }
    }
}
