using System;
using Nest;
using ZeebeBscProj.Repositories.Contracts;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch
{
    public class ZeebeElasticSearchRepoFactory
    {
        public static IElasticSearchZeebeRepo GetZeebeElasticSearchRepo(string url)
        {
          var  client = new ElasticClient(new ConnectionSettings(new Uri(url)));

          return new ZeebeElastiscSearchRepo(new ZeebeElasticScearchClientService(client));
        }
    }
}
