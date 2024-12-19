using System.Windows;
using pracrica.db;
using pracrica.models;

namespace pracrica.windows.payments
{
    public partial class CreatePaymentWindow : Window
    {
        private readonly DatabaseService _dbService;

        public CreatePaymentWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            LoadUsers();
            LoadProducts();
        }

        private void LoadUsers()
        {
            var users = _dbService.GetUsers();
            UserComboBox.ItemsSource = users;
            UserComboBox.DisplayMemberPath = "Login";
            UserComboBox.SelectedValuePath = "Id";
        }

        private void LoadProducts()
        {
            var products = _dbService.GetProducts();
            ProductComboBox.ItemsSource = products;
            ProductComboBox.DisplayMemberPath = "Name";
            ProductComboBox.SelectedValuePath = "Id";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int userId = (int)UserComboBox.SelectedValue;
            int productId = (int)ProductComboBox.SelectedValue;
            int quantity;
            if (!int.TryParse(QuantityTextBox.Text, out quantity))
            {
                MessageBox.Show("Количество должно быть числом!");
                return;
            }

            var product = (Product)ProductComboBox.SelectedItem;
            decimal totalAmount = product.Price * quantity;

            if (_dbService.CreatePayment(userId, productId, quantity, totalAmount))
            {
                MessageBox.Show("Платеж создан!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при создании платежа!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}