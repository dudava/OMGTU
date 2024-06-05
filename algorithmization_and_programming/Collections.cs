using System.Collections;

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        ArrayOperations arrayOps = new ArrayOperations();
        ALOperations alOps = new ALOperations();
        SLOperations slOps = new SLOperations();
        int input1 = -1;
        bool arrayCreated = false;
        bool alCreated = false;
        bool slCreated = false;
        string[] arr = new string[0];
        ArrayList al = new ArrayList();
        SortedList sl = new SortedList();
        while (input1 != 0)
        {
            input1 = menu.showmenu();
            int input2 = -1;
            switch (input1)
            {
                case 1:
                    while (input2 != 0)
                    {
                        input2 = arrayOps.showArrayMenu(arrayCreated);
                        switch (input2)
                        {
                            case 1:
                                arr = arrayOps.createArray();
                                arrayCreated = true;
                                break;
                            case 2:
                                arrayOps.aCount(arr);
                                break;
                            case 3:
                                arrayOps.aBinSearch(arr);
                                break;
                            case 4:
                                arrayOps.aCopy(arr);
                                break;
                            case 5:
                                arrayOps.aFind(arr);
                                break;
                            case 6:
                                arrayOps.aFindLast(arr);
                                break;
                            case 7:
                                arrayOps.aIndexOf(arr);
                                break;
                            case 8:
                                arrayOps.aReverse(arr);
                                break;
                            case 9:
                                arrayOps.aResize(arr);
                                break;
                            case 10:
                                arrayOps.aSort(arr);
                                break;
                        }
                    }
                    break;

                case 2:
                    while (input2 != 0)
                    {
                        input2 = alOps.showALMenu(alCreated);
                        switch (input2)
                        {
                            case 1:
                                al = alOps.createAl();
                                alCreated = true;
                                break;
                            case 2:
                                alOps.alBinsearch(al);
                                break;
                            case 3:
                                alOps.alCopy(al);
                                break;
                            case 4:
                                alOps.alIndexOf(al);
                                break;
                            case 5:
                                alOps.alInsert(al);
                                break;
                            case 6:
                                alOps.alReverse(al);
                                break;
                            case 7:
                                alOps.alSort(al);
                                break;
                            case 8:
                                alOps.alAdd(al);
                                break;
                        }
                    }
                    break;

                case 3:
                    while (input2 != 0)
                    {
                        input2 = slOps.showSlMenu(slCreated);
                        switch (input2)
                        {
                            case 1:
                                sl = slOps.createSl();
                                slCreated = true;
                                break;
                            case 2:
                                slOps.slAdd(sl);
                                break;
                            case 3:
                                slOps.slIndexOfKey(sl);
                                break;
                            case 4:
                                slOps.slIndexOfValue(sl);
                                break;
                            case 5:
                                slOps.GetKeyByIndex(sl);
                                break;
                            case 6:
                                slOps.GetValueByIndex(sl);
                                break;
                        }
                    }
                    break;
            }
        }
    }
}

class Menu
{
    public int showmenu()
    {
        Console.WriteLine("\n\n0) Выход\n1) Array\n2) ArrayList\n3) SortedList");
        return Convert.ToInt32(Console.ReadLine());
    }
}

class ArrayOperations
{
    public int showArrayMenu(bool arrayCreated)
    {
        if (arrayCreated)
        {
            Console.WriteLine("\n\n0) Назад\n1) Создать массив\n2) Count\n3) BinSearch\n4) Copy\n5) Find\n6) FindLast\n7) IndexOf\n8) Reverse\n9) Resize\n10) Sort");
        }
        else
        {
            Console.WriteLine("\n\n0) Назад\n1) Создать массив");
        }
        return Convert.ToInt32(Console.ReadLine());
    }

    public string[] createArray()
    {
        Console.WriteLine("Массив создан: {'Что', 'вершит', 'судьбу', 'человечества', 'в', 'этом', 'мире?'}");
        return new string[] { "Что", "вершит", "судьбу", "человечества", "в", "этом", "мире?" };
    }

