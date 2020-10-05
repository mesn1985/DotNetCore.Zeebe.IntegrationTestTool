using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class HitDTO<T>
    { 
        [JsonPropertyName("_index")]
        public string Index   { get; set; }
        [JsonPropertyName("_type")]
        public string Type    { get; set; }
        [JsonPropertyName("_id")]
        public string Id      { get; set; }
        [JsonPropertyName("_score")]
        public double Score   { get; set; }
        [JsonPropertyName("_routing")]
        public string Routing { get; set; }
        [JsonPropertyName("_source")]
        public SourceDTO<T> Source  { get; set; }
    }
}
