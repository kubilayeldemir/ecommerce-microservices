using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clients.Interfaces;
using Clients.Models;

namespace Clients.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IClient _client;

        public BasketRepository(IClient client)
        {
            _client = client;
            _client.SetBaseAddress(Environment.GetEnvironmentVariable("BASKET_SERVICE"));
        }

        public async Task<List<Product>> GetBasket(string basketId)
        {
            var endpoint = "basket/" + basketId;
            return await _client.GetAsync<List<Product>>(endpoint);
        }

        public async Task<List<Product>> AddToBasket(string basketId, List<Product> products)
        {
            var endpoint = "basket/" + basketId;
            return await _client.PostAsync<List<Product>>(endpoint, products);
        }

        public async Task<string> CreateBasket(List<Product> products)
        {
            var endpoint = "basket";
            return await _client.PostAsync<string>(endpoint, products);
        }

        public async Task<string> DeleteBasket(string basketId)
        {
            var endpoint = "basket/" + basketId;
            return await _client.DeleteAsync<string>(endpoint);
        }
    }
}