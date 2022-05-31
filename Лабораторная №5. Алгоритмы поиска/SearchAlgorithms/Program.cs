using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SearchAlgorithms
{
    class Program
    {
        // Поиск
        public static void Find(int[] array, int numberFind)
        {
            int index;
            double workTime;

            // В неупорядоченном массиве
            // Линейный
            workTime = Stopwatch(Search.LinePoisk, array, numberFind, out index);
            Console.WriteLine($"Линейный \tИндекс: \t{index} \tВремя: \t{workTime}");

            // Линейный с барьером
            int[] arrayWithBarrier = Generator.LinearBarrier(array, numberFind);
            workTime = Stopwatch(Search.LineBarrier, arrayWithBarrier, numberFind, out index);
            Console.WriteLine($"C барьером \tИндекс: \t{index} \tВремя: \t{workTime}");

            // В упорядоченном массиве
            Array.Sort(array);

            // Бинарный итерационный
            workTime = Stopwatch(Search.Binary, array, numberFind, out index);
            Console.WriteLine($"Бинарный \tИндекс: \t{index} \tВремя: \t{workTime}");

            // Прыжковый
            workTime = Stopwatch(Search.Jump, array, numberFind, out index);
            Console.WriteLine($"Прыжковый \tИндекс: \t{index} \tВремя: \t{workTime}");
        }

        public static double Stopwatch(Func<int[], int, int> method, int[] array, int numberToFind, out int result)
        {
            Stopwatch sw = new Stopwatch();
            double workTime = 0;

            sw.Start();
            result = method(array, numberToFind);
            sw.Stop();
            workTime += sw.ElapsedMilliseconds;

            return workTime;
        }

        static void Main(string[] args)
        {
            List<int> arrayLength = new List<int> { 10000, 20000, 30000, 40000, 50000 };

            foreach (int number in arrayLength)
            {
                int numberFind = 13;
                int[] array; // Неупорядоченный массив

                Console.WriteLine("Средний случай: {0} элементов. Найти - {1}", number, numberFind);
                array = Generator.Average(number);
                Find(array, numberFind);

                Console.WriteLine("Худший случай: {0} элементов. Найти - {1}", number, numberFind);
                array = Generator.Worst(number, numberFind);
                Find(array, numberFind);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
