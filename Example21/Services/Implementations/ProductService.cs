using Example21.Data;
using Example21.Models;
using Example21.Services.Definitions;
using System.Collections.Generic;
using System.Linq;

namespace Example21.Services.Implementations {
    internal class ProductService : IService<Product> {
        private readonly DataContext _dataContext = new DataContext();

        public void Create(Product obj) {
            this._dataContext.Add(obj);
            this._dataContext.SaveChanges();
        }

        public void Delete(Product obj) {
            this._dataContext.Remove(obj);
            this._dataContext.SaveChanges();
        }

        public Product Get(string id) {
            return this._dataContext.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public IEnumerable<Product> GetAll() {
            return this._dataContext.Products.ToList();
        }

        public void Update(Product obj) {
            this._dataContext.Update(obj);
        }
    }
}
