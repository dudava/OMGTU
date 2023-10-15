/******************************************************************************
Дан массив из н элементов. Надо определить
!Кол-во четных элементов расположенных между макс и мин элементами массива. Обработать ситуация,когда элементорв между мин и макс нет
!Определить все ли элементы стоящие на четных местах с точки зрения пользователя имеют в своей записи хотя бы одну пятерку % 10 = 5
Заменить все нечетные элементы массива на сумму цифр (его же)
Определить кол-во элементов значения которых больше смреднего арифметического нечетных элементов массива
Имеется ли в массиве хоть один отр элемент оканчивающийся на 3 % 10 == 3

*******************************************************************************/
using System;
class HelloWorld
{
    static int find_min_index(int[] nums)
    {
        double min_el = double.PositiveInfinity;
        int min_index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < min_el)
            {
                min_el = nums[i];
                min_index = i;
            }
        }
        return min_index;
    }
    static int find_max_index(int[] nums)
    {
        double max_el = double.NegativeInfinity;
        int max_index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max_el)
            {
                max_el = nums[i];
                max_index = i;
            }
        }
        return max_index;
    }

    static int[] get_nums_from_console()
    {
        Console.WriteLine("Введите количество элементов в массиве");
        int c = Convert.ToInt32(Console.ReadLine());
        int[] nums = new int[c];
        Console.WriteLine("Вводите элементы массива, каждый с новой строки");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }
        return nums;
    }
    static void even_el_between_min_max()
    {

        int[] nums = get_nums_from_console();

        int min_index = find_min_index(nums);
        int max_index = find_max_index(nums);

        if (min_index > max_index)
        {
            (min_index, max_index) = (max_index, min_index);
        }

        if (max_index - min_index <= 1)
        {
            Console.WriteLine("Между минимальным и максимальным нет элементов");
            return;
        }

        int count = 0;
        for (int i = min_index + 1; i < max_index; i++)
        {
            if (nums[i] % 2 == 0)
            {
                count++;
            }
        }
        Console.WriteLine("Количество четных элементов между максимальным и минимальным");
        Console.WriteLine(count);
    }

    static bool if_el_with_five(int num)
    {
        string str = num.ToString();
        bool flag = false;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '5')
            {
                flag = true; break;
            }
        }
        return flag;
    }

    static void even_el_in_own_position_with_five()
    {
        int[] nums = get_nums_from_console();
        bool flag = true;

        for (int i = 0; i < nums.Length; i++)
        {
            if ((i + 1) % 2 == 0)
            {
                if (!if_el_with_five(nums[i]))
                {
                    flag = false; break;
                }
            }
        }
        if (flag)
        {
            Console.WriteLine("Все ок");
        }
        else
        {
            Console.WriteLine("Нет");
        }
    }
    static int sum_digits(int num)
    {
        string str = num.ToString();
        int sum = 0;
        for (int i = 0; i < str.Length; i++)
        {
            sum += str[i] - '0';
        }
        return sum;
    }
    static void odd_to_sum()
    {
        int[] nums = get_nums_from_console();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 1)
            {
                nums[i] = sum_digits(nums[i]);
            }
            Console.WriteLine(nums[i]);
        }
    }

    static void count_el_greater_than_mean_odd()
    {
        int[] nums = get_nums_from_console();
        float odd_sum = 0;
        float odd_c = 0;
        for (int i=0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 1)
            {
                odd_sum += nums[i];
                odd_c++;
            }
        }
        float odd_mean = odd_sum / odd_c;
        int c = 0;
        for (int i=0 ; i < nums.Length ; i++)
        {
            if (nums[i] > odd_mean)
            {
                c++;
            }
        }
        Console.WriteLine("Среднее арифметическое нечетных элементов:");
        Console.WriteLine(odd_mean);
        Console.WriteLine("Количество элементов больших среднего арифметического нечетных равно:");
        Console.WriteLine(c);
    }

    static void is_negative_el_ended_3()
    {
        int[] nums = get_nums_from_console();
        bool flag = false;
        for (int i=0; i < nums.Length;i++) 
        {
            if (nums[i] < 0 && Math.Abs(nums[i] % 10) == 3)
            {
                flag = true;
                break;
            }
        }
        if (flag)
        {
            Console.WriteLine("В массиве есть отрицательный элемент, оканчивающийся на 3");
        }
        else
        {
            Console.WriteLine("Нет");
        }
    }

    static void Main()
    {
        //even_el_between_min_max();
        //even_el_in_own_position_with_five();
        //odd_to_sum();
        //count_el_greater_than_mean_odd();
        //is_negative_el_ended_3();
    }
}