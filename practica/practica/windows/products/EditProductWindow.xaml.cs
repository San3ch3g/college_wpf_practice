using System.Windows;
using pracrica.db;
using pracrica.models;

namespace pracrica.windows.products
{
    public partial class EditProductWindow : Window
    {
        private readonly DatabaseService _dbService;
        private readonly Product _product;

        public EditProductWindow(Product product)
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _product = product;
            LoadCategories();

            // Заполняем поля данными
            ProductIdTextBox.Text = _product.Id.ToString();
            ProductNameTextBox.Text = _product.Name;
            ProductPriceTextBox.Text = _product.Price.ToString();
        }

        private void LoadCategories()
        {
            var categories = _dbService.GetCategories();
            CategoryComboBox.ItemsSource = categories;
            CategoryComboBox.DisplayMemberPath = "Name";
            CategoryComboBox.SelectedValuePath = "Id";
            CategoryComboBox.SelectedValue = _product.CategoryId;
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

            if (_dbService.UpdateProduct(_product.Id, categoryId, name, price))
            {
                MessageBox.Show("Продукт обновлён!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении продукта!");
            }
        }

        // Обработчик нажатия на кнопку "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрываем окно
        }
    }
}