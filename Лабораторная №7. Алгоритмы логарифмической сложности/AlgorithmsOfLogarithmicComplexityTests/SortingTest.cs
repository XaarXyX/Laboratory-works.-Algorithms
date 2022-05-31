using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsOfLogarithmicComplexity;

namespace AlgorithmsOfLogarithmicComplexityTests
{
    [TestClass]
    public class SortingTest
    {
        private static int[] unsortedArray = { 5, 2, 1, 9, 15, 7, 3, 8, 24, 6, 1, 12 };
        private static int[] sortedArray = { 1, 1, 2, 3, 5, 6, 7, 8, 9, 12, 15, 24 };
        private static int[] array;

        [TestMethod]
        public void QuickSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Quick_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Merge_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void HeapSort()
        {
            // Act
            array = new int[10];
            array = Sorting.Heap_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }
    }
}
