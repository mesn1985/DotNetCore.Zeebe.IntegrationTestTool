using System.Linq;
using Zeebe.Client.Api.Responses;
using ZeebeBscProj.Models.TopologyRequestModels;

namespace ZeebeBscProj.Repositories.Implementations.ZBClient.Extensions
{
    internal static class ZeebeBrokerExtension
    {
        internal static ZeebeBroker FromRequestBrokerToModelBroker(this IBrokerInfo requestBroker)
        {
            return new ZeebeBroker
            {
                HostedOn = requestBroker.Host,
                NodeId = requestBroker.NodeId.ToString(),
                Adresse = requestBroker.Address,
                Partitions = requestBroker.Partitions.Select(requestPartition =>
                                 new ZeebePartition
                                 {
                                     Id = requestPartition.PartitionId.ToString(),
                                     Type = requestPartition.Role==0?PartitionRole.Leader:PartitionRole.Follower
                                 })
            };

        }
    }
}
