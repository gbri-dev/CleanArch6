using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IIncomeExpenseRepository
    {
        Task<IEnumerable<IncomeExpense>> GetIncomeExpenseAsync();
        Task<IncomeExpense> GetByIdAsync(int? id);       
        Task<IncomeExpense> CreateAsync(IncomeExpense product);
        Task<IncomeExpense> UpdateAsync(IncomeExpense product);
        Task<IncomeExpense> RemoveAsync(IncomeExpense product);
    }
}
