using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication18
{
    class Program
    {

        class Menu
        {
            public void show_menu()
            {
                Console.WriteLine(@"
            1. Создание БД
            2. Добавление в БД
            3. Изменение записи по номеру аудитории
            4. Выборка аудиторий с возможностью разместить заданное количество студентов
            5. Выборка аудиторий с наличием проектора
            6. Выборка аудиторий с наличием пк
            7. Выборка аудиторий, расположенных на заданном этаже
            8. Выход
            ");
            }

            public List<Auditorium> choose(string str, List<Auditorium> auditoriums)
            {
                if (str == "8")
                {
                    System.Environment.Exit('0');
                }
                if (auditoriums != null)
                {
                    switch (str)
                    {
                        case "2":
                            Auditorium.db_add(auditoriums);
                            break;
                        case "3":
                            Auditorium.db_change(auditoriums);
                            break;
                        case "4":
                            Auditorium.v_students(auditoriums);
                            break;
                        case "5":
                            Auditorium.v_projector(auditoriums);
                            break;
                        case "6":
                            Auditorium.v_pc(auditoriums);
                            break;
                        case "7":
                            Auditorium.v_floor(auditoriums);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Необходимо сначала создать БД");
                }
                show_menu();
                return auditoriums;
            }

            
        }


        class Auditorium
        {
            public int number;
            public int number_seats;
            public bool is_pc;
            public bool is_projector;

            public Auditorium(int number, int number_seats, bool is_pc, bool is_projector)
            {
                this.number = number;
                this.number_seats = number_seats;
                this.is_pc = is_pc;
                this.is_projector = is_projector;
            }
            public void get_info()
            {
                Console.WriteLine(@"Аудитория {0}, Количество мест: {1}, Есть пк: {2}, Есть проектор: {3}", number, number_seats, is_pc, is_projector);
            }
            public static List<Auditorium> db_create()
            {
                Console.WriteLine("База данных успешно создана");
                return new List<Auditorium>();
            }

            public static void db_add(List<Auditorium> auditoriums)
            {
                Console.WriteLine("Добавление новой аудитории");
                Auditorium new_auditorium = create_auditorium();
                new_auditorium.get_info();
                auditoriums.Add(new_auditorium);
            }

            public static void db_change(List<Auditorium> auditoriums)
            {
                Console.WriteLine("Введите номер аудитории:");
                int number = get_natural_number();
                for (int i = 0; i < auditoriums.Count; i++)
                {
                    if (auditoriums[i].number == number)
                    {
                        auditoriums[i].get_info();
                        change_auditorium(auditoriums[i]);
                        auditoriums[i].get_info();
                        return;
                    }
                }
                Console.WriteLine("Аудитория с нужным номером не найдена");
            }

            public static void v_students(List<Auditorium> auditoriums)
            {
                Console.WriteLine("Введите количество студентов: ");
                int number = get_natural_number();
                for (int i = 0; i < auditoriums.Count(); i++)
                {
                    if (auditoriums[i].number_seats >= number)
                    {
                        auditoriums[i].get_info();
                    }
                }
            }

            public static void v_projector(List<Auditorium> auditoriums)
            {
                
                for (int i = 0; i < auditoriums.Count(); i++)
                {
                    if (auditoriums[i].is_projector == true)
                    {
                        auditoriums[i].get_info();
                    }
                }
            }

            public static void v_pc(List<Auditorium> auditoriums)
            {

                for (int i = 0; i < auditoriums.Count(); i++)
                {
                    if (auditoriums[i].is_pc == true)
                    {
                        auditoriums[i].get_info();
                    }
                }
            }

            public static void v_floor(List<Auditorium> auditoriums)
            {
                Console.WriteLine("Введите этаж: ");
                int num = get_natural_number();
                for (int i = 0; i < auditoriums.Count(); i++)
                {
                    int floorNumber = Convert.ToString(auditoriums[i].number)[0] - '0';

                    if (floorNumber == num)
                    {
                        auditoriums[i].get_info();
                    }
                }
            }

            public static Auditorium create_auditorium()
            {
                Console.WriteLine("Ввведите номер:");
                int number = get_three_digit_number();

                Console.WriteLine("Ввведите количество мест:");
                int number_seats = get_natural_number();

                Console.WriteLine("В аудитории есть ПК? (да/нет)");
                bool is_pc = get_yes_no_bool();

                Console.WriteLine("В аудитории есть проектор? (да/нет)");
                bool is_projector = get_yes_no_bool();

                return new Auditorium(number, number_seats, is_pc, is_projector);
            }

            public static void change_auditorium(Auditorium auditorium)
            {
                Console.WriteLine("Ввведите количество мест:");
                auditorium.number_seats = get_natural_number();

                Console.WriteLine("В аудитории есть ПК? (да/нет)");
                auditorium.is_pc = get_yes_no_bool();

                Console.WriteLine("В аудитории есть проектор? (да/нет)");
                auditorium.is_projector = get_yes_no_bool();
            }

            static int get_three_digit_number()
            {
                int number = 0;
                while (true)
                {
                    number = get_natural_number();
                    if (number >= 100 && number < 1000)
                    {
                        break;
                    }
                    Console.WriteLine("Число должно быть трехзначным");
                }

                return number;
            }

            static int get_natural_number()
            {
                bool isNumeric = false;
                int number = -1;
                while (true)
                {
                    isNumeric = int.TryParse(Console.ReadLine(), out number);
                    if (isNumeric && number > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Число должно быть натуральным");
                }
                return number;
            }

            static bool get_yes_no_bool()
            {
                string str_yes_no;
                bool is_bool = false;
                while (true)
                {
                    str_yes_no = Console.ReadLine();
                    if (str_yes_no == "да")
                    {
                        is_bool = true;
                        break;
                    }

                    else if (str_yes_no == "нет")
                    {
                        is_bool = false;
                        break;
                    }
                }
                return is_bool;
            }
        }
        
        static void Main()
        {
            Menu menu = new Menu();
            menu.show_menu();

            List<Auditorium> auditoriums = null;

            while (true)
            {
                string choose = Console.ReadLine();
                if (choose == "1")
                {
                    auditoriums = Auditorium.db_create();
                }
                if (auditoriums != null)
                {
                    auditoriums = menu.choose(choose, auditoriums);
                }
                else
                {
                    Console.WriteLine("Нужно создать БД");
                }                
            }
        }
    }
}