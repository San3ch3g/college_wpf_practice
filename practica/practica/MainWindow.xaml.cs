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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            var categoriesWindow = new CategoriesWindow();
            categoriesWindow.ShowDialog();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            var productsWindow = new ProductsWindow();
            productsWindow.ShowDialog();
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            var paymentsWindow = new PaymentsWindow();
            paymentsWindow.ShowDialog();
        }
        
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}