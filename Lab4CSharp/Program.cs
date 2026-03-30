using System;
using System.Text;

namespace Lab4CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine(" 1. Завдання 1: Клас Triangle (Перевантаження та індексатори)");
                Console.WriteLine(" 2. Завдання 2: Клас VectorUInt (Вектори цілих чисел)");
                Console.WriteLine(" 3. Завдання 3: Співробітники (Структури, Кортежі, Записи)");
                Console.WriteLine(" 4. Завдання 4: Клас MatrixUint (Матриці цілих чисел)");
                Console.WriteLine(" 0. Вихід");
                Console.WriteLine("==========================================================");
                Console.Write("\n Оберіть номер завдання: ");

                string? choice = Console.ReadLine();

                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Task1.Execute();
                        break;
                    case "2":
                        Task2.Execute();
                        break;
                    case "3":
                        Task3.Execute();
                        break;
                    case "4":
                        Task4.Execute();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Програма завершена. Успіхів у навчанні!");
                        continue;
                    default:
                        Console.WriteLine("Помилка: невірний вибір. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine("\n----------------------------------------------------------");
                Console.WriteLine("Натисніть Enter, щоб повернутися до головного меню...");
                Console.ReadLine();
            }
        }
    }
}
