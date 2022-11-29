using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.Image).HasMaxLength(250);
            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

           // builder.HasData(
                //new Product()
                //{
                //    id = 1,
                //    name = "Caderno",
                //    description = "Caderno espiral 100 fôlhas",
                //    price = 9.45m,
                //    stock = 10,
                //    image = "Caderno 96 folhas"
                //    categoryId = 1
                //},
                //new Product
                //{
                //    Id = 2,
                //    Name = "Borracha",
                //    Description = "Borracha branca pequena",
                //    Price = 9.45m
                //},
                //new Product
                //{
                //    Id = 3,
                //    Name = "Estojo",
                //    Description = "Estojo de plástico pequeno",
                //    Price = 9.45m
                //}
              //  );
        }
    }
}
