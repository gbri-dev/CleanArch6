using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IIncomeExpenseService
    {
        Task<IEnumerable<IncomeExpenseDTO>> GetProductsAsync();
        Task<IncomeExpenseDTO> GetByIdAsync(int? id);
       // Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task CreateAsync (IncomeExpenseDTO product);
        Task UpdateAsync(IncomeExpenseDTO product);
        Task RemoveAsync(int? id);
       
    }
}
