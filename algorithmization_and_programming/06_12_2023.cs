using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Car
    {
        public string name;
        public int age;
        public string number;
        public List<int> to;

        public Car()
        {
            this.name = "Арбуз";
            this.age = 2000;
            this.to = new List<int>() { 2000, 2014 };
            this.number = "в004ко";
        }
        public Car(string name, int age, List<int> to, string number)
        {
            this.name = name;
            this.age = age;
            this.to = to;
            this.number = number;
        }
    }
    class LightCar : Car
    {
        public string body_type;
        public int power;

        public LightCar(string name, int age, List<int> to, string number, string body_type, int power)
            : base(name, age, to, number)
        {
            this.body_type = body_type;
            this.power = power;
        }
    }
    class Truck : Car
    {
        public int payload;

        public Truck(string name, int age, List<int> to, string number, int payload)
            : base(name, age, to, number)
        {
            this.payload = payload;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество машин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            List<LightCar> lightcars = new List<LightCar>();
            List<Truck> trucks = new List<Truck>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Будете ли вы вводить параметры машины {0}? (y/n)", i + 1);
                string answer1 = Console.ReadLine();
                if (answer1 == "y")
                {
                    Console.WriteLine("Введите тип машины (Light, Truck: ");
                    string answer2 = Console.ReadLine();
                    if (answer2 == "Light")
                    {
                        Console.WriteLine("Введите название машины: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите год выпуска машины: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите номер машины: ");
                        string number = Console.ReadLine();
                        Console.WriteLine("Сколько ТО было пройдено?");
                        List<int> to = new List<int>();
                        int answer3 = Convert.ToInt32(Console.ReadLine());
                        for (int j = 0; j < answer3; j++)
                        {
                            Console.WriteLine("Введите дату {0}? техосмотра: ", j + 1);
                            int answer4 = Convert.ToInt32(Console.ReadLine());
                            to.Add(Convert.ToInt32(Console.ReadLine()));
                        }
                        Console.WriteLine("Введите тип кузова машины: ");
                        string body_type = Console.ReadLine();
                        Console.WriteLine("Введите мощность двигателя машины: ");
                        int power = Convert.ToInt32(Console.ReadLine());
                        LightCar car = new LightCar(name, age, to, number, body_type, power);
                    }
                    if (answer2 == "Truck")
                    {
                        Console.WriteLine("Введите название машины: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите год выпуска машины: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите номер машины: ");
                        string number = Console.ReadLine();
                        Console.WriteLine("Сколько ТО было пройдено?");
                        List<int> to = new List<int>();
                        int answer3 = Convert.ToInt32(Console.ReadLine());
                        for (int j = 0; j < answer3; j++)
                        {
                            Console.WriteLine("Введите дату {0}? техосмотра: ", j + 1);
                            int answer4 = Convert.ToInt32(Console.ReadLine());
                            to.Add(Convert.ToInt32(Console.ReadLine()));
                        }
                        Console.WriteLine("Введите грузоподьемность машины: ");
                        int payload = Convert.ToInt32(Console.ReadLine());
                        cars[i] = new Truck(name, age, to, number, payload);
                        Console.WriteLine("Машина создана!");
                    }
                    else if (answer1 == "n")
                    {
                        cars[i] = new Car();
                        Console.WriteLine("Создана машина со стандартными параметрами");
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, выберите y/n");
                    }
                }
            }
            Console.WriteLine("Выборка по типу кузова, введите тип кузова: ");
            string need_body_type = Console.ReadLine();
            Console.WriteLine("Следующие машины имеют заданный тип кузова: ");
            Console.WriteLine("-------Начало списка-------");
            for (int i = 0; i < n; i++)
            {
                if (cars[i].body_type == need_body_type){

                }
        }
    }
}
           

            