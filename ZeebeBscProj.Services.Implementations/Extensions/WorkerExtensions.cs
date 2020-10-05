using System;
using System.Threading;
using Zeebe.Client;
using Zeebe.Client.Api.Commands;
using Zeebe.Client.Api.Responses;
using Zeebe.Client.Api.Worker;
using ZeebeBscProj.Models.WorkerModels;

namespace ZeebeBscProj.Repositories.Implementations.ZBClient.Extensions
{
    internal static class WorkerExtensions
    {
        internal static IJobWorker CreateWorkerTask(this IZeebeClient client, ZeebeWorkerModel worker)
        {
            var jobHandler = worker.ShouldCompleteSuccesfully
                ? HandleSuccesFullJob(worker)
                : HandleFailedJob(worker);

            return
                client.NewWorker()
                      .JobType(worker.JobType)
                      .Handler(jobHandler)
                      .MaxJobsActive(worker.MaxActiveJobs)
                      .Name(worker.Name)
                      .AutoCompletion()
                      .PollInterval(TimeSpan.FromSeconds(worker.PollIntervalSeconds))
                      .Timeout(TimeSpan.FromSeconds(worker.TimeOutSeconds))
                      .Open();
        }
        private static JobHandler HandleSuccesFullJob(ZeebeWorkerModel worker)
        {
            return (IJobClient jobClient, IJob job) =>
                   {
                       Thread.Sleep(worker.JobDurationTimeMilliSeconds);
                       //TODO implement variables here
                       jobClient.NewCompleteJobCommand(job.Key)
                                .AddVariableIfAny(worker)
                                .Send()
                                .GetAwaiter()
                                .GetResult();
                   };
        }
        private static JobHandler HandleFailedJob(ZeebeWorkerModel worker)
        {
            return (IJobClient jobClient, IJob job) =>
                   {
                       Thread.Sleep(worker.JobDurationTimeMilliSeconds);

                       jobClient.NewFailCommand(job.Key)
                                .Retries(job.Retries - 1)
                                .ErrorMessage("Test Mock failed")
                                .Send()
                                .GetAwaiter()
                                .GetResult();
                   };
        }

        private static ICompleteJobCommandStep1 AddVariableIfAny(this ICompleteJobCommandStep1 jobCommand,ZeebeWorkerModel worker)
        {
            var argumentName = worker.JobCompleteArgumentName;
            var argumentValue = worker.JobCompleteArgumentValue;

            if (string.IsNullOrEmpty(argumentName) || string.IsNullOrEmpty(argumentValue))
                return jobCommand;

            return jobCommand.Variables($"{{\"{argumentName}\":\"{argumentValue}\"}}");
        }
        
    }
}
