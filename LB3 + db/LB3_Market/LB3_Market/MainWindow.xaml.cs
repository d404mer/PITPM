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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LB3_Market
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = UsernameInput.Text;
            string password = PasswordInput.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите email и пароль", "Ошибка входа",
                               MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            try
            {
                var userRepository = new LB3_Market.Repos.UserRepos();

                var user = userRepository.Login(email, password);

                if (user != null)
                {
                  
                        MessageBox.Show($"Добро пожаловать, {user.FullName}!",
                                       "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);

                        App.SetCurrentUser(user);

                        OpenWindowByRole(user.Role);

                        this.Close();
                   
                }
                else
                {
                    MessageBox.Show("Неверный email или пароль. Пожалуйста, попробуйте снова.",
                                   "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при входе: {ex.Message}",
                               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void OpenWindowByRole(string role)
        {
            switch (role)
            {
                case App.ROLE_ADMIN:
                    // Окно для администратора
                    AdminPanel adminWindow = new AdminPanel();
                    adminWindow.Show();
                    break;


                case App.ROLE_USER:
                default:
                    // Окно для обычного пользователя
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    break;
            }
        }
    }
 }
