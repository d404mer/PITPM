
using PITPM_LABA1.SortingSSSS;
using PITPM_LB1.SortingSSSS;


namespace XUnitTestProject_LORDSAVEUS
{
    public class SortingTests
    {
        // Тест: корректное преобразование строки в массив
        [Fact]
        public void ParseInput_ValidInput_ReturnsExpectedArray()
        {
            // Arrange
            string input = "5, 3, 1, 4, 2";
            var expected = new int[] { 5, 3, 1, 4, 2 };

            // Act
            var result = SortingHelper.ParseInput(input);

            // Assert
            Assert.Equal(expected, result);
        }

        // Тест: некорректный ввод должен вернуть null
        [Fact]
        public void ParseInput_InvalidInput_ReturnsNull()
        {
            // Arrange
            string input = "5, abc, 1, 4, 2";

            // Act
            var result = SortingHelper.ParseInput(input);

            // Assert
            Assert.Null(result);
        }

        // Тест: пузырьковая сортировка
        [Fact]
        public void BubbleSort_SortsArrayCorrectly()
        {
            // Arrange
            var input = new int[] { 5, 3, 1, 4, 2 };
            var expected = new int[] { 1, 2, 3, 4, 5 };

            // Act
            BubbleSort.Sort(input);

            // Assert
            Assert.Equal(expected, input);
        }

        // Тест: сортировка вставками
        [Fact]
        public void InsertionSort_SortsArrayCorrectly()
        {
            // Arrange
            var input = new int[] { 5, 3, 1, 4, 2 };
            var expected = new int[] { 1, 2, 3, 4, 5 };

            // Act
            InsertionSort.Sort(input);

            // Assert
            Assert.Equal(expected, input);
        }

        // Тест: быстрая сортировка
        [Fact]
        public void QuickSort_SortsArrayCorrectly()
        {
            // Arrange
            var input = new int[] { 5, 3, 1, 4, 2 };
            var expected = new int[] { 1, 2, 3, 4, 5 };

            // Act
            QuickSort.Sort(input, 0, input.Length - 1);

            // Assert
            Assert.Equal(expected, input);
        }

        // Тест: сортировка с использованием пузырьковой сортировки и возвращение строки
        [Fact]
        public void SortArray_WithBubbleSort_ReturnsSortedString()
        {
            // Arrange
            var input = new int[] { 5, 3, 1, 4, 2 };
            var expected = "1, 2, 3, 4, 5";

            // Act
            var result = SortingHelper.SortArray(input, BubbleSort.Sort);

            // Assert
            Assert.Equal(expected, result);
        }

        // Тест: проверка ошибки при некорректном вводе
        [Fact]
        public void SortArray_WithInvalidInput_ReturnsErrorMessage()
        {
            // Arrange
            int[] input = null;
            var expected = "Ошибка: некорректный ввод!";

            // Act
            var result = SortingHelper.SortArray(input, BubbleSort.Sort);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}