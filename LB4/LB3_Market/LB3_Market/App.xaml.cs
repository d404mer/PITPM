using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LB3_Market.Models;

namespace LB3_Market
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_USER = "User";

        public static void SetCurrentUser(Users user)
        {
            if (user != null)
            {
                user.PasswordHash = null;
            }

            Current.Resources["CurrentUser"] = user;
        }
    }
}
