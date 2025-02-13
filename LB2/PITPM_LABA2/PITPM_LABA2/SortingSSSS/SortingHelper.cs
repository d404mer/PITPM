using System;
using System.Linq;

namespace PITPM_LABA1.SortingSSSS
{
    public static class SortingHelper
    {
        // Метод для парсинга входной строки в массив чисел
        public static int[] ParseInput(string input)
        {
            try
            {
                // Разделяем строку по запятой, удаляем пробелы и пытаемся преобразовать в массив чисел
                return input.Split(',')
                            .Select(s => int.Parse(s.Trim()))
                            .ToArray();
            }
            catch
            {
                // В случае ошибки (например, если ввод некорректный) возвращаем null
                return null;
            }
        }

        // Метод для сортировки массива с использованием заданной функции сортировки
        public static string SortArray(int[] numbers, Action<int[]> sortFunction)
        {
            // Проверяем на null
            if (numbers == null) return "Ошибка: некорректный ввод!";

            // Вызываем функцию сортировки
            sortFunction(numbers);

            // Возвращаем отсортированный массив в виде строки
            return string.Join(", ", numbers);
        }
    }
}
