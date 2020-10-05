using System.Collections.Generic;

namespace ZeebeBscProj.Models.TopologyRequestModels
{
    public class ZeebeBroker
    {
        public string HostedOn { get; set; }
        public string NodeId { get; set; }
        public string Adresse { get; set; }
        
        public IEnumerable<ZeebePartition> Partitions;
    }
}
