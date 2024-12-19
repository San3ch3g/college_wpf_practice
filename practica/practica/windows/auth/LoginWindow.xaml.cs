using System.Windows;
using BCrypt.Net;
using pracrica.db;

namespace pracrica.windows.auth
{
    public partial class LoginWindow : Window
    {
        private readonly DatabaseService _dbService;

        public LoginWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            var user = _dbService.GetUserByLogin(login);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                MessageBox.Show("Успешный вход!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}