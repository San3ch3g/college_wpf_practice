using System.Windows;
using pracrica.db;
using pracrica.models;

namespace pracrica.windows.payments
{
    public partial class EditPaymentWindow : Window
    {
        private readonly DatabaseService _dbService;
        private readonly Payment _payment;

        public EditPaymentWindow(Payment payment)
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _payment = payment;
            LoadUsers();
            LoadProducts();
            QuantityTextBox.Text = _payment.Quantity.ToString();
        }

        private void LoadUsers()
        {
            var users = _dbService.GetUsers();
            UserComboBox.ItemsSource = users;
            UserComboBox.DisplayMemberPath = "Login";
            UserComboBox.SelectedValuePath = "Id";
            UserComboBox.SelectedValue = _payment.UserId;
        }

        private void LoadProducts()
        {
            var products = _dbService.GetProducts();
            ProductComboBox.ItemsSource = products;
            ProductComboBox.DisplayMemberPath = "Name";
            ProductComboBox.SelectedValuePath = "Id";
            ProductComboBox.SelectedValue = _payment.ProductId;
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

            if (_dbService.UpdatePayment(_payment.Id, userId, productId, quantity, totalAmount))
            {
                MessageBox.Show("Платеж обновлён!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении платежа!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}