using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Employee
    {
        public int id;
        public string name;
        public List<Employee> soldiers;

        public Employee(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.soldiers = new List<Employee>();
        }

        public Employee(int id)
        {
            this.id = id;
            this.name = "Unknown Name";
            this.soldiers = new List<Employee>();
        }

        public static bool check_id(int id, List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee.id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static Employee get_by_id(int id, List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee.id == id)
                {
                    return employee;
                }
            }
            return null;
        }

        public static Employee get_by_name(string name, List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee.name == name)
                {
                    return employee;
                }
            }
            return null;
        }



        public void get_info()
        {
            Console.WriteLine("{0} {1}", id, name);
        }

        public static List<Employee> get_soldiers(Employee employee, List<Employee> soldiers)
        {
            foreach (var soldier in employee.soldiers)
            {
                soldiers.Add(soldier);
                get_soldiers(soldier, soldiers);
            }
            soldiers.Sort((s1, s2) => s1.id.CompareTo(s2.id));
            return soldiers;
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            List<Employee> employes = new List<Employee>();
            int count = 0;
            Employee boss = new Employee(0);
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                int id = int.Parse(input.Substring(0, 4));
                string name = "";
                if (input.Length > 5)
                {
                    name = input.Substring(5, input.Length - 5);
                }
                Employee employee;
                if (!Employee.check_id(id, employes))
                {
                    if (name != "")
                    {
                        employee = new Employee(id, name);
                    }
                    else
                    {
                        employee = new Employee(id);
                    }
                    employes.Add(employee);
                }
                else
                {
                    employee = Employee.get_by_id(id, employes);
                }
                if (name != "" && employee.name == "Unknown Name")
                {
                    employee.name = name;
                }

                if (count % 2 == 0)
                {
                    boss = employee;
                }
                else
                {
                    boss.soldiers.Add(employee);
                }
                count++;
            }
            Employee req_boss;
            string req_input = Console.ReadLine();
            int req_id;
            bool is_numeric = int.TryParse(req_input, out req_id);
            if (is_numeric)
            {
                req_boss = Employee.get_by_id(req_id, employes);
            }
            else
            {
                req_boss = Employee.get_by_name(req_input, employes);
            }

            List<Employee> soldiers = Employee.get_soldiers(req_boss, new List<Employee>());
            foreach (var soldier in soldiers)
            {
                soldier.get_info();
            }
            Console.ReadLine();
        }
    }
}
