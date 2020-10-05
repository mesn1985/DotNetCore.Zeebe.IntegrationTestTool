using System.Text.Json.Serialization;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO
{
    internal class SourceDTO<T>
    {
        [JsonPropertyName("partitionId")]
        public int    PartitionId          { get; set; } // which partion was this event(record) performed on
        [JsonPropertyName("value")]
        public T  Value                { get; set; } // Value contains the record specific data
        [JsonPropertyName("sourceRecordPosition")]
        public object SourceRecordPosition { get; set; } // ????
        [JsonPropertyName("position")]
        public object Position             { get; set; } // ??????
        [JsonPropertyName("recordType")]
        public string RecordType           { get; set; } // what type of record, E.g Event
        [JsonPropertyName("timestamp")]
        public object Timestamp            { get; set; } // time of capture, pressumably
        [JsonPropertyName("valueType")]
        public string ValueType            { get; set; } // what is record made for, Deployment, workflow instance, Job
        [JsonPropertyName("intent")]
        public string Intent               { get; set; } // what was the purpose, e.g activated, completed
        [JsonPropertyName("rejectionType")]
        public string RejectionType        { get; set; } // ???
        [JsonPropertyName("rejectionReason")]
        public string RejectionReason      { get; set; } // ????
        [JsonPropertyName("key")]
        public object Key                  { get; set; } // Probably unique identifier in ES

    }

   
}
