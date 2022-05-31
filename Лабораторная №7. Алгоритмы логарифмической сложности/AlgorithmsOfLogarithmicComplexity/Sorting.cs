using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsOfLogarithmicComplexity
{
    public static class Sorting
    {
        // Замена
        private static void Swap(ref int FirstArg, ref int SecondArg)
        {
            int temp = FirstArg;
            FirstArg = SecondArg;
            SecondArg = temp;
        }

        // Быстрая сортировка
        public static int[] Quick_Sort(int[] array)
        {
            return Quick_Sort(array, 0, array.Length - 1);
        }

        private static int[] Quick_Sort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return array;

            int bearingIndex = BearingIndex(array, minIndex, maxIndex);

            Quick_Sort(array, minIndex, bearingIndex - 1);
            Quick_Sort(array, bearingIndex + 1, maxIndex);

            return array;
        }

        // Получение индекса элемента bearing
        private static int BearingIndex(int[] array, int minIndex, int maxIndex)
        {
            int bearingIndex = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    bearingIndex++;
                    Swap(ref array[bearingIndex], ref array[i]);
                }
            }

            bearingIndex++;
            Swap(ref array[bearingIndex], ref array[maxIndex]);

            return bearingIndex;
        }

        // Пирамидальная сортировка
        public static int[] Heap_Sort(int[] array)
        {
            return Heap_Sort(array, array.Length);
        }

        private static int AddHeap(int[] array, int i, int length)
        {
            int imax;

            if ((2 * i + 2) < length)
            {
                if (array[2 * i + 1] < array[2 * i + 2])
                    imax = 2 * i + 2;
                else
                    imax = 2 * i + 1;
            }
            else
                imax = 2 * i + 1;

            if (imax >= length)
                return i;

            if (array[i] < array[imax])
            {
                Swap(ref array[i], ref array[imax]);

                if (imax < length / 2)
                    i = imax;
            }

            return i;
        }

        private static int[] Heap_Sort(int[] array, int length)
        {
            for (int i = length / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = AddHeap(array, i, length);
                if (prev_i != i) ++i;
            }

            for (int k = length - 1; k > 0; --k)
            {
                Swap(ref array[0], ref array[k]);
                int i = 0, prev_i = -1;

                while (i != prev_i)
                {
                    prev_i = i;
                    i = AddHeap(array, i, k);
                }
            }

            return array;
        }

        // Сортировка слиянием
        public static int[] Merge_Sort(int[] array)
        {
            return Merge_Sort(array, 0, array.Length - 1);
        }

        private static int[] Merge_Sort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex < maxIndex)
            {
                int middleIndex = minIndex + (maxIndex - minIndex) / 2;
                Merge_Sort(array, minIndex, middleIndex);
                Merge_Sort(array, middleIndex + 1, maxIndex);
                MergeHalves(array, minIndex, middleIndex, maxIndex);
            }
            return array;
        }

        private static void MergeHalves(int[] array, int minIndex, int middleIndex, int maxIndex)
        {
            var minArrayLength = middleIndex - minIndex + 1;
            var maxArrayLength = maxIndex - middleIndex;
            var minTempArray = new int[minArrayLength];
            var maxTempArray = new int[maxArrayLength];
            int i, j;

            for (i = 0; i < minArrayLength; ++i)
                minTempArray[i] = array[minIndex + i];

            for (j = 0; j < maxArrayLength; ++j)
                maxTempArray[j] = array[middleIndex + 1 + j];

            i = 0;
            j = 0;
            int k = minIndex;

            while (i < minArrayLength && j < maxArrayLength)
            {
                if (minTempArray[i] <= maxTempArray[j])
                {
                    array[k++] = minTempArray[i++];
                }
                else
                {
                    array[k++] = maxTempArray[j++];
                }
            }

            while (i < minArrayLength)
            {
                array[k++] = minTempArray[i++];
            }

            while (j < maxArrayLength)
            {
                array[k++] = maxTempArray[j++];
            }
        }
    }
}
