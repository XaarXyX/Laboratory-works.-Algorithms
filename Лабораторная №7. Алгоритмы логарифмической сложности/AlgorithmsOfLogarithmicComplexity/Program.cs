using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsOfLogarithmicComplexity
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

            Sorting.Quick_Sort(array);
            Sorting.Merge_Sort(array);
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
                double timeWork = Stopwatch(array, Sorting.Quick_Sort);
                Console.WriteLine($"Быстрая сортировка: {timeWork, 2}");

                Array.Copy(unsortedArray, array, count);
                timeWork = Stopwatch(array, Sorting.Merge_Sort);
                Console.WriteLine($"Сортировка слиянием: {timeWork, 2}");

                Array.Copy(unsortedArray, array, count);
                timeWork = Stopwatch(array, Sorting.Heap_Sort);
                Console.WriteLine($"Пирамидальная сортировка: {timeWork, 2}");

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}

