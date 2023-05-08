using CleanArch.Application.DTOs;


namespace CleanArch.Application.Interfaces
{
    public interface IProcessTypeValueService
    {
        Task<IEnumerable<ProcessTypeValueDTO>> GetProcesTypeValue();
        Task<ProcessTypeValueDTO> GetProcessTypeValueById(int? id);
        Task Add(ProcessTypeValueDTO objetoDto);
        Task Update(ProcessTypeValueDTO objetoDto);
        Task Remove(int? id);
    }
}
