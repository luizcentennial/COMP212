using System;

namespace Example15.Models {
    internal class OrderItem {
        public string OrderItemID { get; private set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public uint Quantity { get; set; }

        public OrderItem() {
            this.OrderItemID = Guid.NewGuid().ToString();
        }
    }
}
