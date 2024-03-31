using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication34
{
    class Program
    {
        public delegate double UnaryOperation(double a);
        public delegate double BinaryOperation(double a, double b);

        static double ProcessUnaryOperation(UnaryOperation op)
        {
            Console.WriteLine("Введите число");
            double a = Convert.ToDouble(Console.ReadLine());
            return op(a);
        }
        static double ProcessBinaryOperation(BinaryOperation op)
        {
            Console.WriteLine("Введите первый операнд");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второй операнд");
            double b = Convert.ToDouble(Console.ReadLine());
            
            return op(a, b);
        }
        static double SafeDivision(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Деление на ноль");
            }
            return a / b;
        }
        static double SafeSqrt(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("Корень из отрицательного числа");
            }
            return Math.Sqrt(a);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Какую операцию выполнить? (сложение, вычитание, умножение, деление, корень, синус, косинус)");
            string answer = Console.ReadLine();
            double result = 0;
            switch (answer) {
                case "сложение":
                    result = ProcessBinaryOperation((double a, double b) => { return a + b; });
                    break;
                case "вычитание":
                    result = ProcessBinaryOperation((double a, double b) => { return a - b; });
                    break;
                case "умножение":
                    result = ProcessBinaryOperation((double a, double b) => { return a * b; });
                    break;
                case "деление":
                    result = ProcessBinaryOperation(SafeDivision);
                    break;
                case "корень":
                    result = ProcessUnaryOperation(SafeSqrt);
                    break;
                case "синус":
                    result = ProcessUnaryOperation(Math.Sin);
                    break;
                case "косинус":
                    result = ProcessUnaryOperation(Math.Cos);
                    break;
            }
            
            
            Console.WriteLine("Результат: {0}", result);
            Console.ReadKey();
        }
    }
}
