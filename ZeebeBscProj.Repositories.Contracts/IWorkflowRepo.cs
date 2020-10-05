using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ZeebeBscProj.Models.WorkFlowModels;

namespace ZeebeBscProj.Repositories.Contracts
{
    public interface IWorkflowRepo
    {
        Task RequestWorkFlowInstanceAsync(
            WorkFlowInstanceRequest workFlowInstanceRequest,
            [CallerMemberName] string name = "");
        Task DeployWorkFlow(byte[] bytes, [CallerMemberName] string name = "");
    }
}
