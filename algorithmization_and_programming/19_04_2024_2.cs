using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\User\Documents\files\strings.txt";
            string min_string = "";
            int min_count = int.MaxValue;
            foreach (var st in File.ReadLines(path)) {
                var matches = Regex.Matches(st, @"a+");
                string[] substrings = new string[matches.Count];
                for (int i = 0; i < matches.Count; i++)
                {
                    substrings[i] = matches[i].ToString();
                }
                int min_sub;
                if (substrings.Length == 0)
                {
                    min_sub = 0;
                }
                else 
                {
                    min_sub = substrings.Min(str => str.Length);   
                }
                
                if (min_sub < min_count)
                {
                    min_string = st;
                    min_count = min_sub;
                }
            }
            Console.WriteLine(min_string);
            Console.WriteLine(min_count);
            Console.ReadKey();
        }
    }
}
