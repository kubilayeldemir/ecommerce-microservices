using System.Collections.Generic;
using System.Threading.Tasks;
using Clients.Models;

namespace Clients.Interfaces
{
    public interface IBasketRepository
    {
        public Task<List<Product>> GetBasket(string basketId);
        public Task<List<Product>> AddToBasket(string basketId, List<Product> products);
        public Task<string> CreateBasket(List<Product> products);
        public Task<string> DeleteBasket(string basketId);
    }
}