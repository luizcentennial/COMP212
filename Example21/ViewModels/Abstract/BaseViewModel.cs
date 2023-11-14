using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Example21.ViewModels.Abstract {
    public abstract class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName) {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetAndNotify<T>(ref T field, T value, [CallerMemberName] string property = null) {
            if (Object.Equals(field, value))
                return;

            field = value;

            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        protected void SetAndNotify<T>(ref T field, T value, Action callback, [CallerMemberName] string property = null) {
            this.SetAndNotify(ref field, value, property);

            callback.Invoke();
        }
    }
}
