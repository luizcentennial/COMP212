using Example21.Models;
using Microsoft.EntityFrameworkCore;

namespace Example21.Data {
    public class DataContext : DbContext {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDb01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Example21"));

            // ...
        }
    }
}
