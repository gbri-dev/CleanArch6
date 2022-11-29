using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    { 
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductCategoryAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> RemoveAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Product>> GetProductsAsync()
        //{
        //    return await _context.Products;
        //}
    }
}
