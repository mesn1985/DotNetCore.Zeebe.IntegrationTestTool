using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class ShardsDTO
    {
        [JsonPropertyName("total")]
        public int Total      { get; set; } // Shards that ES records are distributed out on?
        [JsonPropertyName("successful")]
        public int Successful { get; set; } //???
        [JsonPropertyName("skipped")]
        public int Skipped    { get; set; } //????
        [JsonPropertyName("failed")]
        public int Failed     { get; set; } // ???
    }
}
