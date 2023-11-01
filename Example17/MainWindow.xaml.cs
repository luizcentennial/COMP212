using System;
using System.Windows;

namespace Example17
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Event handlers can be assigned either here in the code-behind, or in XAML.
            //this.btnClickMe.Click += OnClick;
        }

        // The method below is an event handler, which is
        // triggered when the linked button is clicked.
        // Event handlers ALWAYS define two parameters:
        // - Sender: Reference to the triggering control.
        // - Event arguments: Event meta-data.
        private void OnClick(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked!");
        }
    }
}
