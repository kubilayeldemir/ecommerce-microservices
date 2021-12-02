using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using SearchEngine.Models;

namespace SearchEngine.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElasticClient client;
        public ProductRepository(ElasticClient client)
        {
            this.client = client;
        }

        public async Task<Guid> Save(Product product)
        {
            product.Id = Guid.NewGuid();
            var savedProduct = await client.IndexAsync(product, idx => idx.Index("product-alias").Refresh(Refresh.WaitFor));

            if (savedProduct.IsValid)
            {
                return new Guid(savedProduct.Id);
            }

            throw new Exception("Couldn't save product");
        }
    }
}