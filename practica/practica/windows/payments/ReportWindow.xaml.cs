using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using pracrica.db;
using pracrica.models;

namespace pracrica.windows.payments
{
    public partial class ReportWindow : Window
    {
        private readonly DatabaseService _dbService;
        private readonly DateTime? _startDate;
        private readonly DateTime? _endDate;

        public ReportWindow(DateTime? startDate, DateTime? endDate)
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _startDate = startDate;
            _endDate = endDate;

            LoadReportData();
        }

        private void LoadReportData()
        {
            var payments = _dbService.GetPayments()
                .Where(p => (_startDate == null || p.PaymentDate >= _startDate) &&
                            (_endDate == null || p.PaymentDate <= _endDate))
                .ToList();

            var categories = new List<ReportCategory>();

            foreach (var payment in payments)
            {
                var productName = _dbService.GetProductNameById(payment.ProductId);
                var categoryName = _dbService.GetCategoryNameByProductId(payment.ProductId);

                // Найти или создать категорию
                var category = categories.FirstOrDefault(c => c.CategoryName == categoryName);
                if (category == null)
                {
                    category = new ReportCategory { CategoryName = categoryName };
                    categories.Add(category);
                }

                // Добавить товар в категорию
                var product = category.Products.FirstOrDefault(p => p.ProductName == productName);
                if (product == null)
                {
                    product = new ReportProduct { ProductName = productName };
                    category.Products.Add(product);
                }

                // Увеличить общую сумму товара
                product.TotalAmount += payment.TotalAmount;

                // Увеличить общую сумму категории
                category.TotalAmount += payment.TotalAmount;
            }

            // Добавить итоговую сумму
            var totalAmount = categories.Sum(c => c.TotalAmount);
            categories.Add(new ReportCategory
            {
                CategoryName = "ИТОГО",
                TotalAmount = totalAmount
            });

            // Привязать данные к ItemsControl
            ReportDataGrid.ItemsSource = categories;
        }
    }
}