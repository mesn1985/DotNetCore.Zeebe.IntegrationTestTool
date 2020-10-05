using System.Runtime.CompilerServices;
using Zeebe.Client;
using Zeebe.Client.Api.Worker;
using ZeebeBscProj.Models.WorkerModels;
using ZeebeBscProj.Repositories.Implementations.ZBClient.Extensions;

[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZBClient.WorkerService
{
    internal class ZeebeWorkerService : IZeebeWorkerService
    {
        private readonly IZeebeClient client;
        
        public ZeebeWorkerService(IZeebeClient client)
        {
            this.client = client;
        }
        
        public IJobWorker DeployWorker(ZeebeWorkerModel worker,[CallerMemberName] string callingMember = "")
           => client.CreateWorkerTask(worker);

    }

}