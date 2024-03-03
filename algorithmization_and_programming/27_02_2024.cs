using System.Collections;

static void KeepRecordMinutes(Dictionary<string, int> dictionary, Hashtable hashtable, string key, int minutesCount)
{
    if (dictionary.ContainsKey(key))
    {
        int minutesSum = dictionary[key] + minutesCount;
        dictionary[key] = minutesSum;
        hashtable[key] = minutesSum;
    }
    else
    {
        dictionary[key] = minutesCount;
        hashtable[key] = minutesCount;
    }
}


Queue<string> records = new Queue<string> ();
Dictionary<string, int> dictionaryMontlyReport = new Dictionary<string, int> ();
Dictionary<string, int> dictionaryDailyReport = new Dictionary<string, int>();
Hashtable hashtableMontlyReport = new Hashtable();
Hashtable hashtableDailyReport = new Hashtable();

while (true)
{
    string input = Console.ReadLine();
    if (input == "")
    {
        break;
    }
    records.Enqueue(input);
}

while(records.Count > 0)
{
    string[] record = records.Dequeue().Split(' ');
    string phone = record[0];
    string date = record[1];
    string time = record[2];
    int minutesCount = Convert.ToInt32(record[3]);

    KeepRecordMinutes(dictionaryMontlyReport, hashtableMontlyReport, phone, minutesCount);
    KeepRecordMinutes(dictionaryDailyReport, hashtableDailyReport, date, minutesCount);
}

Console.WriteLine("Месячный отчет по времени разговоров");
Console.WriteLine("Из словаря:");
foreach (string key in dictionaryMontlyReport.Keys)
{
    Console.WriteLine("{0}: {1} минут", key, dictionaryMontlyReport[key]);
}
Console.WriteLine("Из хеш-таблицы:");
foreach (string key in hashtableMontlyReport.Keys)
{
    Console.WriteLine("{0}: {1} минут", key, hashtableMontlyReport[key]);
}


Console.WriteLine("Введите дату для получения отчета");
string req_date = Console.ReadLine();
Console.WriteLine("Суммарное время разговоров за {0}: {1} минут из словаря", req_date, dictionaryDailyReport[req_date]);
Console.WriteLine("Суммарное время разговоров за {0}: {1} минут из хеш-таблицы", req_date, hashtableDailyReport[req_date]);