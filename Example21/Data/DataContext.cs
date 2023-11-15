using Example21.Models;
using Microsoft.EntityFrameworkCore;

namespace Example21.Data {
    public class DataContext : DbContext {
        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=<Your Database Name>;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(this._connectionString, b => b.MigrationsAssembly("Example21"));

            // ...
        }
    }
}
