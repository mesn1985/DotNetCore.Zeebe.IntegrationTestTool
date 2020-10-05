using System.Collections.Concurrent;
using Zeebe.Client;
using ZeebeBscProj.Repositories.Contracts;
using ZeebeBscProj.Repositories.Implementations.ZBClient.ClientService;
using ZeebeBscProj.Repositories.Implementations.ZBClient.WorkerService;

namespace ZeebeBscProj.Repositories.Implementations.ZBClient
{
    public  class ZeebeRepositoryFactory
    {
        public static ITopologyRepo GetTopologyRepo(string url)
            => GetClientServiceRepo(url);
        public static IWorkflowRepo GetWorkFlowRepo(string url)
            => GetClientServiceRepo(url);
        public static IWorkerRepo GetWorkerRepo(string url)
        {

            var client = ZeebeClient.Builder()
                                .UseGatewayAddress(url)
                                .UsePlainText()
                                .Build();
            return new WorkerRepo(new ConcurrentDictionary<string, JobAndWorker>(),
                new ZeebeWorkerService(client));
        }
        private static ClientServiceRepo GetClientServiceRepo(string url)
        {
            var client = Zeebe.Client
                              .ZeebeClient.Builder()
                              .UseGatewayAddress(url)
                              .UsePlainText()
                              .Build();
            var zeebeClient = new ZeebeClientService(client);
            return new ClientServiceRepo(zeebeClient);
        }

    }
}
