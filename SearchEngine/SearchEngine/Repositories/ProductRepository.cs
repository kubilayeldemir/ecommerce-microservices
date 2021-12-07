using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using SearchEngine.Models;
using SearchEngine.V1.Models.RequestModels;

namespace SearchEngine.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElasticClient _client;
        private readonly string _aliasName;

        public ProductRepository(ElasticClient client, string aliasName)
        {
            this._client = client;
            _aliasName = aliasName;
            CreateElasticRepository(client).GetAwaiter().GetResult();
        }

        private async Task CreateElasticRepository(ElasticClient client)
        {
            await ElasticHelper.CheckAndCreateAlias<Product>(_aliasName, client, null);
        }

        public async Task<List<Product>> Get(GetProductRequestModel model, int from, int size = 10)
        {
            QueryContainer GenerateQuery(QueryContainerDescriptor<Product> q)
            {
                var queryContainer = new QueryContainer();

                if (!string.IsNullOrWhiteSpace(model.Name))
                {
                    queryContainer = queryContainer && q
                        .Match(m => m.Field(f => f.Name)
                            .Query(model.Name));
                }

                if (!string.IsNullOrWhiteSpace(model.Brand))
                {
                    queryContainer = queryContainer && q
                        .Match(m => m.Field(f => f.Brand)
                            .Query(model.Brand));
                }

                if (!string.IsNullOrWhiteSpace(model.Description))
                {
                    queryContainer = queryContainer && q
                        .Match(m => m.Field(f => f.Description)
                            .Query(model.Description));
                }

                if (model.Category != null && model.Category.Count > 1)
                {
                    queryContainer = queryContainer && q
                        .Terms(m => m.Field(f => f.Category)
                            .Terms(model.Category));
                }

                return queryContainer;
            }

            var searchDescriptor = new SearchDescriptor<Product>()
                .Query(GenerateQuery)
                .Index(_aliasName)
                .From(from)
                .Size(size);
            
            var result = await _client.SearchAsync<Product>(searchDescriptor);

            if (!result.IsValid)
            {
                throw new ElasticsearchClientException("");
            }

            return result.Documents.ToList();
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