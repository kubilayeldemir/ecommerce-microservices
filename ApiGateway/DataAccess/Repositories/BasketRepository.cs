﻿using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IClient _client;
        public BasketRepository(IClient client)
        {
            this._client = client;
            this._client.SetBaseAddress(Environment.GetEnvironmentVariable("BASKET_SERVICE"));
        }

        public async Task<List<Product>> GetBasket(string basketId)
        {
            string endpoint = "basket/" + basketId;
            return await _client.GetAsync<List<Product>>(endpoint);
        }

        public async Task<List<Product>> AddToBasket(String basketId, List<Product> products)
        {
            string endpoint = "basket/" + basketId;
            return await _client.PostAsync<List<Product>>(endpoint,products);
        }

        public async Task<String> CreateBasket(List<Product> products)
        {
            string endpoint = "basket";
            return await _client.PostAsync<String>(endpoint,products);
        }
        public async Task<String> DeleteBasket(string basketId)
        {
            string endpoint = "basket/"+ basketId;
            return await _client.DeleteAsync<String>(endpoint);
        }
    }
}
