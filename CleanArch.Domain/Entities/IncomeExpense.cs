

namespace CleanArch.Domain.Entities
{
    public sealed class IncomeExpense : EntityBase
    {
        public string? Title { get; private set; }
        public DateTime? ClosingDate { get; private set;}
        public DateTime? DueDate { get; private set;}
        public string? Description { get; private set; }
        public decimal Money { get; private set; }
        public int TypeValue { get; private set; }

        public ProcessTypeValue? ProcessType { get; set; }
    }
}
