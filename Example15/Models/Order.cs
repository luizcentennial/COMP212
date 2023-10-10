using System;
using System.Collections.Generic;

namespace Example15.Models {
    internal class Order {
        public event Action<Product, Order> ProductAdded;
        public event Action<Order> ProcessingStarted;

        public string OrderID { get; private set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; }
        public double Total { 
            get {
                double total = 0;

                foreach (var item in Items) {
                    total += item.Quantity > 0 && item.Product.Price > 0 
                             ? item.Quantity * item.Product.Price
                             : 0;
                }

                return total;
            }
        }

        public Order() {
            this.OrderID = Guid.NewGuid().ToString();
            this.Items = new List<OrderItem>();
        }

        public void Add(Product product, uint quantity = 1) {
            var item = new OrderItem();
            item.Order = this;
            item.Product = product;
            item.Quantity = quantity;

            this.Items.Add(item);

            // Triggering ProductAdded event.
            this.ProductAdded.Invoke(product, this);
        }

        public void Process() {
            // Order processing logic.

            this.ProcessingStarted.Invoke(this);
        }
    }
}
