using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class IncomeExpenseConfiguration : IEntityTypeConfiguration<IncomeExpense>
    {
        public void Configure(EntityTypeBuilder<IncomeExpense> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Title).HasMaxLength(40).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.ClosingDate).HasPrecision(2, 7).IsRequired();
            builder.Property(p => p.DueDate).HasPrecision(2, 7).IsRequired();
            builder.Property(p => p.Money).HasPrecision(18, 2).IsRequired();
            builder.Property(p => p.TypeValue).IsRequired();
            builder.HasOne(e => e.ProcessType).WithMany(e => e.IncomeExpenseTypevalueList)
                .HasForeignKey(e => e.Id);
        }
    }
}
