namespace ZeebeBscProj.Models.TopologyRequestModels
{
    public class ZeebePartition
    {
        public string Id { get; set; }
        public PartitionRole Type { get; set; }
    }
    public enum PartitionRole { Leader=0,Follower=1}
}
