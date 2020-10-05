using ZeebeBscProj.Models.WorkerModels;

namespace ZeebeBscProj.API.Extensions
{
    public static class ZeebeWorkerModelExtensions
    {
        public static ZeebeWorkerModel AsDefault(this ZeebeWorkerModel worker)
        {
            worker = new ZeebeWorkerModel
            {
                JobDurationTimeMilliSeconds = 1,
                JobType = "JobType",
                MaxActiveJobs = 1,
                Name = "WorkerName",
                PollIntervalSeconds = 1,
                ShouldCompleteSuccesfully = true,
                TimeOutSeconds = 1
            };
            return worker;
        }
    }
}
