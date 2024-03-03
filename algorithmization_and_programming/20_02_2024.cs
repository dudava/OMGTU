using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

static bool CheckBrackets(string brackets)
{
    Stack<char> stack = new Stack<char>();
    foreach(char bracket in brackets)
    {
        if (bracket == '(' || bracket == '[' || bracket == '{')
        {
            stack.Push(bracket);
        }
        else
        {
            if (stack.Count == 0)
            {
                return false;
            }
            char stackBracket = stack.Pop();
            switch (bracket)
            {
                case ')': 
                    if (stackBracket != '(')
                    {
                        return false;
                    }
                    break;
                case ']':
                    if (stackBracket != '[')
                    {
                        return false;
                    }
                    break;
                case '}':
                    if (stackBracket != '{')
                    {
                        return false;
                    }
                    break;
                default: 
                    return false;
            }
        }
    }
    return true;
}


static void ShowReversePolishNotationResult(string expr)
{
    Stack<int> numbers = new Stack<int>();
    int? result = null;
    
    foreach(char c in expr) 
    {
        if (c >= 48 && c <= 57)
        {
            numbers.Push(c - '0');
        }
        else
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("Недостаточно операндов");
                return;
            }
            if (result == null)
            {
                result = numbers.Pop();
            }
            switch (c)
            {
                case '+':
                    result += numbers.Pop();
                    break;
                case '-':
                    result -= numbers.Pop();
                    break;
                case '*':
                    result *= numbers.Pop();
                    break;
                case '/':
                    int tryNumber = numbers.Pop();
                    if (tryNumber == 0)
                    {
                        Console.WriteLine("Деление на ноль");
                        return;
                    }
                    result /= numbers.Pop();
                    break;
            }
        }
    }
    if (numbers.Count > 0)
    {
        Console.WriteLine("Результат не однозначен");
        return;
    }
    Console.WriteLine("Результат выполнения выражения: {0}", result);
}


Console.WriteLine("Введите строку скобок");
string input = Console.ReadLine();
if (CheckBrackets(input))
{
    Console.WriteLine("Строка правильная");
}
else
{
    Console.WriteLine("Строка неправильная");
}

Console.WriteLine("Введите обратную польскую нотацию");
input = Console.ReadLine();
ShowReversePolishNotationResult(input);
Console.ReadKey();
