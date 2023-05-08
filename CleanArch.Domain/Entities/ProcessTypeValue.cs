

using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class ProcessTypeValue : EntityBase
    {
        public string? Nome { get; set; }        
        public ICollection<IncomeExpense> IncomeExpenseTypevalueList { get; set; }
        public ProcessTypeValue(int id, string nome) 
        {
            Id = id;
            Nome = nome;
        }
       
    }
}
