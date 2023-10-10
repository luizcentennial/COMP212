using System;

namespace Example14 {

    // EVENTS
    //
    // Events are signals that communicate the occurrence of
    // something. Events can be subscribed to, or observed,
    // so that the system knows that the event happened and
    // responds accordingly.
    //
    // For example, when a mouse button is clicked, an event is
    // triggered. This event signals the program that the click
    // occurred, so that it can decide whether a response is due.
    //
    // Events can be used as a means to propagate information across
    // the system. Components that are listening for an event will
    // be able to detect its occurrence, and react with a programmed response.

    internal class Program {
        public static event Action OnLoad;

        static Program() {

            // Subscribing to an event.
            OnLoad += OnAppLoad;

            // Triggering an event.
            OnLoad.Invoke();
        }

        static void Main(string[] args) {
            // This Main method is empty.
            // Nevertheless, a message appears in the console
            // to show the app has loaded.
        }

        private static void OnAppLoad() {
            Console.WriteLine("Application loaded.");
        }
    }
}
