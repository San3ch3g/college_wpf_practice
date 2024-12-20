using System.Windows;
using pracrica.windows.products;
using pracrica.windows.payments; 
using pracrica.windows;
using practica.windows.categories;
using practica.windows;
using pracrica.windows.auth;

namespace pracrica
{
    public partial class MainWindow : Window
    {
        private bool isLoggedIn = false;

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void UpdateUI()
        {
            CategoryMenuItem.IsEnabled = isLoggedIn;
            ProductMenuItem.IsEnabled = isLoggedIn;
            PaymentMenuItem.IsEnabled = isLoggedIn;

            if (isLoggedIn)
            {
                LoginButton.Visibility = Visibility.Collapsed;
                RegisterButton.Visibility = Visibility.Collapsed;
                LogoutButton.Visibility = Visibility.Visible;
                LoggedInText.Visibility = Visibility.Visible;
            }
            else
            {
                LoginButton.Visibility = Visibility.Visible;
                RegisterButton.Visibility = Visibility.Visible;
                LogoutButton.Visibility = Visibility.Collapsed;
                LoggedInText.Visibility = Visibility.Collapsed;
            }
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Сначала авторизуйтесь!");
                return;
            }
            var categoriesWindow = new CategoriesWindow();
            categoriesWindow.ShowDialog();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Сначала авторизуйтесь!");
                return;
            }
            var productsWindow = new ProductsWindow();
            productsWindow.ShowDialog();
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Сначала авторизуйтесь!");
                return;
            }
            var paymentsWindow = new PaymentsWindow();
            paymentsWindow.ShowDialog();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            if (loginWindow.DialogResult == true)
            {
                isLoggedIn = true;
                UpdateUI();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            isLoggedIn = false;
            UpdateUI();
        }
    }
}