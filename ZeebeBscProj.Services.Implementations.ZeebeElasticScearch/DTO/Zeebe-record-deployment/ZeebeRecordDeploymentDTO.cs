﻿using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class ZeebeRecordDeploymentDTO
    {
        [JsonPropertyName("took")]
        public int Took { get; set; }
        [JsonPropertyName("timed_out")]
        public bool TimedOut { get; set; }
        [JsonPropertyName("_shards")]
        public ShardsDTO Shards   { get; set; }
        [JsonPropertyName("hits")]
        public HitsDTO<DeploymentValueDTO> Hits { get; set; }
    }
}
