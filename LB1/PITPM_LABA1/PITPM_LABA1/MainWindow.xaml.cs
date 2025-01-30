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
using PITPM_LB1.SortingSSSS;

namespace PITPM_LABA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BubbleSort_Click(object sender, RoutedEventArgs e)
        {
            int[] numbers = ParseInput();
            if (numbers == null) return;
            BubbleSort.Sort(numbers);
            OutputArray.Text = string.Join(", ", numbers);
        }

        private void InsertionSort_Click(object sender, RoutedEventArgs e)
        {
            int[] numbers = ParseInput();
            if (numbers == null) return;
            InsertionSort.Sort(numbers);
            OutputArray.Text = string.Join(", ", numbers);
        }

        private void QuickSort_Click(object sender, RoutedEventArgs e)
        {
            int[] numbers = ParseInput();
            if (numbers == null) return;
            QuickSort.Sort(numbers, 0, numbers.Length - 1);
            OutputArray.Text = string.Join(", ", numbers);
        }


        private int[] ParseInput()
        {
            try
            {
                return InputArray.Text.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
            }
            catch
            {
                MessageBox.Show("Некорректный ввод! Введите числа через запятую.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private void ClearInput_Click(object sender, RoutedEventArgs e)
        {
            InputArray.Text = "";
            OutputArray.Text = "";
        }

        private void ClearOutput_Click(object sender, RoutedEventArgs e)
        {
            OutputArray.Text = "";
        }
    }
}
