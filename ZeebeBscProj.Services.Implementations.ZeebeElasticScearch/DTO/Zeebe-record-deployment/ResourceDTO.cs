using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class ResourceDTO
    {
        [JsonPropertyName("resourceName")]
        public string ResourceName { get; set; }
        [JsonPropertyName("resourceType")]
        public string ResourceType { get; set; }
        [JsonPropertyName("resource")]
        public string ResourceDefinition { get; set; }
    }
}
