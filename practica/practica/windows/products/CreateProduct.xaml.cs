using System.Windows;
using pracrica.db;

namespace pracrica.windows.products
{
    public partial class CreateProductWindow : Window
    {
        private readonly DatabaseService _dbService;

        public CreateProductWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = _dbService.GetCategories();
            CategoryComboBox.ItemsSource = categories;
            CategoryComboBox.DisplayMemberPath = "Name";
            CategoryComboBox.SelectedValuePath = "Id";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = ProductNameTextBox.Text;
            decimal price;
            if (!decimal.TryParse(ProductPriceTextBox.Text, out price))
            {
                MessageBox.Show("Цена должна быть числом!");
                return;
            }

            int categoryId = (int)CategoryComboBox.SelectedValue;

            if (_dbService.CreateProduct(categoryId, name, price))
            {
                MessageBox.Show("Продукт создан!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при создании продукта!");
            }
        }

        // Обработчик нажатия на кнопку "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрываем окно
        }
    }
}