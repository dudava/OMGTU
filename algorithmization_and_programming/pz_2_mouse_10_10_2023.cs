Console.WriteLine("Введите количество мышей");
int count = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Съедать каждую k-тую мышь");
int k = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Позиция белой мыши начиная с нуля");
int white_pos = Convert.ToInt32(Console.ReadLine());

for  (int i = 0; i < count; i++)
{
    int[] mouses = new int[count];
    for (int j = 0; j < count; j++)
    {
        mouses[j] = 1;
    }
    int steps = k;
    int l = (i + 1) % count;
    int lived_mouses = count;
    while (true)
    {
        if (mouses[l] != -1)
        {
            steps--;
        }
        if (steps == 0)
        {
            mouses[l] = -1;
            lived_mouses--;
            steps = k;

            if (lived_mouses >= 1 && l == white_pos)
            {
                break;
            }

            if (lived_mouses == 1)
            {
                Console.WriteLine("Позиция, с которой следует начать съедать мышей:");
                Console.WriteLine(i);
                break;
            }
        }
        l = (l + 1) % count;
    }
}