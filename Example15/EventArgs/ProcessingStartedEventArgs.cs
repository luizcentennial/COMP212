using Example15.Models;

namespace Example15.EventArgs {
    internal class ProcessingStartedEventArgs : System.EventArgs {
        public Order Order { get; set; }
    }
}
