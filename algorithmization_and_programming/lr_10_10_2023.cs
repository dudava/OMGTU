int[] get_int_array_from_console()
{
    Console.WriteLine("Введите количество элементов в массиве");
    int c = Convert.ToInt32(Console.ReadLine());
    int[] nums = new int[c];
    Console.WriteLine("Вводите числа, каждое с новой строки");

    for (int i = 0; i < c; i++)
    {
        nums[i] = Convert.ToInt32(Console.ReadLine());
    }
    return nums;
}


void check_multiple_numbers()
{
    Console.WriteLine("Все ли числа кратны своей позиции начиная с 1");
    int[] nums = get_int_array_from_console();

    bool flag = true;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] % (i + 1) != 0)
        {
            flag = false; break;
        }
    }

    if (flag)
    {
        Console.WriteLine("Все числа кратны номеру под которым они стоят");
    }
    else
    {
        Console.WriteLine("Не все числа кратны номеру под которым они стоят");
    }
}


void first_even_number()
{
    Console.WriteLine("Положение первого четного элемента массива");
    int[] nums = get_int_array_from_console();
    
    for (int i = 0;i < nums.Length;i++)
    {
        if (nums[i] % 2 == 0)
        {
            Console.WriteLine("Положение первого четного элемента:");
            Console.WriteLine(i + 1); break;
        }
    }
}


void last_zero_number()
{
    Console.WriteLine("Положение последнего нулевого элемента");
    int[] nums = get_int_array_from_console();
    int zero_el_position = 0;

    for (int i = 0; i < nums.Length;i++)
    {
        if (nums[i] == 0)
        {
            zero_el_position = i + 1;
        }
    }
    Console.WriteLine("Положение последнего нулевого элемента в массиве: (если 0, значит его нет)");
    Console.WriteLine(zero_el_position);
}


void count_numbers_multiple_min()
{
    int get_min_el_exclude_zero(int[] nums)
    {
        double min_el = double.PositiveInfinity;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < min_el && nums[i] != 0)
            {
                min_el = nums[i];
            }
        }
        return Convert.ToInt32(min_el);
    }
    Console.WriteLine("Количество элементов массива кратных минимальному (кроме 0)");
    int[] nums = get_int_array_from_console();
    int min_el = get_min_el_exclude_zero(nums);
    int c = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] % min_el == 0)
        {
            c++;
        }
    }
    Console.WriteLine("Количество элементов кратных минимальному:");
    Console.WriteLine(c);
}


void decreasing_nums_between_min_max()
{
    int get_index_min(int[] nums)
    {
        double min_el = double.PositiveInfinity;
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < min_el)
            {
                min_el = nums[i];
                index = i;
            }
        }
        return index;
    }

    int get_index_max(int[] nums)
    {
        double max_el = double.NegativeInfinity;
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max_el)
            {
                max_el = nums[i];
                index = i;
            }
        }
        return index;
    }

    Console.WriteLine("Образуют ли элементы массива между минимальным и максимальным убывающую последовательность");
    int[] nums = get_int_array_from_console();
    int min_index = get_index_min(nums);
    int max_index = get_index_max(nums);

    if (min_index > max_index)
    {
        (min_index, max_index) = (max_index, min_index);
    }

    if (nums.Length == 1)
    {
        Console.WriteLine("В массиве только один элемент");
        return;
    }
    else if (max_index - min_index == 1)
    {
        Console.WriteLine("В массиве нет элементов между минимальным и максимальным");
        return;
    }

    else
    {
        int prev_el = nums[min_index + 1];
        bool flag = true;
        for (int i = min_index + 1; i < max_index; i++)
        {
            if (nums[i] > prev_el)
            {
                flag = false; break;
            }
            else
            {
                prev_el = nums[i];
            }
        }
        if (flag)
        {
            Console.WriteLine("Последовательность убывающая");
        }
        else
        {
            Console.WriteLine("Нет");
        }
    }
}


//check_multiple_numbers();
//first_even_number();
//last_zero_number();
//count_numbers_multiple_min();
//decreasing_nums_between_min_max();