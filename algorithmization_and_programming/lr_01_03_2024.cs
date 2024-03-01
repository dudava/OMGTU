using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication26
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> numbers = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] inputSplited = input.Split(' ');
                string number = inputSplited[0];
                numbers.Add(number);
            }
            Console.WriteLine("Количество уникальных номеров: {0}", numbers.Count);
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }
            

            List<HashSet<int>> sets = new List<HashSet<int>>() {
                 new HashSet<int>() { 1, 2, 3, 4 },
                 new HashSet<int>() { 3, 4, 5, 6 },
                 new HashSet<int>() { 3, 4, 8, 9 }
            };

            HashSet<int> universum = new HashSet<int>();
            HashSet<int> inter = new HashSet<int>(sets[0]);

            foreach (HashSet<int> set in sets)
            {
                universum.UnionWith(set);
            }
            Console.WriteLine("Объединение множеств");
            Console.WriteLine(String.Join(" ", universum));

            for (int i = 1; i < sets.Count; i++)
            {
                inter.IntersectWith(sets[i]);
            }
            Console.WriteLine("Пересечение множеств");
            Console.WriteLine(String.Join(" ", inter));

            Console.WriteLine("Дополнения множеств");
            foreach (HashSet<int> set in sets)
            {
                HashSet<int> add = new HashSet<int>();
                Console.WriteLine("Исходное множество: {0}. Дополнение: {1}", String.Join(" ", set), String.Join(" ", universum.Except(set)));
            }
            Console.ReadKey();
        }
    }
}
