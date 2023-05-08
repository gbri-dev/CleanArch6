using CleanArch.Domain.Entities;


namespace CleanArch.Domain.Interfaces
{
    public interface IProcessTypeValueRepository
    {
        Task<IEnumerable<ProcessTypeValue>> GetProcessTypeValue();
        Task<ProcessTypeValue> GetById(int? id);
        Task<ProcessTypeValue> Create(ProcessTypeValue category);
        Task<ProcessTypeValue> Update(ProcessTypeValue category);
        Task<ProcessTypeValue> Remove(ProcessTypeValue category);        
    }
}
