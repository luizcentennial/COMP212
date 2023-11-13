using System;

namespace Example20.Models {
    public class Product {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Product() {
            this.ProductID = Guid.NewGuid().ToString();
        }

        public override bool Equals(object? obj) {
            try {
                return ((Product)obj).ProductID == this.ProductID;
            }
            catch { 
                return false; 
            }
        }

        public static bool operator ==(Product left, Product right) {
            return left.ProductID == right.ProductID;
        }

        public static bool operator !=(Product left, Product right) {
            return left.ProductID != right.ProductID;
        }
    }
}
