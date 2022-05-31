using System;

namespace SearchAlgorithms
{
    static class Generator
    {
        static Random random = new Random();

        // Средний случай, случайные элементы
        public static int[] Average(int numbersCount)
        {
            int[] array = new int[numbersCount];

            for (int i = 0; i < numbersCount; i++)
            {
                array[i] = random.Next(0, numbersCount);
            }

            return array;
        }

        // Худший случай, все элементы отличаются от искомого числа
        public static int[] Worst(int numbersCount, int numberFind)
        {
            int[] array = new int[numbersCount];
            int number = 100 + numberFind;

            for (int i = 0; i < numbersCount; i++)
            {
                array[i] = number;
            }

            return array;
        }

        // Средний случай с барьером
        public static int[] LinearBarrier(int[] array, int numberFind)
        {
            int[] arrayBarrier = new int[array.Length + 1];
            array.CopyTo(arrayBarrier, 0);
            arrayBarrier[arrayBarrier.Length - 1] = numberFind;

            return arrayBarrier;
        }
    }
}
