using Example21.Models;
using Example21.Services.Definitions;
using System.Collections.Generic;
using System.Linq;

namespace Example21.Services.Implementations {
    internal class ProductService : IService<Product> {
        private static List<Product> s_products = new List<Product>() {
            new Product() { Name = "Acoustic Guitar", Price = 4999.99, Description = "A fine instrument to play." },
            new Product() { Name = "Fender Stratocaster Guitar", Price = 7999.99, Description = "A super strat straight from the 80's that will rock your world." },
            new Product() { Name = "Gibson Les Paul Guitar", Price = 4999.99, Description = "A guitar so good you'll wish you had Jimmy Page's skills." },
        };

        public void Create(Product obj) {
            s_products.Add(obj);
        }

        public void Delete(Product obj) {
            s_products.Remove(obj);
        }

        public Product Get(string id) {
            return s_products.FirstOrDefault(p => p.ProductID == id);
        }

        public IEnumerable<Product> GetAll() {
            return s_products;
        }

        public void Update(Product obj) {
            this.Delete(obj);
            this.Create(obj);
        }
    }
}
