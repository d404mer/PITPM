using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

        // Встроенная логика парсинга ввода
        private int[] ParseInput()
        {
            try
            {
                return InputArray.Text.Split(',')
                                      .Select(s => int.Parse(s.Trim()))
                                      .ToArray();
            }
            catch
            {
                MessageBox.Show("Некорректный ввод! Введите числа через запятую.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        // Встроенная логика сортировки массива
        private string SortArray(int[] numbers, Action<int[]> sortFunction)
        {
            if (numbers == null) return "Ошибка: некорректный ввод!";
            sortFunction(numbers);
            return string.Join(", ", numbers);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(0, 10);
            }
            InputArray.Text = string.Join(", ", numbers);
        }
    }
}
