using System.Runtime.CompilerServices;
using Zeebe.Client.Api.Worker;
using ZeebeBscProj.Models.WorkerModels;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZBClient.WorkerService
{
    internal interface IZeebeWorkerService
    {
        IJobWorker DeployWorker(ZeebeWorkerModel worker, [CallerMemberName] string callingMember = "");

    }
}
