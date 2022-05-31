using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuadraticComplexityAlgorithms
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

            Sorting.Bubble_Sort(array);
            Sorting.Shaker_Sort(array);
        }

        static void Main(string[] args)
        {
            SingleRun();

            foreach (var count in numbersCountList)
            {
                int[] unsortedarray = UnsortedArray(count);
                int[] array = new int[count];

                Console.WriteLine($"Количество элементов: {count}");
                Array.Copy(unsortedarray, array, count);
                double timeWork = Stopwatch(array, Sorting.Bubble_Sort);
                Console.WriteLine($"Пузырьковая: {timeWork, 2}");

                Array.Copy(unsortedarray, array, count);
                timeWork = Stopwatch(array, Sorting.Shaker_Sort);
                Console.WriteLine($"Шейкерная: {timeWork, 2}");

                Array.Copy(unsortedarray, array, count);
                timeWork = Stopwatch(array, Sorting.Comb_Sort);
                Console.WriteLine($"Расческой: {timeWork, 2}");

                Array.Copy(unsortedarray, array, count);
                timeWork = Stopwatch(array, Sorting.Pick_Sort);
                Console.WriteLine($"Выбором: {timeWork, 2}");

                Array.Copy(unsortedarray, array, count);
                timeWork = Stopwatch(array, Sorting.Insert_Sort);
                Console.WriteLine($"Вставками: {timeWork, 2}");

                Array.Copy(unsortedarray, array, count);
                timeWork = Stopwatch(array, Sorting.Shell_Sort);
                Console.WriteLine($"Шелла: {timeWork, 2}");

                Array.Copy(unsortedarray, array, count);
                timeWork = Stopwatch(array, Sorting.Gnome_Sort);
                Console.WriteLine($"Гномья: {timeWork, 2}");

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
