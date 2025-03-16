using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LB3_Market.Models;

namespace LB3_Market.Repos
{
    class ProductsRepo
    {
        public List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT ProductID, ProductName, Description, Price, ImageURL
                                 FROM Products"; 

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Products
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Price = reader.GetDecimal(3),
                                ImageURL = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };

                            products.Add(product);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при получении списка товаров: {ex.Message}");
                    throw;
                }
            }

            return products;
        }
    }
}
