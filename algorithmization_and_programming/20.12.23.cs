using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        class Item
        {
            public string name;
            public string unit_measurement;
            public int price;

            public Item(string name, string unit_measurement, int price)
            {
                this.name = name;
                this.unit_measurement = unit_measurement;
                this.price = price;
            }
        }

        class Product : Item
        {
            int expiration;
            int calories;
            int protein;
            int fats;
            int carbo;

            public Product(string name, string unit_measurement, int price, int expiration, int calories, int protein, int fats, int carbo)
                : base(name, unit_measurement, price)
            {
                this.expiration = expiration;
                this.calories = calories;
                this.protein = protein;
                this.fats = fats;
                this.carbo = carbo;
            }

            public string to_string()
            {
                return String.Format("Имя: {0}, Единица измерения: {1}, Цена: {2}, Калории: {3}, Белки: {4}, Жиры: {5}, Углеводы: {6}", this.name, this.unit_measurement, this.price, this.calories,
                                      this.protein, this.fats, this.carbo);
            }
        }

        class BuildMaterials : Item
        {
            string type;

            public BuildMaterials(string name, string unit_measurement, int price, string type)
                : base(name, unit_measurement, price)
            {
                this.type = type;
            }

            public string to_string()
            {
                return String.Format("Имя: {0}, Единица измерения: {1}, Цена: {2}, Вид материала: {3}", this.name, this.unit_measurement, this.price, this.type);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Количество продуктов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Product[] products = new Product[n];
            Console.WriteLine("Количество строительных материалов: ");
            int k = Convert.ToInt32(Console.ReadLine());
            BuildMaterials[] materials = new BuildMaterials[k];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите наименование продукта: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите единицу измерения продукта: ");
                string unit_measurement = Console.ReadLine();
                Console.WriteLine("Введите цену продукта: ");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите срок годности продукта: ");
                int expiration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите число калорий: ");
                int calories = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество белков: ");
                int protein = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество жиров: ");
                int fats = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество углеводов: ");
                int carbo = Convert.ToInt32(Console.ReadLine());
                products[i] = new Product(name, unit_measurement, price, expiration, calories, protein, fats, carbo);
                Console.WriteLine("Продукт создан!");
            }

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("Введите наименование материала: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите единицу измерения материала: ");
                string unit_measurement = Console.ReadLine();
                Console.WriteLine("Введите цену материала: ");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите тип материала: ");
                string type = Console.ReadLine();
                materials[i] = new BuildMaterials(name, unit_measurement, price, type);
                Console.WriteLine("Материал создан!");
            }
            Console.WriteLine("Список продуктов: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(products[i].to_string());
            }
            Console.WriteLine("Список материалов: ");
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(materials[i].to_string());
            }
            Console.ReadKey();
        }
    }
}