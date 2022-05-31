using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms;

namespace LineBarrier
{
    [TestClass]
    public class LineBarrierTests
    {
        public static int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0};

        [TestMethod]
        public void LineWithBarrier_Find0()
        {
            // Act
            int result = Search.LineBarrier(array, 1);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void LineWithBarrier_Find1()
        {
            // Act
            int result = Search.LineBarrier(array, 10);

            // Assert
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void LineWithBarrier_Find2()
        {
            // Act
            int result = Search.LineBarrier(array, 5);

            // Assert
            Assert.AreEqual(result, 4);
        }
    }
}
