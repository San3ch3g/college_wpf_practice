using System.Windows;
using pracrica.db;
using pracrica.models;

namespace practica.windows.categories
{
    public partial class EditCategoryWindow : Window
    {
        private readonly DatabaseService _dbService;
        private readonly Category _category;

        public EditCategoryWindow(Category category)
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _category = category;

            CategoryIdTextBox.Text = _category.Id.ToString();
            CategoryNameTextBox.Text = _category.Name;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = CategoryNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите название категории!");
                return;
            }

            if (_dbService.UpdateCategory(_category.Id, name))
            {
                MessageBox.Show("Категория обновлена!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении категории!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}