using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LinearComplexityAlgorithms
{
    public class Program
    {
        private static List<int> numbersCountList = new List<int> { 1000, 2000, 3000, 4000, 5000 };
        private static Random random = new Random();
        private delegate int[] Sort(int[] array);

        // Таймер
        private static double Stopwatch(int[] array, Sort sort)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            sort(array);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        // Не отсортированный массив
        private static int[] UnsortedArray(int count)
        {
            int[] array = new int[count];

            for (var i = 0; i < array.Length; i++)
                array[i] = random.Next(1, count);

            return array;
        }

        // Одиночный прогон
        private static void SingleRun()
        {
            int[] array = new int[10000];

            for (var i = 0; i < array.Length; i++)
                array[i] = random.Next(1, 1000);

            Sorting.Counting_Sort(array);
            Sorting.Radix_Sort(array);
        }

        static void Main(string[] args)
        {
            SingleRun();

            foreach (var count in numbersCountList)
            {
                int[] unsortedArray = UnsortedArray(count);
                int[] array = new int[count];

                Console.WriteLine($"Количество элементов: {count}");

                Array.Copy(unsortedArray, array, count);
                double timeWork = Stopwatch(array, Sorting.Counting_Sort);
                Console.WriteLine($"Сортировка подсчетом: {timeWork, 2}");

                Array.Copy(unsortedArray, array, count);
                timeWork = Stopwatch(array, Sorting.Pigeonhole_Sort);
                Console.WriteLine($"Голубиная сортировка: {timeWork, 2}");

                Array.Copy(unsortedArray, array, count);
                timeWork = Stopwatch(array, Sorting.Bucket_Sort);
                Console.WriteLine($"Блочная сортировка: {timeWork, 2}");

                Array.Copy(unsortedArray, array, count);
                timeWork = Stopwatch(array, Sorting.Radix_Sort);
                Console.WriteLine($"Поразрядная сортировка: {timeWork, 2}");

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
