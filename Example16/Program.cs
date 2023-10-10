using Example16.Models;
using System;

namespace Example16 {

    // THE OBSERVER DESIGN PATTERN:
    //
    // The observer design pattern enables a subscriber to register
    // with and receive notifications from a provider. It's suitable
    // for any scenario that requires push-based notification.
    //
    // The pattern defines a provider (also known as a subject or an observable)
    // and zero, one, or more observers. Observers register with the provider,
    // and whenever a predefined condition, event, or state change occurs, the
    // provider automatically notifies all observers by invoking a delegate.
    // In this method call, the provider can also provide current state information
    // to observers.
    //
    // In .NET, the observer design pattern is applied by implementing the generic
    // System.IObservable<T> and System.IObserver<T> interfaces. The generic type
    // parameter represents the type that provides notification information.

    internal class Program {
        static void Main(string[] args) {
            // Creating message.
            var message = new Message() { 
                Content = "Hello, C#!"
            };

            // Defining sender.
            var sender = new Sender();

            // Defining recipient.
            var recipient = new Recipient("Recipient");
            recipient.Subscribe(sender);
            recipient.OnMessageReceived += (m) => Console.WriteLine(m.Content);

            // Sending message.
            sender.Send(message);
        }
    }
}
