using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearComplexityAlgorithms;

namespace LinearComplexityAlgorithmsTests
{
    [TestClass]
    public class SortingTest
    {
        private static int[] unsortedArray = { 5, 2, 1, 9, 15, 7, 3, 8, 24, 6, 1, 12 };
        private static int[] sortedArray = { 1, 1, 2, 3, 5, 6, 7, 8, 9, 12, 15, 24 };
        private static int[] array;

        [TestMethod]
        public void CountingSort()
        {
            // Act
            array = new int[10];
            array = Sorting.Counting_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void PigeonholeSort()
        {
            // Act
            array = new int[10];
            array = Sorting.Pigeonhole_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        // Часть 2
        [TestMethod]
        public void BucketSort()
        {
            // Act
            array = new int[10];
            array = Sorting.Bucket_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void RadixSort()
        {
            // Act
            array = new int[10];
            array = Sorting.Radix_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }
    }
}
