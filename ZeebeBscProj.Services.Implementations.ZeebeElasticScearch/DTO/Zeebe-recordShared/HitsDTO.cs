using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class HitsDTO<T>
    {
        [JsonPropertyName("total")]
        public int       Total     { get; set; }
        [JsonPropertyName("max_score")]
        public double?    MaxScore { get; set; }
        [JsonPropertyName("hits")]
        public List<HitDTO<T>> AllHits { get; set; }
    }
}
