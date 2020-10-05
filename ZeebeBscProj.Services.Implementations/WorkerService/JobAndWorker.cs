using System.Runtime.CompilerServices;
using Zeebe.Client.Api.Worker;
using ZeebeBscProj.Models.WorkerModels;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZBClient.WorkerService
{
    internal class JobAndWorker
    {
        public  IJobWorker job { get; }
        public ZeebeWorkerModel workerModel { get;}
        
        public JobAndWorker(IJobWorker job, ZeebeWorkerModel workerModel)
        {
            this.job = job;
            this.workerModel = workerModel;
        }
        public void EndJob()
        {
            job.Dispose();
        }
    }
}
