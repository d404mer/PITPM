using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PITPM_LB1.SortingSSSS;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BubbleSort_Test()
        {
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };

            BubbleSort.Sort(input);

            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void InsertionSort_Test()
        {
            int[] input = { 10, -3, 5, 0, 2 };
            int[] expected = { -3, 0, 2, 5, 10 };

            InsertionSort.Sort(input);

            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void QuickSort_Test()
        {
            int[] input = { 9, 7, 5, 11, 12, 2, 14, 3 };
            int[] expected = { 2, 3, 5, 7, 9, 11, 12, 14 };

            QuickSort.Sort(input, 0, input.Length - 1);

            CollectionAssert.AreEqual(expected, input);
        }
    }
}
