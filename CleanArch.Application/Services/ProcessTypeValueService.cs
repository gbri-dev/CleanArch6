using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProcessTypeValueService : IProcessTypeValueService
    {
        private IProcessTypeValueRepository _processTypeValueRepository;
        private readonly IMapper _mapper;

        public ProcessTypeValueService(IProcessTypeValueRepository processTypeValueRepository, IMapper mapper)
        {
            _processTypeValueRepository = processTypeValueRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProcessTypeValueDTO>> GetProcesTypeValue()
        {
            var processTypeValueEntity = await _processTypeValueRepository.GetProcessTypeValue();
            return _mapper.Map<IEnumerable<ProcessTypeValueDTO>>(processTypeValueEntity);
        }

        public async Task<ProcessTypeValueDTO> GetProcessTypeValueById(int? id)
        {
            var processTypeValueEntity = await _processTypeValueRepository.GetById(id);
            return _mapper.Map<ProcessTypeValueDTO>(processTypeValueEntity);
        }

        public async Task Add(ProcessTypeValueDTO processTypeValueDTO)
        {
            var processTypeValueEntity = _mapper.Map<ProcessTypeValue>(processTypeValueDTO);
            await _processTypeValueRepository.Create(processTypeValueEntity);
        }

        public async Task Update(ProcessTypeValueDTO processTypeValueDTO)
        {
            var processTypeValueEntity = _mapper.Map<ProcessTypeValue>(processTypeValueDTO);
            await _processTypeValueRepository.Update(processTypeValueEntity);
        }

        public async Task Remove(int? id)
        {
            var processTypeValueEntity = _processTypeValueRepository.GetById(id).Result;
            await _processTypeValueRepository.Remove(processTypeValueEntity);
        }
    }
}
