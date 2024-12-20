using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using pracrica.db;
using pracrica.models;
using System.Collections.Generic;

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
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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

        // Метод для экспорта отчёта в Excel
        private void ExportToExcel(List<ReportCategory> categories)
        {
            // Создаём имя файла с текущей датой
            string fileName = $"Отчёт от {DateTime.Now:dd.MM.yyyy}.xlsx";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Создаём новый Excel-файл
            using (var package = new ExcelPackage())
            {
                foreach (var category in categories)
                {
                    // Создаём новый лист для каждой категории
                    var worksheet = package.Workbook.Worksheets.Add(category.CategoryName);

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Название продукта";
                    worksheet.Cells[1, 2].Value = "Итоговая сумма";

                    // Заполняем данные
                    int row = 2;
                    foreach (var product in category.Products)
                    {
                        worksheet.Cells[row, 1].Value = product.ProductName;
                        worksheet.Cells[row, 2].Value = product.TotalAmount;
                        row++;
                    }

                    // Итоговая сумма категории
                    worksheet.Cells[row, 1].Value = "Итого:";
                    worksheet.Cells[row, 2].Value = category.TotalAmount;

                    // Автоподбор ширины столбцов
                    worksheet.Cells.AutoFitColumns();
                }

                // Сохраняем файл
                package.SaveAs(new FileInfo(filePath));
            }

            MessageBox.Show($"Отчёт успешно экспортирован в файл: {filePath}");
        }

        // Обработчик для экспорта
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            var categories = ReportDataGrid.ItemsSource as List<ReportCategory>;
            if (categories != null && categories.Any())
            {
                ExportToExcel(categories);
            }
            else
            {
                MessageBox.Show("Нет данных для экспорта.");
            }
        }
    }
}