using System;
using System.Threading.Tasks;
using Nest;

namespace SearchEngine.Repositories
{
    public static class ElasticHelper
    {
        public static async Task CheckAndCreateAlias<T>(string aliasName, ElasticClient client,
            Func<TypeMappingDescriptor<T>, ITypeMapping> mapping) where T : class
        {
            var index = $"{aliasName}-{DateTime.Now:yyyyMMddhhmm}";
            if (!await CheckAliasExists(aliasName, client))
            {
                await ElasticHelper.CreateIndexAsync(index, aliasName, mapping, client);
            }
        }

        private static async Task<bool> CheckAliasExists(string aliasName, ElasticClient client)
        {
            var response = await client.Indices.AliasExistsAsync(aliasName);
            if (response.OriginalException != null && !response.IsValid)
                return false;
            return response.Exists;
        }

        private static async Task CreateIndexAsync<T>(string index, string aliasName, Func<TypeMappingDescriptor<T>, ITypeMapping> mapping,
            ElasticClient client) where T : class
        {
            mapping ??= x => x.AutoMap();
            
            var result = await client.Indices.CreateAsync(index, index => index
                .Aliases(a => a.Alias(aliasName))
                .Map<T>(mapping));

            if (!result.IsValid)
            {
                throw new Exception(message: result.OriginalException.Message);
            }
        }
    }
}