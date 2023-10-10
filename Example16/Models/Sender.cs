using System;
using System.Collections.Generic;

namespace Example16.Models {
    internal class Sender : IObservable<Message> {
        private readonly HashSet<IObserver<Message>> _observers = new HashSet<IObserver<Message>>();
        private readonly HashSet<Message> _messages = new HashSet<Message>();

        public IDisposable Subscribe(IObserver<Message> observer) {
            if (this._observers.Add(observer)) {
                foreach (Message message in this._messages) {
                    observer.OnNext(message);
                }
            }

            return new Unsubscriber<Message>(this._observers, observer);
        }

        public void Send(Message message) {
            foreach (IObserver<Message> observer in this._observers) {
                observer.OnNext(message);
            }
        }
    }
}
