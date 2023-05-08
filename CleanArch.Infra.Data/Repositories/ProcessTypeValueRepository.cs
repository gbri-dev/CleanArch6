using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProcessTypeValueRepository : IProcessTypeValueRepository
    {
        private ApplicationDbContext _processTypeValueContext;

        public ProcessTypeValueRepository(ApplicationDbContext context)
        {
            _processTypeValueContext = context;
        }

        public async Task<ProcessTypeValue> Create(ProcessTypeValue processTypeValue)
        {
            _processTypeValueContext.Add(processTypeValue); 
            await _processTypeValueContext.SaveChangesAsync();
            return processTypeValue;
        }

        public async Task<ProcessTypeValue> GetById(int? id)
        {
            return await _processTypeValueContext.ProcessTypesValues.FindAsync(id);
        }

        public async Task<IEnumerable<ProcessTypeValue>> GetProcessTypeValue()
        {
            return await _processTypeValueContext.ProcessTypesValues.ToListAsync();
        }

        public async Task<ProcessTypeValue> Remove(ProcessTypeValue processTypeValue)
        {
            _processTypeValueContext.Remove(processTypeValue);
            await _processTypeValueContext.SaveChangesAsync();
            return processTypeValue;
        }

        public async Task<ProcessTypeValue> Update(ProcessTypeValue processTypeValue)
        {
            _processTypeValueContext.Update(processTypeValue);
            await _processTypeValueContext.SaveChangesAsync();
            return processTypeValue;
        }

    }
}
