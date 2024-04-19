using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\User\Documents\files\";
            string path_file_1 = path + "file_1.txt";
            string path_file_2 = path + "file_2.txt";
            string path_result_file = path + "merged_1_2.txt";

            using (StreamReader reader_1 = new StreamReader(path_file_1))
            {
                using (StreamReader reader_2 = new StreamReader(path_file_2))
                {
                    using (StreamWriter writer = new StreamWriter(path_result_file, true))
                    {
                        int line_1 = Convert.ToInt32(reader_1.ReadLine());
                        
                        int line_2 = Convert.ToInt32(reader_2.ReadLine());
                        int current = 0;
                        while (line_1 != 0 || line_2 != 0)
                        {
                            if (line_2 == 0 || line_1 < line_2)
                            {
                                current = line_1;
                                line_1 = Convert.ToInt32(reader_1.ReadLine());
                            }
                            else if (line_1 == 0 || line_2 < line_1) 
                            {
                                current = line_2;
                                line_2 = Convert.ToInt32(reader_2.ReadLine());
                            }
                            writer.WriteLine(Convert.ToString(current));
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
