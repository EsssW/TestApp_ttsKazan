using ClientInterface.MyService;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ClientInterface
{
    /// <summary>
    /// Логика взаимодействия для AuthForm.xaml
    /// </summary>
    public partial class AuthForm : Window
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control ctl in grid.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MyService.MouseEventContractClient obj = new MouseEventContractClient();

            string login = tbLogin.Text;
            string password = passwordBox1.Password;

            int userId = obj.SignIn(login,password);

            if(userId != -1)
            {
                MessageBox.Show("Successful authorization");
                var win = new MainWindow(userId);
                win.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("incorrect password or login, try again");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Registration regWindow = new Registration();
            regWindow.Show();
            Hide();
        }
    }
}
