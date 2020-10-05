using System.Collections.Generic;
using System.Threading.Tasks;
using ZeebeBscProj.Models.TopologyRequestModels;

namespace ZeebeBscProj.Repositories.Contracts
{
    public interface  ITopologyRepo
    { 
        Task<IEnumerable<ZeebeBroker>> MakeTopologyRequestAsync();
    }
}
