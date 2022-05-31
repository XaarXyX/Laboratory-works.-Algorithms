using System;

namespace SearchAlgorithms
{
    public static class Search
    {
        // Линейный поиск
        public static int LinePoisk(int[] mas, int numberFind)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == numberFind)
                {
                    return i;
                }
            }
            return -1;
        }

        // Линейный поиск с барьером
        public static int LineBarrier(int[] mas, int numberFind)
        {
            int i = 0;

            while (mas[i] != numberFind)
            {
                i++;
            }

            if (i == mas.Length - 1)
            {
                return -1;
            }

            return i;
        }

        // Бинарный итерационный поиск
        public static int Binary(int[] mas, int numberFind)
        {
            int left = 0;
            int right = mas.Length - 1;
            int k = -1;

            while (left <= right)
            {
                int middle = (right + left) / 2;

                if (numberFind <= mas[middle])
                {
                    if (numberFind == mas[middle])
                    {
                        k = middle;
                    }

                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return k;
        }

        //Прыжками
        public static int Jump(int[] array, int searchElement)
        {
            int startRange = 0;
            int step = Convert.ToInt32(Math.Sqrt(array.Length));
            int endRange = step;
            while (endRange < array.Length)
            {
                if (searchElement < array[endRange])
                {
                    for (int i = startRange; i < endRange; i++)
                    {
                        if (searchElement == array[i])
                        {
                            return i;
                        }
                    }

                    return -1;
                }

                startRange += step;
                endRange += step;
            }
            for (int i = startRange; i < array.Length; i++)
            {
                if (searchElement == array[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
