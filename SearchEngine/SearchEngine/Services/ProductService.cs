using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.Models;
using SearchEngine.Repositories;
using SearchEngine.V1.Models.RequestModels;

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

        public async Task<List<Guid>> BulkSaveProduct(List<Product> product)
        {
            return await _productRepository.BulkSave(product);
        }

        public async Task<List<Product>> QueryCombineFields(string query, int from, int size)
        {
            size = size == 0 ? 25 : size;
            return await _productRepository.QueryCombineFields(query, from, size);
        }

        public async Task<List<Product>> QueryMultiMatch(string query, int from, int size)
        {
            size = size == 0 ? 25 : size;
            return await _productRepository.QueryMultiMatch(query, from, size);
        }

        public async Task<List<Product>> Get(GetProductRequestModel model, int from, int size)
        {
            return await _productRepository.Get(model, from, size);
        }
    }
}