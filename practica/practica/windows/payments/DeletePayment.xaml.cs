using System.Windows;
using pracrica.db;

namespace pracrica.windows.payments
{
    public partial class DeletePaymentWindow : Window
    {
        private readonly DatabaseService _dbService;
        private readonly int _paymentId;

        public DeletePaymentWindow(int paymentId)
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _paymentId = paymentId;

            PaymentIdTextBox.Text = _paymentId.ToString();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить платеж?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (_dbService.DeletePayment(_paymentId))
                {
                    MessageBox.Show("Платеж удалён!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении платежа!");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}