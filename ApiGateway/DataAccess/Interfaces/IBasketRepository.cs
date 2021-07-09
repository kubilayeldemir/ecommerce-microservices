using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBasketRepository
    {
        public Task<List<Product>> GetBasket(string basketId);
        public  Task<List<Product>> AddToBasket(String basketId, List<Product> products);
        public Task<String> CreateBasket(List<Product> products);

    }
}
