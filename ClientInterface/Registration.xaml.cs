using ClientInterface.MyService;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ClientInterface
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private MyService.MouseEventContractClient obj = new MouseEventContractClient();

        public Registration()
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
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox1.Password != passwordBoxConfirm.Password)
            {
                MessageBox.Show("Пароли на совпадают");
                return;
            }

            var res = obj.Registration(new ServerUser()
            {
                Login = textBoxFirstName.Text,
                Password = passwordBox1.Password,
                Email = textBoxEmail.Text,
                Phone = phoneTB.Text,
                Name = NameTB.Text
            });

            if (res)
            {
                MessageBox.Show("Регистрация прошла успешно");
                Login_Click(null, null);
                Hide();
            }
            else
            {
                MessageBox.Show("Ошибка Регистрации");
            }
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AuthForm authForm = new AuthForm();
            authForm.Show();
            Hide();
        }
    }
}
