using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class IncomeExpenseRepository : IIncomeExpenseRepository
    { 
        private readonly ApplicationDbContext _incomeExpenseContext;

        public IncomeExpenseRepository(ApplicationDbContext context)
        {
            _incomeExpenseContext = context;
        }

        public async Task<IncomeExpense> CreateAsync(IncomeExpense incomeExpense)
        {
            _incomeExpenseContext.Add(incomeExpense);
            await _incomeExpenseContext.SaveChangesAsync();
            return incomeExpense;
        }

        public async Task<IncomeExpense> GetByIdAsync(int? id)
        {
            //return await _productContext.Products.FindAsync(id);
            return await _incomeExpenseContext.IncomesExpenses.Include(c => c.ProcessType)
                .SingleOrDefaultAsync(p => p.Id == id);
        }   

        public async Task<IEnumerable<IncomeExpense>> GetIncomeExpenseAsync()
        {
            return await _incomeExpenseContext.IncomesExpenses.ToListAsync();
        }

        public async Task<IncomeExpense> RemoveAsync(IncomeExpense incomeExpense)
        {
            _incomeExpenseContext.Remove(incomeExpense);
            await _incomeExpenseContext.SaveChangesAsync();
            return incomeExpense;
        }

        public async Task<IncomeExpense> UpdateAsync(IncomeExpense incomeExpense)
        {
            _incomeExpenseContext.Update(incomeExpense);
            await _incomeExpenseContext.SaveChangesAsync();
            return incomeExpense;
        }

    }
}
