using System.ComponentModel.DataAnnotations;

namespace ZeebeBscProj.Models.WorkerModels
{
    public class ZeebeWorkerModel
    {
        [StringLength(20), MinLength(1), Required]
        public string Name { get; set; }
        [StringLength(20), MinLength(1), Required]
        public string JobType { get; set; }
        [Range(1,10), Required]
        public int MaxActiveJobs { get; set; }
        [Range(1, 10000), Required]
        public int PollIntervalSeconds { get; set; }
        [Range(1, 10), Required]
        public int TimeOutSeconds { get; set; }
        [Required,Range(1,10000)]
        public int JobDurationTimeMilliSeconds { get; set; }
        [Required]
        public bool ShouldCompleteSuccesfully { get; set; }
        public string JobCompleteArgumentName { get; set; }
        public string JobCompleteArgumentValue { get; set; }

    }
}
