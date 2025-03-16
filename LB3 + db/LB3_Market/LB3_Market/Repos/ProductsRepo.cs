using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using LB3_Market.Models;

namespace LB3_Market.Repos
{
    public class ProductsRepo
    {
        public virtual List<Products> GetAllProducts()
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


        public virtual bool UpdateUser(Products product)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"UPDATE Products 
                 SET ProductName = @ProductName, 
                     Description = @Description, 
                     Price = @Price, 
                     ImageURL = @ImageURL 
                 WHERE ProductID = @ProductID";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@ImageURL", product.ImageURL);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при обновлении продукта: {ex.Message}");
                    throw; 
                }
            }
        }

        public virtual bool DeleteProd(int ProductID)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"DELETE FROM Products WHERE ProductID = @ProductID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при удалении товара: {ex.Message}");
                    return false;
                }
            }
        }

        public virtual bool AddProduct(Products product)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"INSERT INTO Products (ProductName, Description, Price, ImageURL) 
                 VALUES (@ProductName, @Description, @Price, @ImageURL)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@ImageURL", product.ImageURL);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при добавлении агента: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
