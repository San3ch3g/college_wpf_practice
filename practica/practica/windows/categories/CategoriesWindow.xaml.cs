using System.Windows;
using pracrica.db;
using pracrica.models;
using practica.windows.categories;

namespace practica.windows.categories
{
    public partial class CategoriesWindow : Window
    {
        private readonly DatabaseService _dbService;

        public CategoriesWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            LoadCategories(); 
        }

        private void LoadCategories()
        {
            var categories = _dbService.GetCategories();
            CategoriesDataGrid.ItemsSource = categories;
        }

        private void CreateCategory_Click(object sender, RoutedEventArgs e)
        {
            var createCategoryWindow = new CreateCategoryWindow();
            if (createCategoryWindow.ShowDialog() == true)
            {
                LoadCategories();
            }
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                var editCategoryWindow = new EditCategoryWindow(selectedCategory);
                if (editCategoryWindow.ShowDialog() == true)
                {
                    LoadCategories(); 
                }
            }
            else
            {
                MessageBox.Show("Выберите категорию для редактирования!");
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category selectedCategory)
            {
                var deleteCategoryWindow = new DeleteCategoryWindow(selectedCategory.Id);
                if (deleteCategoryWindow.ShowDialog() == true)
                {
                    LoadCategories();
                }
            }
            else
            {
                MessageBox.Show("Выберите категорию для удаления!");
            }
        }
    }
}