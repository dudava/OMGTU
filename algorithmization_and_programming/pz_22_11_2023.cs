int symb_count(string s, char req_symb)
{
    int c = 0;
    foreach (char symb in s)
    {
        if (symb == req_symb) c++;
    }
    return c;
}
int num_count(int[] s, int req_num)
{
    int c = 0;
    foreach (char num in s)
    {
        if (num== req_num) c++;
    }
    return c;
}
int[] string_to_int_arr(string s)
{
    int[] arr = new int[s.Length];
    for (int i = 0; i < s.Length; i++)
    {
        arr[i] = s[i] - '0';
    }
    return arr;
}

int[][] get_mouse_order(int white_count, int gray_count)
{
    // 0 - белая мышь, 1 - серая
    List<int[]> order = new List<int[]>();
    int count = white_count + gray_count;
    string first = string.Join("", Enumerable.Repeat('0', count));
    
    if (symb_count(first, '0') == white_count && symb_count(first, '1') == gray_count)
        order.Add(string_to_int_arr(first));

    int start_num = (int)Math.Pow(2, count - 1);
    int end_num = (int)Math.Pow(2, count);
    for (int i = start_num; i < end_num; i++)
    {
        string b_num = Convert.ToString(i, 2);
        if (symb_count(b_num, '0') == white_count && symb_count(b_num, '1') == gray_count)
        {
            order.Add(string_to_int_arr(b_num));
        }
    }

    return order.ToArray();
}

get_mouse_order(4, 2);

Console.WriteLine("Введите количество белых мышей");
int white_count = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество серых мышей");
int gray_count = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество белых мышей, которые должны выжить");
int white_lived_count = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество серых мышей, которые должны выжить");
int gray_lived_count = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Съедать каждую k-тую мышь");
int k = Convert.ToInt32(Console.ReadLine());
int count = white_count + gray_count;
int lived_count = white_lived_count + gray_lived_count;
 
int[][] orders = get_mouse_order(white_count, gray_count);
foreach (var init_mouses in orders)
{
    for (int i = 0; i < init_mouses.Length; i++)
    {
        int[] mouses = new int[count];
        Array.Copy(init_mouses, mouses, count);

        if (mouses[i] == 0) { continue; }
        int lived_mouses = count;
        int steps = k;
        int l = (i + 1) % count;
        while (true)
        {
            if (mouses[l] != -1)
            {
                steps--;
            }
            if (steps == 0)
            {
                mouses[l] = -1;
                lived_mouses -= 1;
                steps = k;
                if (lived_mouses == lived_count)
                {
                    if (num_count(mouses, 0) == white_lived_count && num_count(mouses, 1) == gray_lived_count)
                    {
                        Console.WriteLine("Расположение мышей: {0} (0 - белая, 1 - серая)",
                                          String.Join("", new List<int>(init_mouses).ConvertAll(i => i.ToString()).ToArray()));
                        Console.WriteLine("Позиция, с которой следует начать съедать мышей: {0}\n", i);
                    }
                    
                    break;
                }
                if (lived_mouses < lived_count) break;
            }
            l = (l + 1) % count;
        }
    }
}