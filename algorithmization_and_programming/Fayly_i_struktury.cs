using System;
using System.IO;
using System.Linq;

struct Person
{
    public string Name;
    public string Phone;
    public string City;
    public Person(string name, string phone, string city)
    {
        Name = name;
        Phone = phone;
        City = city;
    }
    public override string ToString()
    {
        return $"{Name}, {Phone}, {City}";
    }
    public static Person FromString(string data)
    {
        var parts = data.Split(", ");
        return new Person(parts[0], parts[1], parts[2]);
    }
}
class Program
{
    static void Save(Person[] people, string filePath)
    {
        File.WriteAllLines(filePath, people.Select(p => p.ToString()));
    }

    static Person[] Load(string filePath)
    {
        return File.ReadAllLines(filePath).Select(Person.FromString).ToArray();
    }
    static void Main()
    {
        var Everything = new[]
        {
            new Person("Буквоедов Сережа", "+9658737912", "Тула"),
            new Person("Кондаков Николай", "+79835273933", "Рыбинск"),
            new Person("Корнеплод Виктор", "+7986533ВИТЯ", "Урюпинск")
        };

        Save(Everything, "data.txt");
        var data = Load("data.txt");
        Console.WriteLine("Введите город:");
        var cityInput = Console.ReadLine();
        var byCity = data.Where(p => p.City == cityInput).ToArray();
        Save(byCity, "city_data.txt");

        foreach (var p in Load("city_data.txt"))
        {
            Console.WriteLine($"{p.Name} {p.Phone} {p.City}");
        }
        Console.WriteLine("Введите фамилию:");
        var surnameInput = Console.ReadLine();
        var bySurname = data.Where(p => p.Name.StartsWith(surnameInput)).ToArray();
        Save(bySurname, "surname_data.txt");

        foreach (var p in Load("surname_data.txt"))
        {
            Console.WriteLine($"{p.Name} {p.Phone} {p.City}");
        }
        Console.WriteLine("Введите город и фамилию (через пробел):");
        var inputs = Console.ReadLine().Split(' ');
        var city = inputs[0];
        var surname = inputs[1];
        var byCandS = data.Where(p => p.City == city && p.Name.StartsWith(surname)).ToArray();
        Save(byCandS, "cands_data.txt");

        foreach (var p in Load("cands_data.txt"))
        {
            Console.WriteLine($"{p.Name} {p.Phone} {p.City}");
        }
    }
}