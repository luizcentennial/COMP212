using System;

namespace Example15.Models {
    internal class Product {
        public string ProductID { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product() {
            this.ProductID = Guid.NewGuid().ToString();
        }
    }
}
