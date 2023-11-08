using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static int minimum(int[] lexa)
        {
            int min = lexa[0];
            for (int i = 0; i < lexa.Length; i++)
            {
                if (min > lexa[i]) min = lexa[i];
            }
            return min;
        }
        static int maximum(int[] lexa)
        {
            int max = lexa[0];
            for (int i = 0; i < lexa.Length; i++)
            {
                if (max < lexa[i]) max = lexa[i];
            }
            return max;
        }
        static int[][] massiv()
        {
            Console.WriteLine("Введите количество строк: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов: ");
            int m = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[n][];
            for (int i = 0; i < n; i++)
            {
                array[i] = new int[m];
                for (int j = 0; j < m; j++) {
                    Console.WriteLine("Введите " + (j+1) + " элемент " + (i+1) + " строки: ");
                    array[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            int count = 0;
            int[][]a = massiv();
            for (int i = 0; i < a.Length; i++)
            {
                int z = maximum(a[i]);
                int y = minimum(a[i]);
                if ((z % 2 == 0) && (y % 2 == 0)){
                    count++;
                }
            }
            Console.WriteLine("Количество строк с четными min и max элементами: " + count);
            Console.ReadKey();
        }
    }
}
