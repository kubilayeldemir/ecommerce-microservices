using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.Models;

namespace SearchEngine.Services
{
    public interface IProductService
    {
        public Task<Guid> SaveProduct(Product product);
        public Task<List<Guid>> BulkSaveProduct(List<Product> product);
    }
}