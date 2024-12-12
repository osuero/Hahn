using Hahn_OctavioSueroBackEnd.Core.Entities;
using Hahn_OctavioSueroBackEnd.Core.Interfaces;

namespace Hahn_OctavioSueroBackEnd.Application.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _repository.GetAllAsync();

        public async Task<Product> GetProductByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddProductAsync(Product product) => await _repository.AddAsync(product);

        public async Task UpdateProductAsync(Product product) => await _repository.UpdateAsync(product);

        public async Task DeleteProductAsync(int id) => await _repository.DeleteAsync(id);
    }
}
