using LB3_Market.Models;
using LB3_Market.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LB3_Market
{
    /// <summary>
    /// Логика взаимодействия для EditProdWindow.xaml
    /// </summary>
    public partial class EditProdWindow : Window
    {
        private Products _product;
        public EditProdWindow()
        {
            InitializeComponent();
        }

        public EditProdWindow(Products product)
        {
            InitializeComponent();
            _product = product;
            LoadAgentData();
        }

        private void LoadAgentData()
        {
            ProductNameTextBox.Text = _product.ProductName;
            DescriptionTextBox.Text = _product.Description;
            PriceTextBox.Text = _product.Price.ToString();
            ImageURLTextBox.Text = _product.ImageURL;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _product.ProductName = ProductNameTextBox.Text;
            _product.Description = DescriptionTextBox.Text;
            _product.Price = decimal.TryParse(PriceTextBox.Text, out decimal price) ? price : _product.Price;
            _product.ImageURL = ImageURLTextBox.Text;

            ProductsRepo repo = new ProductsRepo();
            repo.UpdateUser(_product);

            MessageBox.Show("Данные продукта обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
