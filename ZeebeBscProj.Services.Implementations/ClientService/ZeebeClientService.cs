using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Zeebe.Client;
using ZeebeBscProj.Models.TopologyRequestModels;
using ZeebeBscProj.Models.WorkFlowModels;
using ZeebeBscProj.Repositories.Implementations.ZBClient.Extensions;

[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZBClient.ClientService
{
    internal class ZeebeClientService : IZeebeClientService
    {
        private readonly IZeebeClient client;
        
        public ZeebeClientService(IZeebeClient client)
        {
            this.client = client;
        }

        public async Task DeployWorkFlow(byte[] bytes, [CallerMemberName] string name = "")
        {
                  await client.NewDeployCommand()
                  .AddResourceBytes(bytes, $"TestFlow{Guid.NewGuid()}.bpmn")
                  .Send();
        }

        public async Task<IEnumerable<ZeebeBroker>> MakeTopologyRequestAsync()
        {
            var topology = await client.TopologyRequest().Send();
            var brokers = new List<ZeebeBroker>();

            foreach (var broker in topology.Brokers)
                brokers.Add(broker.FromRequestBrokerToModelBroker());

            return brokers;
        }

        public async Task  RequestWorkFlowInstanceAsync(WorkFlowInstanceRequest workFlowInstanceRequest, [CallerMemberName] string name = "")
        {
           await client.NewCreateWorkflowInstanceCommand()
                  .BpmnProcessId(workFlowInstanceRequest.BpmnProcessId)
                  .LatestVersion()
                  .Send();
        }
    }
}
