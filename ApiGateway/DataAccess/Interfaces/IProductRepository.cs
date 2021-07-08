using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> GetProductById(string productId);
        public Task<PagedProducts> GetProductsPaged(string brand, int page, int size);
        public Task<List<Product>> GetProductsByIdList(List<String> productIds);

    }
}
