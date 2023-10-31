using Example15.Models;

namespace Example15.EventArgs {
    internal class ProductAddedEventArgs : System.EventArgs {
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
