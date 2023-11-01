using System;
using System.Windows;

namespace Example18
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.btnSignIn.Click += OnSignIn;
        }

        private void OnSignIn(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text;
            string password = this.pwdPassword.Password;

            if (username == "john" && password == "smith")
            {
                MessageBox.Show("Login successful!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid credentials!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
