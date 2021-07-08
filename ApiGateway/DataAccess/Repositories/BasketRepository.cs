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
            this._client.SetBaseAddress("http://localhost:3000/api/");
        }
        public async Task<List<Product>> getBasket(string basketId)
        {
            string endpoint = "basket/" + basketId;
            return await _client.GetAsync<List<Product>>(endpoint);
        }
    }
}