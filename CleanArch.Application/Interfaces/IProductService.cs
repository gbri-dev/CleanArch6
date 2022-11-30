using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task CreateAsync (ProductDTO product);
        Task UpdateAsync(ProductDTO product);
        Task RemoveAsync(int? id);
       
    }
}
