using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using SearchEngine.Models;

namespace SearchEngine.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElasticClient _client;
        private readonly string _aliasName;
        public ProductRepository(ElasticClient client,string aliasName)
        {
            this._client = client;
            _aliasName = aliasName;
            CreateElasticRepository(client).GetAwaiter().GetResult();
        }

        private async Task CreateElasticRepository(ElasticClient client)
        {
            await ElasticHelper.CheckAndCreateAlias<Product>(_aliasName, client, null);

        }

        public async Task<Guid> Save(Product product)
        {
            product.Id = Guid.NewGuid();
            var savedProduct = await _client.IndexAsync(product, idx => idx.Index(_aliasName).Refresh(Refresh.WaitFor));

            if (savedProduct.IsValid)
            {
                return new Guid(savedProduct.Id);
            }

            throw new Exception("Couldn't save product");
        }
        
        public async Task<bool> BulkSave(List<Product> products)
        {
            products.ForEach(p => p.Id = Guid.NewGuid());

            var savedProducts = await _client.BulkAsync(p => p.IndexMany(products, (c, doc) => c
                .Document(doc)
                .Index(_aliasName)).Refresh(Refresh.WaitFor));
                

            if (!savedProducts.IsValid)
            {
                throw new Exception("Couldn't save product");
            }
            
            return true;
        }
    }
}