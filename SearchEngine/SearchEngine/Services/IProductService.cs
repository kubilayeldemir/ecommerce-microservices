using System;
using System.Threading.Tasks;
using SearchEngine.Models;

namespace SearchEngine.Services
{
    public interface IProductService
    {
        public Task<Guid> SaveProduct(Product product);

    }
}