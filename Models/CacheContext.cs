namespace PolishMinistryOfFinance.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class CacheContext : DbContext
    {
        private readonly static string connectionString = "Server=192.168.100.103;Database=PolishMinistryOfFinance;User Id=sa;Password=xx";
        public DbSet<TaxIdentificationNumberEntity> TaxIdentificationNumbers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlite("Data Source=cache.db");
        }
    }
}
