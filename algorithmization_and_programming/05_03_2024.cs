using System.Collections;


class PhoneInfo
{
    public int countCalls;
    public int countMinutes;
    public PhoneInfo(int countMinutes)
    {
        this.countMinutes = countMinutes;
        this.countCalls = 1;
    }

    public void UpdatePhoneInfo(int countMinutes)
    {
        this.countMinutes += countMinutes;
        this.countCalls += 1;
    }
}

class PhoneReport
{
    Dictionary<string, PhoneInfo> phones;
    
    public PhoneReport()
    {
        phones = new Dictionary<string, PhoneInfo>();
    }

    public void UpdatePhoneInfo(string incomingNumber, int countMinutes)
    {
        if(!phones.ContainsKey(incomingNumber))
        {
            phones[incomingNumber] = new PhoneInfo(countMinutes);
        }
        else
        {
            phones[incomingNumber].UpdatePhoneInfo(countMinutes);
        }
    }

    public string GetLargestCallsPhone()
    {
        string number = "";
        int maxCountCalls = int.MinValue;

        foreach (var phone in phones)
        {
            PhoneInfo phoneInfo = phone.Value;
            if (phoneInfo.countCalls > maxCountCalls)
            {
                maxCountCalls = phoneInfo.countCalls;
                number = phone.Key;
            }
        }
        return number;
    }

    public string GetLargestMinutesCountPhone()
    {
        string number = "";
        int maxCountMinutes = int.MinValue;

        foreach (var phone in phones)
        {
            PhoneInfo phoneInfo = phone.Value;
            if (phoneInfo.countMinutes > maxCountMinutes)
            {
                maxCountMinutes = phoneInfo.countMinutes;
                number = phone.Key;
            }
        }
        return number;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, PhoneReport>> numbers = new();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "")
            {
                break;
            }
            string[] splitedInput = input.Split(" ");
            string outcomingPhone = splitedInput[0];
            string incomingPhone = splitedInput[1];
            string date = splitedInput[2];
            int minutesCount = Convert.ToInt32(splitedInput[3]);
            if (!numbers.ContainsKey(outcomingPhone))
            {
                numbers[outcomingPhone] = new();
            }
            if (!numbers[outcomingPhone].ContainsKey(date))
            {
                numbers[outcomingPhone][date] = new PhoneReport();
            }
            numbers[outcomingPhone][date].UpdatePhoneInfo(incomingPhone, minutesCount);
        }
        foreach (var outcomingPhone in numbers.Keys)
        {
            foreach (var date in numbers[outcomingPhone].Keys)
            {
                PhoneReport phoneReport = numbers[outcomingPhone][date];
                Console.WriteLine("Номер: {0}, Дата: {1}, Наибольшее число звонков: {2}, Наибольшее время разговоров: {3}", outcomingPhone, date, phoneReport.GetLargestCallsPhone(), phoneReport.GetLargestMinutesCountPhone());
            }
         }
    } 
}


