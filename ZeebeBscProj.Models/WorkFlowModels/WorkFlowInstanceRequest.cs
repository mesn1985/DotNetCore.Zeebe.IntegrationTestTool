using System.ComponentModel.DataAnnotations;

namespace ZeebeBscProj.Models.WorkFlowModels
{
    public class WorkFlowInstanceRequest
    { 
        [Required]
        public string BpmnProcessId { get; set; }
    }
}
