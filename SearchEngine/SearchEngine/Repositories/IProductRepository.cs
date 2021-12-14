using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.Models;
using SearchEngine.V1.Models.RequestModels;

namespace SearchEngine.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> QueryCombineFields(string query, int from, int size);
        public Task<List<Product>> Get(GetProductRequestModel model, int from, int size = 10);
        public  Task<Guid> Save(Product product);
        public Task<List<Guid>> BulkSave(List<Product> productList);
    }
}