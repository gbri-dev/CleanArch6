using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class ProcessTypeValueConfiguration : IEntityTypeConfiguration<ProcessTypeValue>
    {
        public void Configure(EntityTypeBuilder<ProcessTypeValue> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();

            builder.HasData(
                    new ProcessTypeValue(1, "Income"),
                    new ProcessTypeValue(2, "Expense"),
                    new ProcessTypeValue(3, "Outros")
                );
        }
    }
}
