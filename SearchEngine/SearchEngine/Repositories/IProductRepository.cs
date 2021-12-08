using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.Models;

namespace SearchEngine.Repositories
{
    public interface IProductRepository
    {
        public  Task<Guid> Save(Product product);
        public Task<List<Guid>> BulkSave(List<Product> productList);
    }
}