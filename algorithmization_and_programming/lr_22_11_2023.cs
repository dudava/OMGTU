namespace ConsoleApplication8
{
    using System;

    class Student
    {
        string name;
        int birth_date;
        string group;

        public Student()
        {
            this.name = "Иван Иванов";
            this.birth_date = 2005;
            this.group = "ФИТ-231";
        }

        public Student(string name, int birth_date, string group)
        {
            this.name = name;
            this.birth_date = birth_date;
            this.group = group;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Birth
        {
            get { return this.birth_date; }
            set { this.birth_date = value; }
        }
        public string Group
        {
            get { return this.group; }
            set { this.group = value; }
        }
    }

    class HelloWorld
    {
        static void Main()
        {
            Console.Write("Количество студентов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Student[] students = new Student[n];

            for (int i = 0; i < n; i++)
            {
                string ch = "";
                Console.WriteLine("Задать параметры студента {0}? y/n", i + 1);
                while (ch != "y" && ch != "n")
                {
                    ch = Console.ReadLine();
                    if (ch == "y")
                    {
                        Console.Write("Имя студента: ");
                        string new_name = Console.ReadLine();
                        Console.Write("Год рождения студента: ");
                        int new_date = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Название группы студента: ");
                        string new_group = Console.ReadLine();
                        students[i] = new Student(new_name, new_date, new_group);
                        Console.WriteLine("Студент создан");
                    }
                    else if (ch == "n")
                    {
                        students[i] = new Student();
                        Console.WriteLine("Создан студент со стандартными параметрами");
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, выберите y/n");
                    }
                }
                
            }

            Console.WriteLine("Выборка студентов по году рождения, введите год");
            int need_birth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Следующие студенты родились в {0} году", need_birth);
            Console.WriteLine("-----Начало списка-------");
            for (int i = 0; i < n; i++)
            {
                if (students[i].Birth == need_birth)
                {
                    Student student = students[i];
                    Console.WriteLine("Студент {0}, {1}, {2} года рождения, {3}", i + 1, student.Name, student.Birth, student.Group);
                }
            }
            Console.WriteLine("-----Конец списка-------");

            Console.WriteLine("Выборка студентов по группе, введите название группы");
            string need_group = Console.ReadLine();
            Console.WriteLine("Следующие студенты принадлежат группе {0}", need_group);
            Console.WriteLine("-----Начало списка-------");
            for (int i = 0; i < n; i++)
            {
                if (students[i].Group == need_group)
                {
                    Student student = students[i];
                    Console.WriteLine("Студент {0}, {1}, {2} года рождения, {3}", i + 1, student.Name, student.Birth, student.Group);
                }
            }
            Console.WriteLine("-----Конец списка-------");
        }
    }
}