using System;
using System.Windows.Input;

namespace Example19.Commands {
    public class RelayCommand : ICommand {
        private Action<object> _action;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object> action) { 
            this._action = action;
        }

        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            this._action.Invoke(parameter);
        }
    }
}
