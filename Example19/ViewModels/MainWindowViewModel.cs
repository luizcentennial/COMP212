using Example19.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace Example19.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private string _myProperty;
        private int _counter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string MyProperty {
            get => this._myProperty;
            set {
                this._myProperty = value;
                this.Notify(nameof(MyProperty));
            }
        }

        public int Counter {
            get => this._counter;
            set {
                this._counter = value;
                this.Notify(nameof(Counter));
            }
        }

        public ICommand CountUpCommand { get; set; }
        public ICommand CountDownCommand { get; set; }

        public MainWindowViewModel() {
            this.MyProperty = "Hello from ViewModel!";
            this.CountUpCommand = new RelayCommand(CountUp);
            this.CountDownCommand = new RelayCommand(CountDown);
        }

        private void CountUp(object obj) => this.Counter++;

        private void CountDown(object obj) => this.Counter--;

        private void Notify(string propertyName) {
            // Always check if PropertyChanged != null!
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
