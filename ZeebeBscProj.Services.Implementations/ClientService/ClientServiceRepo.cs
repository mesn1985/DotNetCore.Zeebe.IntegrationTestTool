using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ZeebeBscProj.Models.TopologyRequestModels;
using ZeebeBscProj.Models.WorkFlowModels;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.Repositories.Implementations.ZBClient.ClientService
{
    internal class ClientServiceRepo : ITopologyRepo, IWorkflowRepo
    {
        private readonly IZeebeClientService service;

        public ClientServiceRepo(IZeebeClientService service)
        {
            this.service = service;
        }
        public async Task DeployWorkFlow(byte[] bytes, [CallerMemberName] string name = "")
            => await service.DeployWorkFlow(bytes);
        public async Task<IEnumerable<ZeebeBroker>> MakeTopologyRequestAsync()
            => await service.MakeTopologyRequestAsync();
        public async Task RequestWorkFlowInstanceAsync(WorkFlowInstanceRequest workFlowInstanceRequest,
            [CallerMemberName] string name = "")
            => await service.RequestWorkFlowInstanceAsync(workFlowInstanceRequest);
    }
}
