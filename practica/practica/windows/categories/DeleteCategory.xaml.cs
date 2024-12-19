using System.Windows;
using pracrica.db;

namespace practica.windows.categories
{
    public partial class DeleteCategoryWindow : Window
    {
        private readonly DatabaseService _dbService;
        private readonly int _categoryId;

        public DeleteCategoryWindow(int categoryId)
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _categoryId = categoryId;

            CategoryIdTextBox.Text = _categoryId.ToString();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить категорию?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (_dbService.DeleteCategory(_categoryId))
                {
                    MessageBox.Show("Категория удалена!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении категории!");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}