using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearComplexityAlgorithms
{
    public static class Sorting
    {
        // Сортировка подсчетом
        public static int[] Counting_Sort(int[] array)
        {
            return Counting_Sort(array, array.Min(), array.Max());
        }

        private static int[] Counting_Sort(int[] array, int min, int max)
        {
            int[] count = new int[max - min + 1];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
                count[array[i] - min]++;

            for (int i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    array[k++] = i;
                }
            }
            return array;
        }

        // Голубиная сортировка
        public static int[] Pigeonhole_Sort(int[] array)
        {
            Dictionary<int, int> array_dictionary = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array_dictionary.ContainsKey(array[i]))
                    array_dictionary[array[i]]++;
                else
                    array_dictionary.Add(array[i], 1);
            }

            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array_dictionary.ContainsKey(i))
                {
                    for (int j = 0; j < array_dictionary[i]; j++)
                        array[k++] = i;
                }
            }

            return array;
        }

        // Блочная сортировка
        public static int[] Bucket_Sort(int[] array)
        {
            int min = array.Min(), max = array.Max(), count = 0;
            List<int>[] buckets = new List<int>[max - min + 1];

            // Создаем карманы
            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = new List<int>();

            // Распределяем по карманам
            for (int i = 0; i < array.Length; i++)
                buckets[array[i] - min].Add(array[i]);

            // Собираем элементы карманов в исходный массив
            for (int i = 0; i < buckets.Length; i++)
                for (int j = 0; j < buckets[i].Count; j++)
                    array[count++] = buckets[i][j];

            return array;
        }

        // Поразрядная сортировка
        public static int[] Radix_Sort(int[] array)
        {
            return Radix_Sort(array, 10, (int)Math.Log10(array.Max()) + 1);
        }

        private static int[] Radix_Sort(int[] array, int range, int lengthNumber)
        {
            List<int>[] buckets = new List<int>[range];

            // Создаем карманы
            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = new List<int>();

            for (int i = 0; i < lengthNumber; i++)
            {
                // Распределяем по карманам
                for (int j = 0; j < array.Length; j++)
                    buckets[(array[j] % (int)Math.Pow(range, i + 1)) / (int)Math.Pow(range, i)].Add(array[j]);

                // Собираем элементы карманов в исходный массив
                int count = 0;
                for (int m = 0; m < buckets.Length; m++)
                    for (int n = 0; n < buckets[m].Count; n++)
                        array[count++] = buckets[m][n];

                for (int k = 0; k < buckets.Length; k++)
                    buckets[k].Clear();
            }

            return array;
        }
    }
}
