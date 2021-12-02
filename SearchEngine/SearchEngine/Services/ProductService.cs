using System;
using System.Threading.Tasks;
using SearchEngine.Models;
using SearchEngine.Repositories;

namespace SearchEngine.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> SaveProduct(Product product)
        {
            return await _productRepository.Save(product);
        }

    }
}