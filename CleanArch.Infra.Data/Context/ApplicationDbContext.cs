using Microsoft.EntityFrameworkCore;
using CleanArch.Domain.Entities;


namespace CleanArch.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Mapeamento da ORM
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //builder.ApplyConfiguration(new ProductConfiguration());
            //builder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}