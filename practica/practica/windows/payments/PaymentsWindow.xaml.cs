using System.Windows;
using pracrica.db;
using pracrica.models;

namespace pracrica.windows.payments
{
    public partial class PaymentsWindow : Window
    {
        private readonly DatabaseService _dbService;

        public PaymentsWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            LoadPayments();
        }

        private void LoadPayments()
        {
            var payments = _dbService.GetPayments();

            foreach (var payment in payments)
            {
                payment.UserName = _dbService.GetUserNameById(payment.UserId);
                payment.ProductName = _dbService.GetProductNameById(payment.ProductId);
            }

            PaymentsDataGrid.ItemsSource = payments;
        }

        private void CreatePayment_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreatePaymentWindow();
            if (createWindow.ShowDialog() == true)
            {
                LoadPayments();
            }
        }

        private void EditPayment_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentsDataGrid.SelectedItem is Payment selectedPayment)
            {
                var editWindow = new EditPaymentWindow(selectedPayment);
                if (editWindow.ShowDialog() == true)
                {
                    LoadPayments();
                }
            }
            else
            {
                MessageBox.Show("Выберите платеж для редактирования!");
            }
        }

        private void DeletePayment_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentsDataGrid.SelectedItem is Payment selectedPayment)
            {
                var deleteWindow = new DeletePaymentWindow(selectedPayment.Id);
                if (deleteWindow.ShowDialog() == true)
                {
                    LoadPayments();
                }
            }
            else
            {
                MessageBox.Show("Выберите платеж для удаления!");
            }
        }
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Открыть экран отчётов");
        }
    }
}