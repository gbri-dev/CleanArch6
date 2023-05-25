using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IIncomeExpenseService
    {
        Task<IEnumerable<IncomeExpenseDTO>> GetAllAsync();
        Task<IncomeExpenseDTO> GetByIdAsync(int? id);
       // Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task CreateAsync (IncomeExpenseDTO objeto);
        Task UpdateAsync(IncomeExpenseDTO objeto);
        Task RemoveAsync(int? id);
       
    }
}
