using System;

namespace QuadraticComplexityAlgorithms
{
    public static class Sorting
    {
        private static void Swap(ref int FirstArg, ref int SecondArg)
        {
            int temp = FirstArg;
            FirstArg = SecondArg;
            SecondArg = temp;
        }

        // Пузырьковая сортировка
        public static int[] Bubble_Sort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                        Swap(ref array[j], ref array[j + 1]);
                }
            }

            return array;
        }

        // Шейкерная сортировка
        public static int[] Shaker_Sort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var flag = false;

                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        flag = true;
                    }
                }

                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        flag = true;
                    }
                }

                if (!flag)
                    break;
            }

            return array;
        }

        // Сортировка расчёской
        public static int[] Comb_Sort(int[] array)
        {
            var length = array.Length;
            var currentmove = length - 1;

            while (currentmove > 1)
            {
                for (int i = 0; i + currentmove < array.Length; i++)
                {
                    if (array[i] > array[i + currentmove])
                        Swap(ref array[i], ref array[i + currentmove]);
                }

                currentmove = GetNextmove(currentmove);
            }

            return Bubble_Sort(array);
        }

        // Генерация следующего шага
        private static int GetNextmove(int move)
        {
            move = move * 1000 / 1247;
            return move > 1 ? move : 1;
        }

        // Сортировка выбором
        public static int[] Pick_Sort(int[] array)
        {
            int indexMin = 0, indexMax = 0;

            for (int i = 0; i < array.Length / 2; i++)
            {
                var minValue = int.MaxValue;
                var maxValue = 0;
                var tmp = 0;

                for (int j = i; j < array.Length - i; j++)
                {
                    if (minValue > array[j])
                    {
                        minValue = array[j];
                        indexMin = j;
                    }
                    if (array[j] > maxValue)
                    {
                        maxValue = array[j];
                        indexMax = j;
                    }
                }

                tmp = array[i];
                if (i == indexMax)
                {
                    indexMax = indexMin;
                }

                array[i] = minValue;
                array[indexMin] = tmp;

                tmp = array[array.Length - i - 1];
                array[array.Length - i - 1] = maxValue;
                array[indexMax] = tmp;
            }

            return array;
        }

        // Сортировка вставками
        public static int[] Insert_Sort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }

            return array;
        }

        // Сортировка Шелла
        public static int[] Shell_Sort(int[] array)
        {
            var move = array.Length / 2;
            while (move >= 1)
            {
                for (var i = move; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= move) && (array[j - move] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - move]);
                        j = j - move;
                    }
                }

                move = move / 2;
            }

            return array;
        }

        // Гномья сортировка
        public static int[] Gnome_Sort(int[] array)
        {
            int i = 1, j = 2;

            while (i < array.Length)
            {
                if (array[i - 1] < array[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    Swap(ref array[i - 1], ref array[i]);
                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }

            return array;
        }
    }
}
