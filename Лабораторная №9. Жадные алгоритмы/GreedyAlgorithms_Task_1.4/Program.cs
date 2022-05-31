using System;

namespace GreedyAlgorithms_Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите расстояние между пунктами А и В и расстояние, которое автомобиль может проехать с полным баком: ");
            string[] temporal = Console.ReadLine().Split(' ');
            int N = int.Parse(temporal[0]);
            int k = int.Parse(temporal[1]);

            Console.Write("Введите количество бензоколонок и расстояние от пункта А до каждой заправки: ");
            temporal = Console.ReadLine().Split(' ');
            int[] array = new int[int.Parse(temporal[0])];
            int count = 0, rast = 0;
            for(int i = 0; i < int.Parse(temporal[0]); i++)
            {
                array[i] = int.Parse(temporal[i + 1]);
            }
            Array.Sort(array);

            while (rast < N && k < N)
            {
                if (k >= array[count])
                {
                    rast += array[count++];
                    if (count == array.Length)
                    {
                        rast += k;
                        break;
                    }
                }
                else
                    break;
            }
            if(rast >= N || k >= N)
                Console.WriteLine($"{count}");
            else
                Console.WriteLine("-1");
            
            Console.ReadKey();
        }
    }
}
