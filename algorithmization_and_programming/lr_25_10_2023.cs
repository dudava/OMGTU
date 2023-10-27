using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApplication6
{
    class Program
    {
        static bool el_check(int el, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (el == array[i])
                {
                    return true;
                }
            }
            return false;
        }

        static bool el_is_everywhere(int k, int[] min_array, int[][] main_array)
        {
            int el = min_array[k];
            for (int j = 0; j < main_array.Length; j++)
            {
                if (!el_check(el, main_array[j]))
                {
                    return false;
                }
            }
            return true;
        }


        static int[] find_intersection(int[][] main_array, int min_array_index)
        {
            int[] min_array = main_array[min_array_index];
            List<int> intersection = new List<int>();

            for (int k = 0; k < min_array.Length; k++)
            {
                if (el_is_everywhere(k, min_array, main_array))
                {
                    intersection.Add(min_array[k]);
                }
            }
            return intersection.ToArray();

        }

        static bool is_in_list(int el, List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (el == list[i])
                {
                    return true;
                }
            }
            return false;
        }

        static int[] find_unity(int[][] main_array)
        {
            List<int> unity = new List<int>();
            for (int i = 0; i < main_array.Length; i++)
            {
                for (int j = 0; j < main_array[i].Length; j++)
                {
                    if (!is_in_list(main_array[i][j], unity))
                    {
                        unity.Add(main_array[i][j]);
                    }
                }
            }
            return unity.ToArray();
        }

        static int[] find_max_els(int[][] main_array)
        {
            int[] max_els = new int[main_array.Length];
            for (int i = 0; i < main_array.Length; i++)
            {
                max_els[i] = main_array[i].Max();
            }
            return max_els;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество множеств");
            int rows = Convert.ToInt32(Console.ReadLine());
            int cols;
            int min_cols = 99999999;
            int min_array_index = -1;
            int[][] main_array = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("Введите количество элементов для {0}-ого множества", i);
                cols = Convert.ToInt32(Console.ReadLine());
                main_array[i] = new int[cols];
                if (cols < min_cols)
                {
                    min_cols = cols;
                    min_array_index = i;
                }

                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine("Введите {0}-ый элемент", j);
                    main_array[i][j] = int.Parse(Console.ReadLine());
                }
            }

            int[] intersection = find_intersection(main_array, min_array_index);
            Console.WriteLine("Пересечение множеств:");
            for (int i = 0; i < intersection.Length; i++)
            {
                Console.WriteLine(intersection[i]);
            }
            int[] unity = find_unity(main_array);
            Console.WriteLine("Объединение множеств:");
            for (int i = 0; i < unity.Length; i++)
            {
                Console.WriteLine(unity[i]);
            }
            int[] max_els = find_max_els(main_array);
            Console.WriteLine("Максимальные элементы множеств:");
            for (int i = 0; i < max_els.Length; i++)
            {
                Console.WriteLine(max_els[i]);
            }
            Console.ReadKey();
        }
    }
}