    public void aCount(string[] arr)
    {
        Console.Write($"Количество элементов в массиве: {arr.Length}");
    }

    public void aBinSearch(string[] arr)
    {
        Console.Write("Введите нужный элемент: ");
        string input = Console.ReadLine();
        int index = Array.BinarySearch(arr, input);
        if (index < 0) Console.Write("Элемент не найден");
        else Console.Write($"Индекс элемента: {index}");
    }

    public void aCopy(string[] arr)
    {
        string[] copyArr = new string[arr.Length];
        Array.Copy(arr, copyArr, arr.Length);
        Console.Write("Массив скопирован: ");
        correctArr(copyArr);
    }

    public void aFind(string[] arr)
    {
        Console.Write("Введите нужный элемент: ");
        string input = Console.ReadLine();
        string el = Array.Find(arr, x => x == input);
        if (el != null) Console.Write($"Найденный элемент: {el}");
        else Console.Write("Элемент не найден");
    }

    public void aFindLast(string[] arr)
    {
        Console.Write("Введите нужный элемент: ");
        string input = Console.ReadLine();
        string el = Array.FindLast(arr, x => x == input);
        if (el != null) Console.Write($"Найденный элемент: {el}");
        else Console.Write("Элемент не найден");
    }

    public void aIndexOf(string[] arr)
    {
        Console.Write("Введите нужный элемент: ");
        string input = Console.ReadLine();
        int index = Array.IndexOf(arr, input);
        if (index < 0) Console.Write("Элемент не найден");
        else Console.Write($"Индекс элемента: {index}");
    }

    public void aReverse(string[] arr)
    {
        Array.Reverse(arr);
        Console.Write("Перевернутый массив:");
        correctArr(arr);
    }

