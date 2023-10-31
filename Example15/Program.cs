using Example15.Models;
using System;

namespace Example15 {

    // EVENTS (cont.):
    //
    // This example shows how events can be used in model classes
    // to allow for an event-driven approach.

    internal class Program {
        static void Main(string[] args) {
            var product = new Product() {
                Name = "Electric Guitar",
                Description = "Gibson Les Paul Custom 1959 Reissue",
                Price = 12999.99
            };

            var order = new Order();

            // Subscribing to order events.
            order.ProductAdded += (sender, args) => Log($"Product '{args.Product.Name}' added to order '{args.Order.OrderID}' at {DateTime.Now}.");
            order.ProcessingStarted += (sender, args) => Log($"Order '{args.Order.OrderID}' started processing at {DateTime.Now}.");

            order.Add(product);
            order.Process();
        }

        private static void Log(string message) {
            Console.WriteLine(message);
        }
    }
}
