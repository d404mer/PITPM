using System.Windows;
using LB3_Market.Repos;
using LB3_Market.Models;

namespace LB3_Market
{
    /// <summary>
    /// Логика взаимодействия для AddProdw.xaml
    /// </summary>
    public partial class AddProdw : Window
    {
        public AddProdw()
        {
            InitializeComponent();
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(ImageURLTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Неверный формат цены. Должно быть числовым значением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Products newProduct = new Products
            {
                ProductName = ProductNameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Price = price,
                ImageURL = ImageURLTextBox.Text
            };

            bool success = ProductsRepo.AddProduct(newProduct);
            if (success)
            {
                MessageBox.Show("Продукт добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении продукта.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