    public void aResize(string[] arr)
    {
        Console.Write("Введите новый размер: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Array.Resize(ref arr, input);
        Console.Write($"Массив после изменения размера:");
        correctArr(arr);
    }

    public void aSort(string[] arr)
    {
        Array.Sort(arr);
        Console.Write("Отсортированный массив:");
        correctArr(arr);
    }

    public void correctArr(string[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }
}

class ALOperations
{
    public int showALMenu(bool listCreated)
    {
        if (listCreated)
        {
            Console.WriteLine("\n\n0) Назад\n1) Создать ArrayList\n2) BinSearch\n3) Copy\n4) IndexOf\n5) Insert\n6) Reverse\n7) Sort\n8) Add");
        }
        else
        {
            Console.WriteLine("\n\n0) Назад\n1) Создать ArrayList");
        }
        return Convert.ToInt32(Console.ReadLine());
    }

    public ArrayList createAl()
    {
        Console.WriteLine("ArrayList создан: {\"Чебупели\", 52, 15605, \"Абрикос\", \"+79835273933\"}");
        return new ArrayList() { "Чебупели", "52", "15605", "Абрикос", "+79835273933" };
    }

    public void alBinsearch(ArrayList list)
    {
        Console.Write("Введите нужный элемент: ");
        string input = Console.ReadLine();
        int index = list.BinarySearch(input);
        if (index < 0) Console.Write("Элемент не найден");
        else Console.Write($"Индекс элемента: {index}");
    }

    public void alCopy(ArrayList list)
    {
        string[] copyAL = new string[list.Count];
        list.CopyTo(copyAL);
        Console.Write("ArrayList скопирован: ");
        foreach (string i in copyAL) Console.Write(i + " ");
    }

    public void alIndexOf(ArrayList list)
    {
        Console.Write("Введите нужный элемент: ");
        string input = Console.ReadLine();
        int index = list.IndexOf(input);
        if (index < 0) Console.Write("Элемент не найден");
        else Console.Write($"Индекс элемента: {index}");
    }

    public void alInsert(ArrayList list)
    {
        Console.Write("Введите элемент: ");
        string input = Console.ReadLine();
        Console.Write("Введите индекс: ");
        int index = Convert.ToInt32(Console.ReadLine());
        list.Insert(index, input);
        Console.Write("Элемент был помещен в ArrayList:");
        correctAL(list);
    }

    public void alReverse(ArrayList list)
    {
        list.Reverse();
        Console.Write("Перевернутый ArrayList:");
        correctAL(list);
    }

    public void alSort(ArrayList list)
    {
        list.Sort();
        Console.Write("Отсортированный ArrayList:");
        correctAL(list);
    }

    public void alAdd(ArrayList list)
    {
        Console.Write("Введите элемент: ");
        string input = Console.ReadLine();
        list.Add(input);
        Console.Write("Элемент был помещен в ArrayList:");
        correctAL(list);
    }

    public void correctAL(ArrayList list)
    {
        Console.WriteLine(string.Join(", ", list.ToArray()));
    }
}

class SLOperations
{
    public int showSlMenu(bool sortedCreated)
    {
        if (sortedCreated)
        {
            Console.WriteLine("\n\n0) Назад\n1) Создать SortedList\n2) Add\n3) IndexOfKey\n4) IndexOfValue\n5) KeyByIndex\n6) ValueByIndex");
        }
        else
        {
            Console.WriteLine("\n\n0) Назад\n1) Создать SortedList");
        }
        return Convert.ToInt32(Console.ReadLine());
    }

    public SortedList createSl()
    {
        Console.WriteLine("SortedList created: {\"Сварщик\": \"Леха\", \"Николай\": \"Пупуня\", \"пока что\": \"не придумал\"}");
        SortedList sortedList = new SortedList{ { "Сварщик", "Леха" }, { "Николай", "Пупуня" }, { "пока что", "не придумал" } };
        return sortedList;
    }

    public void slAdd(SortedList sortedList)
    {
        Console.Write("Введите ключ: ");
        string key = Console.ReadLine();
        Console.Write("Введите значение: ");
        string value = Console.ReadLine();
        sortedList.Add(key, value);
        Console.Write("Элемент добавлен: ");
        correctSL(sortedList);
    }

    public void slIndexOfKey(SortedList sortedList)
    {
        Console.Write("Введите ключ: ");
        string key = Console.ReadLine();
        int index = sortedList.IndexOfKey(key);
        if (index < 0) Console.Write("Ключ не найден");
        else Console.Write($"Индекс ключа: {index}");
    }

    public void slIndexOfValue(SortedList sortedList)
    {
        Console.Write("Введите значение: ");
        string value = Console.ReadLine();
        int index = sortedList.IndexOfValue(value);
        if (index < 0) Console.Write("Значение не найдено");
        else Console.Write($"Индекс значения: {index}");
    }

    public void GetKeyByIndex(SortedList sortedList)
    {
        Console.Write("Введите индекс: ");
        int index = Convert.ToInt32(Console.ReadLine());
        if (index >= 0 && index < sortedList.Count)
        {
            string key = Convert.ToString(sortedList.GetKey(index));
            Console.Write($"Ключ с индексом {index}: {key}");
        }
        else
        {
            Console.Write("Некорректный индекс");
        }
    }

    public void GetValueByIndex(SortedList sortedList)
    {
        Console.Write("Введите индекс: ");
        int index = Convert.ToInt32(Console.ReadLine());
        if (index >= 0 && index < sortedList.Count)
        {
            string value = Convert.ToString(sortedList.GetByIndex(index));
            Console.Write($"Значение с индексом {index}: {value}");
        }
        else
        {
            Console.Write("Некорректный индекс");
        }
    }

    private void correctSL(SortedList sortedList)
    {
        foreach (DictionaryEntry s in sortedList)
        {
            Console.WriteLine($"{s.Key}: {s.Value}");
        }
    }
}
