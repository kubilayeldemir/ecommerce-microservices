using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clients.Interfaces;
using Clients.Models;

namespace Clients.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IClient _client;

        public ProductRepository(IClient client)
        {
            _client = client;
            _client.SetBaseAddress(Environment.GetEnvironmentVariable("PRODUCT_SERVICE"));
        }

        public async Task<Product> GetProductById(string productId)
        {
            var endpoint = "products/" + productId;
            return await _client.GetAsync<Product>(endpoint);
        }

        public async Task<PagedProducts> GetProductsPaged(string brand, int page, int size)
        {
            size = size < 1 ? 3 : size;
            var endpoint = "products?";
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("brand", brand);
            queryString.Add("page", page.ToString());
            queryString.Add("size", size.ToString());
            endpoint += queryString.ToString();

            return await _client.GetAsync<PagedProducts>(endpoint);
        }

        public async Task<List<Product>> GetProductsByIdList(List<string> productIds)
        {
            var endpoint = "/api/products/list/";
            foreach (var id in productIds)
            {
                endpoint += id + ',';
            }

            return await _client.GetAsync<List<Product>>(endpoint);
        }
    }
}