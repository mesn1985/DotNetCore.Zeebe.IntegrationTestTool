using System;
using System.Text.Json;
using Elasticsearch.Net;
using Nest;

namespace ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch.Extensions
{
    internal static class SearchExtensions
    {
        public static StringResponse SearchFor(this ElasticClient client, string index, Object query)
        =>  client.LowLevel.Search<StringResponse>(index, PostData.Serializable(query));

        public static string StringResponseToString(this StringResponse strResponse)
            => strResponse.Body;
        public static T Deserialize<T>(this string json) where T : new()
        {
            if (string.IsNullOrEmpty(json))
                return new T();

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
