using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZeebeBscProj.Models.WorkerModels;

namespace ZeebeBscProj.Repositories.Contracts
{
    public interface IWorkerRepo
    {
        void DeployWorker(ZeebeWorkerModel worker, [CallerMemberName] string callingMember = "");

        IEnumerable<ZeebeWorkerModel> GetWorkers();

        void RemoveWorker(string name);
    }
}
