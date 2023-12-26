using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
            this.name = "ГАЗ";
            this.age = 1970;
            this.to = new List<int>() { 1971, 2023 };
            this.number = "А123ВС";
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
        public LightCar() : base()
        {
            this.body_type = "седан";
            this.power = 100;
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

        public Truck() : base()
        {
            this.payload = 3000;
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
                Console.WriteLine("Введите тип машины (Light, Truck): ");
                string answer2 = Console.ReadLine();
                if (answer1 == "y")
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
                        Console.WriteLine("Введите дату {0} техосмотра: ", j + 1);
                        int answer4 = Convert.ToInt32(Console.ReadLine());
                        to.Add(answer4);
                    }

                    if (answer2 == "Light")
                    {
                        Console.WriteLine("Введите тип кузова машины: ");
                        string body_type = Console.ReadLine();
                        Console.WriteLine("Введите мощность двигателя машины: ");
                        int power = Convert.ToInt32(Console.ReadLine());
                        lightcars.Add(new LightCar(name, age, to, number, body_type, power));
                    }
                    else if (answer2 == "Truck")
                    {
                        Console.WriteLine("Введите грузоподьемность машины: ");
                        int payload = Convert.ToInt32(Console.ReadLine());
                        trucks.Add(new Truck(name, age, to, number, payload));
                    }
                }
                else if (answer1 == "n")
                {
                    if (answer2 == "Light")
                    {
                        lightcars.Add(new LightCar());
                        Console.WriteLine("Создана легковая машина со стандартными параметрами");
                    }
                    else if (answer2 == "Truck")
                    {
                        trucks.Add(new Truck());
                        Console.WriteLine("Создана грузовая машина со стандартными параметрами");
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, выберите y/n");
                }
            }
            Console.WriteLine("Выборка по типу кузова, введите тип кузова: ");
            string need_body_type = Console.ReadLine();
            Console.WriteLine("Следующие машины имеют заданный тип кузова: ");
            Console.WriteLine("-------Начало списка-------");
            foreach (var car in lightcars)
            {
                if (car.body_type == need_body_type)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3} л.с. ({4})", car.name, car.age, car.number, car.power, car.body_type);
                }
            }
            Console.WriteLine("-------Конец списка-------");
            Console.WriteLine("Введите массу груза, который нужно перевезти: ");
            int need_payload = Convert.ToInt32(Console.ReadLine());
            trucks.Sort((truck1, truck2)=>truck1.payload.CompareTo(truck2.payload));
            trucks.Reverse();
            List<Truck> required_trucks = new List<Truck>();
            foreach(var truck in trucks)
            {
                if (need_payload <= 0)
                {
                    break;
                }
                required_trucks.Add(truck);
                need_payload -= truck.payload;
            }
            if (need_payload > 0)
            {
                Console.WriteLine("Перевезти груз невозможно с текущим автопарком");
            }
            else
            {
                Console.WriteLine("Необходимо задействовать следующие грузовые машины:");
                foreach (var truck in required_trucks)
                {
                    Console.WriteLine("{0}, {1}, {2} (грузоподъемность: {3}) ", truck.name, truck.age, truck.number, truck.payload);
                }
                Console.WriteLine("-------Конец списка-------");
            }
            
            Console.WriteLine("Введите номер машины: ");
            string need_number = Console.ReadLine();

            foreach(Truck truck in trucks)
            {
                if (truck.number == need_number)
                {
                    Console.WriteLine("Это грузовая машина");
                    break;
                }
            }
            foreach (LightCar car in lightcars)
            {
                if (car.number == need_number)
                {
                    Console.WriteLine("Это легковая машина");
                    break;
                }
            }
        }
    }
}  