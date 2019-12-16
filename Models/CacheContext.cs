namespace PolishMinistryOfFinance.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class CacheContext : DbContext
    {
        public DbSet<TaxIdentificationNumberEntity> TaxIdentificationNumbers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=cache.db");
        }
    }
}