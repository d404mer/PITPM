using LB3_Market.Models;
using System.Collections.Generic;
using LB3_Market.Repos;
using System.Windows;


namespace LB3_Market
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public List<Products> ProductsList { get; set; }
        public UserWindow()
        {
            InitializeComponent();

            var productRepository = new LB3_Market.Repos.ProductsRepo();
            ProductsList = productRepository.GetAllProducts();
            ProductItemsControl.ItemsSource = ProductsList;
        }
    }
}
