using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class Car
    {
        public string name;
        public int date_birth;
        public string color;
        public List <string> owners;
        public List <int> dates_to;
        public Car()
        {
            this.name = "ВАЗ 2107";
            this.date_birth = 2000;
            this.color = "Белый";
            this.owners = new List<string>();
            this.owners.Add("Серега Кириешкин");
            this.dates_to = new List<int>();
            this.dates_to.Add(2000);
        }
        public Car(string name, int date_birth, string color, List <string> owners, List <int> dates_to)
        {
            this.name = name;
            this.date_birth = date_birth;
            this.color = color;
            this.owners = owners;
            this.dates_to = dates_to;
        }
        public bool completed_to(int req_date) 
        {
            foreach(var date in this.dates_to) {
                if (date == req_date) return true;
            }
            return false;
        }
        public string last_owner()
        {
            if (this.owners.Count() > 0)
            {
                return this.owners[this.owners.Count() - 1];
            }
            else
            {
                return "Нет владельцев";
            }
            
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество машин: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Car[] cars = new Car[n];
            for (int i = 0; i < n; i++)
            {
                string ch = "";
                Console.WriteLine("Задать параметры машины {0}? (y/n)", i + 1);
                while (ch != "y" && ch != "n")
                {
                    ch = Console.ReadLine();
                    if (ch == "y")
                    {
                        Console.WriteLine("Название машины: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Год выпуска машины: ");
                        int date_birth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите цвет машины: ");
                        string color = Console.ReadLine();
                        List<string> owners = new List<string>();
                        Console.WriteLine("Введите количество владельцев");
                        int owners_count = Convert.ToInt32(Console.ReadLine());
                        for (int o = 0; o < owners_count; o++)
                        {
                            Console.WriteLine("Введите имя владельца");
                            owners.Add(Console.ReadLine());
                        }
                        List<int> dates = new List<int>();
                        Console.WriteLine("Введите количество пройденных тех осмотров");
                        int dates_count = Convert.ToInt32(Console.ReadLine());
                        for (int d = 0; d < dates_count; d++)
                        {
                            Console.WriteLine("Введите дату прохождения тех осмотра");
                            dates.Add(Convert.ToInt32(Console.ReadLine()));
                        }
                        cars[i] = new Car(name, date_birth, color, owners, dates);
                        Console.WriteLine("Создана машина с заданными параметрами");
                    }
                    if (ch == "n")
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
            Console.WriteLine("Выборка машин по году выпуска, введите год");
            int need_birth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Следующие машины выпущены в {0} году", need_birth);
            Console.WriteLine("-----Начало списка-------");
            for (int i = 0; i < n; i++)
            {
                if (cars[i].date_birth == need_birth)
                {
                    Car car = cars[i];
                    Console.WriteLine("Машина {0}, {1}, {2} года выпуска", i + 1, car.name, car.date_birth);
                }
            }
            Console.WriteLine("-----Конец списка-------");

            Console.WriteLine("Выборка машин по году прохождения тех осмотра, введите год прохождения тех осмотра");
            int date = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Следующие машины проходили тех осмотр в {0} году", date);
            Console.WriteLine("-----Начало списка-------");
            for (int i = 0; i < n; i++)
            {
                if (cars[i].completed_to(date))
                {
                    Car car= cars[i];
                    Console.WriteLine("Машина {0}, {1}, {2} года выпуска", i + 1, car.name, car.date_birth);
                }
            }
            Console.WriteLine("-----Конец списка-------");

            Console.WriteLine("Последний владелец каждой машины");
            Console.WriteLine("-----Начало списка-------");
            for (int i = 0; i < n; i++)
            {
                Car car = cars[i];
                Console.WriteLine("Машина {0}, {1}, {2} года выпуска. Последний владелец: {3}", i + 1, car.name, car.date_birth, car.last_owner());
            }
            Console.WriteLine("-----Конец списка-------");
            Console.ReadKey();
        }
    }
}
