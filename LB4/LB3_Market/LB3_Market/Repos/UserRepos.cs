using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using LB3_Market.Models;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LB3_Market.Repos
{
    class UserRepos
    {

        public Users Login(string email, string password)
        {
            // Преобразуем введенный пароль в MD5-хеш
            string hashedPassword = Helpers.GetMd5Hash(password);

            Users user = null;

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT UserID, Role, Email, PasswordHash, FullName
                FROM Users 
                WHERE Email = @Email AND PasswordHash = @PasswordHash";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = hashedPassword;
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Users
                            {
                                UserID = reader.GetInt32(0),
                                Role = reader.GetString(1),
                                Email = reader.GetString(2),
                                PasswordHash = reader.GetString(3),
                                FullName = reader.GetString(4),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при входе в систему: {ex.Message}");
                    return null;
                }
            }

            return user;
        }
    }
}
