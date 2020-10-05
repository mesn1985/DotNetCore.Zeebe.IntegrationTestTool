using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ZeebeBscProj.Models.WorkerModels;
using ZeebeBscProj.Repositories.Contracts;

[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZBClient.WorkerService
{
    internal class WorkerRepo : IWorkerRepo
    {
        private readonly ConcurrentDictionary<string, JobAndWorker> activeWorkers;
        private readonly IZeebeWorkerService workerService;
        public WorkerRepo(ConcurrentDictionary<string, JobAndWorker> activeWorkers, IZeebeWorkerService workerService)
        {
            this.activeWorkers = activeWorkers;
            this.workerService = workerService;
        }
        public void DeployWorker(ZeebeWorkerModel worker, [CallerMemberName] string callingMember = "")
        {
            if (activeWorkers.ContainsKey(worker.Name))
                throw new ArgumentException($"{callingMember} tried to add a worker with an already existing name");

            activeWorkers[worker.Name] =
                new JobAndWorker(workerService.DeployWorker(worker), worker);
        }
        public IEnumerable<ZeebeWorkerModel> GetWorkers()
            => activeWorkers.Values.Select(WorkerTask => WorkerTask.workerModel);
        public void RemoveWorker(string name)
        {
            JobAndWorker removedWorkerTask;

            activeWorkers.Remove(name, out removedWorkerTask);

            removedWorkerTask?.EndJob();
        }
    }
}
