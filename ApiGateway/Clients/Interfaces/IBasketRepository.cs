using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clients.Models;

namespace Clients.Interfaces
{
    public interface IBasketRepository
    {
        public Task<List<Product>> GetBasket(string basketId);
        public  Task<List<Product>> AddToBasket(String basketId, List<Product> products);
        public Task<String> CreateBasket(List<Product> products);
        public Task<String> DeleteBasket(string basketId);

    }
}
