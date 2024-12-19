using System.Windows;
using pracrica.db;

namespace practica.windows.categories
{
    public partial class CreateCategoryWindow : Window
    {
        private readonly DatabaseService _dbService;

        public CreateCategoryWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = CategoryNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите название категории!");
                return;
            }

            if (_dbService.CreateCategory(name))
            {
                MessageBox.Show("Категория создана!");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при создании категории!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}