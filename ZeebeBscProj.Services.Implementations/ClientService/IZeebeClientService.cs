using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ZeebeBscProj.Models.TopologyRequestModels;
using ZeebeBscProj.Models.WorkFlowModels;

[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZBClient.ClientService
{ 
    internal interface IZeebeClientService
    {
        Task<IEnumerable<ZeebeBroker>> MakeTopologyRequestAsync();

        Task RequestWorkFlowInstanceAsync(
            WorkFlowInstanceRequest workFlowInstanceRequest,
            [CallerMemberName] string name = "");
        Task DeployWorkFlow(byte[] bytes,[CallerMemberName] string name = "");
    }
}
