using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Services
{
    public class IncomeExpenseService : IIncomeExpenseService
    {
        private IIncomeExpenseRepository _incomeExpenseRepository;
        private readonly IMapper _mapper;

        public IncomeExpenseService(IIncomeExpenseRepository incomeExpenseRepository, IMapper mapper)
        {
            _mapper = mapper;
            _incomeExpenseRepository = incomeExpenseRepository;
        }

        public async Task<IEnumerable<IncomeExpenseDTO>> GetAllAsync()
        {
            var incomesExpensesEntity = await _incomeExpenseRepository.GetIncomeExpenseAsync();
            return _mapper.Map<IEnumerable<IncomeExpenseDTO>>(incomesExpensesEntity);
        }

        public async Task<IncomeExpenseDTO> GetByIdAsync(int? id)
        {
            var incomesExpensesEntity = await _incomeExpenseRepository.GetByIdAsync(id);
            return _mapper.Map<IncomeExpenseDTO>(incomesExpensesEntity);
        }    

        public async Task CreateAsync(IncomeExpenseDTO incomeExpenseDto)
        {
            var incomesExpensesEntity = _mapper.Map<IncomeExpense>(incomeExpenseDto);
            await _incomeExpenseRepository.CreateAsync(incomesExpensesEntity);
        }

        public async Task UpdateAsync(IncomeExpenseDTO incomeExpenseDto)
        {
            var incomesExpensesEntity = _mapper.Map<IncomeExpense>(incomeExpenseDto);
            await _incomeExpenseRepository.UpdateAsync(incomesExpensesEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var incomesExpensesEntity = _incomeExpenseRepository.GetByIdAsync(id).Result;
            await _incomeExpenseRepository.RemoveAsync(incomesExpensesEntity);
        }
    }
}
