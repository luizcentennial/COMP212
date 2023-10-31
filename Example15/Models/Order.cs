using System;
using System.Collections.Generic;
using Example15.EventArgs;

namespace Example15.Models {
    internal class Order {
        public event EventHandler<ProductAddedEventArgs> ProductAdded;
        public event EventHandler<ProcessingStartedEventArgs> ProcessingStarted;

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
            var args = new ProductAddedEventArgs() { Order = this, Product = product };
            this.ProductAdded.Invoke(this, args);
        }

        public void Process() {
            // Order processing logic.

            var args = new ProcessingStartedEventArgs() { Order = this };
            this.ProcessingStarted.Invoke(this, args);
        }
    }
}
