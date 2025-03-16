using LB3_Market.Models;
using System.Windows;
using LB3_Market.Repos;
using System.Collections.Generic;
using System.Linq;  // Добавьте это пространство имен
using System;
using System.Windows.Input;
using System.Windows.Controls;

namespace LB3_Market
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private ProductsRepo _productsRepo;
        private List<Products> _allProducts;
        private Products _selectedProduct;

        public AdminPanel()
        {
            InitializeComponent();

            _productsRepo = new ProductsRepo();
            _allProducts = new List<Products>();

            this.Loaded += ProductsPanel_Loaded;
        }

        private void ProductsPanel_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                _allProducts = _productsRepo.GetAllProducts();

                this.Dispatcher.Invoke(() =>
                {
                    if (ProductsDataGrid != null)
                    {
                        UpdateProductsGrid();
                    }
                });
            }
            catch (Exception ex)
            {
                _allProducts = new List<Products>();
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateProductsGrid()
        {
            if (ProductsDataGrid == null || _allProducts == null) return;

            var displayProducts = _allProducts.Select(a => new
            {
                ProductID = a.ProductID,
                ProductName = a.ProductName,
                Description = a.Description,
                Price = a.Price,
                ImageURL = a.ImageURL
            }).ToList();  

            ProductsDataGrid.ItemsSource = displayProducts;
        }

        private void ProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = ProductsDataGrid.SelectedItem;
            if (selectedItem != null)
            {
                var type = selectedItem.GetType();
                var productIDProperty = type.GetProperty("ProductID"); 
                int productID = (int)productIDProperty.GetValue(selectedItem); 

                var selectedProduct = _allProducts.FirstOrDefault(a => a.ProductID == productID);
                if (selectedProduct != null)
                {
                    EditProdWindow editWindow = new EditProdWindow(selectedProduct);
                    editWindow.ShowDialog();

                    LoadProducts();
                }
            }
        }



        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ProductsDataGrid.SelectedItem;
            if (selectedItem != null)
            {
                var type = selectedItem.GetType();
                var productIDProperty = type.GetProperty("ProductID"); 
                int productID = (int)productIDProperty.GetValue(selectedItem); 

                _selectedProduct = _allProducts.FirstOrDefault(a => a.ProductID == productID);
            }
            else
            {
                _selectedProduct = null;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProdw addAgentWindow = new AddProdw();
            if (addAgentWindow.ShowDialog() == true)
            {
                LoadProducts(); 
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(_selectedProduct != null)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить товар {_selectedProduct.ProductName}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    bool success = ProductsRepo.DeleteProd(_selectedProduct.ProductID);
                    if (success)
                    {
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
