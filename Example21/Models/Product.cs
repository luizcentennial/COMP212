using System;
using System.Linq;

namespace Example21.Models {
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

        public override int GetHashCode() {
            string value = string.Join(null, this.ProductID.Where(c => int.TryParse(c.ToString(), out _)).Take(8));

            return int.Parse(value);
        }

        public static bool operator ==(Product left, Product right) {
            return left.ProductID == right.ProductID;
        }

        public static bool operator !=(Product left, Product right) {
            return left.ProductID != right.ProductID;
        }
    }
}
