using System;
using System.Collections.Generic;

namespace Example16.Models {
    internal class Recipient : IObserver<Message> {
        private readonly string _name;
        private readonly List<string> _messages = new List<string>();
        private IDisposable? _cancellation;

        public event Action<Message> OnMessageReceived;

        public Recipient(string name) {
            this._name = name;
        }

        public virtual void Subscribe(IObservable<Message> sender) {
            this._cancellation = sender.Subscribe(this);
        }

        public virtual void Unsubscribe() {
            this._cancellation?.Dispose();
            this._messages.Clear();
        }

        public virtual void OnCompleted() {
            this._messages.Clear();
        }

        public virtual void OnError(Exception e) {
            // Handle error.
        }

        public virtual void OnNext(Message message) {
            // The magic happens here.
            // This is the method that gets executed when a message is received.
            // It also carries a reference encapsulating all message data.

            // Technically, this method can implement all logic that should
            // run when a message is received. Alternatively, we can use events to
            // provide different recipients with the ability to respond to messages
            // in different ways.
            this.OnMessageReceived.Invoke(message);
        }
    }
}
