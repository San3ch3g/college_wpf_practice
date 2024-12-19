using System.Windows;
using System.Windows.Controls;
using BCrypt.Net;
using pracrica.db;

namespace pracrica.windows.auth
{
    public partial class RegisterWindow : Window
    {
        private readonly DatabaseService _dbService;

        public RegisterWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            if (_dbService.RegisterUser(firstName, lastName, login, hashedPassword))
            {
                MessageBox.Show("Регистрация успешна!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}