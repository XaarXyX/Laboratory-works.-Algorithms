using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyAlgorithms_Task_2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество сторожей \nN: ");
            int N = Int16.Parse(Console.ReadLine());

            Dictionary<double, double> Guard = new Dictionary<double, double>(N);
            Dictionary<double, double> Defended = new Dictionary<double, double>(N);
            double past = 0;
            Console.WriteLine("\nВведите действительные числа через пробел - время прихода и время ухода сторожа:");
            for (int i = 1; i <= N; i++)
            {
                string[] temporal = Console.ReadLine().Split(' ');
                Guard.Add(double.Parse(temporal[0]), double.Parse(temporal[1]));
            }
            Guard.Add(24, 24);

            foreach (KeyValuePair<double, double> meaning in Guard.OrderBy(key => key.Key))
            {
                if (meaning.Key - past > 0 && Guard.Count != 1)
                {
                    Defended.Add(past, meaning.Key);
                    past = meaning.Value;
                    Guard.Remove(meaning.Key);
                }
                else if (Guard.Count == 1 && 24 - past > 0)
                {
                    Defended.Add(past, 24);
                }
                else
                {
                    past = meaning.Value;
                    Guard.Remove(meaning.Key);
                }
            }

            Console.WriteLine("\nГалерея без охраны:");
            if (Defended.Count > 0)
            {
                foreach (KeyValuePair<double, double> meaning in Defended)
                    Console.WriteLine($"{meaning.Key:0.00} - {meaning.Value:0.00}");
            }
            else
                Console.WriteLine("Охраняется всегда");

            Console.ReadKey();
        }
    }
}
