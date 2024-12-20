using System;
using System.Linq;
using System.Windows;
using pracrica.db;
using pracrica.models;

namespace pracrica.windows.payments
{
    public partial class PaymentsWindow : Window
    {
        private readonly DatabaseService _dbService;
        private Payment[] _allPayments;

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

            _allPayments = payments.ToArray();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var searchText = SearchTextBox.Text.ToLower();
            var startDate = StartDatePicker.SelectedDate;
            var endDate = EndDatePicker.SelectedDate;

            var filteredPayments = _allPayments.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                filteredPayments = filteredPayments.Where(p => p.ProductName.ToLower().Contains(searchText));
            }

            if (startDate != null)
            {
                filteredPayments = filteredPayments.Where(p => p.PaymentDate >= startDate);
            }

            if (endDate != null)
            {
                filteredPayments = filteredPayments.Where(p => p.PaymentDate <= endDate);
            }

            PaymentsDataGrid.ItemsSource = filteredPayments.ToList();
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void StartDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void EndDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ApplyFilters();
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
            DateTime? startDate = StartDatePicker.SelectedDate;
            DateTime? endDate = EndDatePicker.SelectedDate;

            var reportWindow = new ReportWindow(startDate, endDate);
            reportWindow.ShowDialog();
        }
    }
}