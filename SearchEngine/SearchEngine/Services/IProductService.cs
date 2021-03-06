using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.Models;
using SearchEngine.V1.Models.RequestModels;

namespace SearchEngine.Services
{
    public interface IProductService
    {
        public Task<List<Product>> QueryCombineFields(string query, int from, int size);
        public Task<List<Product>> QueryMultiMatch(string query, int from, int size);
        public Task<List<Product>> Get(GetProductRequestModel model, int from, int size);
        public Task<Guid> SaveProduct(Product product);
        public Task<List<Guid>> BulkSaveProduct(List<Product> product);
    }
}