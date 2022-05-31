using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuadraticComplexityAlgorithms;

namespace QuadraticComplexityAlgorithmsTests
{
    [TestClass]
    public class SortingTest
    {
        private static int[] unsortedArray = { 5, 2, 1, 9, 15, 7, 3, 8, 24, 6, 1, 12 };
        private static int[] sortedArray = { 1, 1, 2, 3, 5, 6, 7, 8, 9, 12, 15, 24 };
        private static int[] array;

        [TestMethod]
        public void BubbleSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Bubble_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void ShakerSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Shaker_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void CombSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Comb_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void PickSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Pick_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void InsertSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Insert_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void ShellSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Shell_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }

        [TestMethod]
        public void GnomeSortTest()
        {
            // Act
            array = new int[10];
            array = Sorting.Gnome_Sort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(array, sortedArray);
        }
    }
}
