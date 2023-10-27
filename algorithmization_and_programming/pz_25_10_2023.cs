using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static int sum_paths(int gas, int[] cities) {
            int sum = 0;
            for (int i = 0; i < cities.Length; i++) {
                sum += Math.Abs(gas - cities[i]);
            }
            return sum;
        }

        static bool is_valid_gas(int gas, int[] cities, int p) {
            for (int i = 0; i < cities.Length - 1; i++) {
                int start = cities[i];
                int end = cities[i + 1];
                if (gas >= start + p && gas <= end - p) {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            int p; int k; int z;
            Console.WriteLine("Введите количество городов: ");
            k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите p: ");
            p = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[k - 1];
            int[] cities = new int[k];
            int h = 0;
            cities[0] = 0;

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("Введите расстояние между " + i + " и " + (i + 1));
                a[i] = Convert.ToInt32(Console.ReadLine());
                cities[i + 1] = cities[i] + a[i];
                h += a[i];
            }

            int min_sum_paths = int.MaxValue;
            for (int i = 0; i < h; i++)
            {
                if (is_valid_gas(i, cities, p))
                {
                    int sum = sum_paths(i, cities);
                    if (sum < min_sum_paths)
                    {
                        min_sum_paths = sum;
                    }
                }
            }

            if (min_sum_paths == int.MaxValue)
            {
                Console.WriteLine("Заправку разместить невозможно");
            }
            else
            {
                Console.WriteLine("Минимальная сумма путей от заправки до городов");
                Console.WriteLine(min_sum_paths);

            }
            Console.ReadKey();            
        }
            
    }
}
