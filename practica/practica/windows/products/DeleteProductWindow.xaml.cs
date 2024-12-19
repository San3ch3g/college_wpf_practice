using System.Windows;
using pracrica.db;

namespace pracrica.windows.products
{
    public partial class DeleteProductWindow : Window
    {
        private readonly DatabaseService _dbService;
        private readonly int _productId;

        public DeleteProductWindow(int productId)
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _productId = productId;

            // Заполняем поле идентификатора
            ProductIdTextBox.Text = _productId.ToString();
        }

        // Обработчик нажатия на кнопку "Удалить"
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Подтверждение удаления
            if (MessageBox.Show("Вы уверены, что хотите удалить продукт?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Удаляем продукт
                if (_dbService.DeleteProduct(_productId))
                {
                    MessageBox.Show("Продукт удалён!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении продукта!");
                }
            }
        }

        // Обработчик нажатия на кнопку "Отмена"
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрываем окно
        }
    }
}