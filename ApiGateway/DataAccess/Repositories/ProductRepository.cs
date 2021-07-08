using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly IClient _client;
        public ProductRepository(IClient client)
        {
            this._client = client;
            this._client.SetBaseAddress("http://localhost:8080/api/");
        }
        public async Task<Product> GetProductById(string productId)
        {
            string endpoint = "products/" + productId;
            return await _client.GetAsync<Product>(endpoint);
        }
    }
}
