using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nest;
using ZeebeBscProj.Models.WorkFlowModels;
using ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.DTO;
using ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.Extensions;

[assembly: InternalsVisibleTo("ZeebeBscProj.API.Tests.UnitTests")]
namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch
{
    internal class ZeebeElasticScearchClientService : IZeebeElasticSearchClient
    {
        private readonly ElasticClient client;

        public ZeebeElasticScearchClientService(ElasticClient client)
        {
            this.client = client;
        }

        public IEnumerable<DeployedWorkFlowModel> GetAllDeployedWorkFlows()
        {
            return client
                   .SearchFor("zeebe-record-deployment_*",
                              ObjectForQueryingDeployedWorkFlows())
                   .StringResponseToString()
                   .Deserialize<ZeebeRecordDeploymentDTO>()
                   .GetAllDeployedWorkFlows()
                   .AsDeployedWorkFlowModels();
        }
        private Object ObjectForQueryingDeployedWorkFlows()
        {
            return new
            {
                query = new
                {
                    query_string = new
                    {
                        default_field = "intent",
                        query = "DISTRIBUTED"
                    }
                }
            };
        }
    }
}
