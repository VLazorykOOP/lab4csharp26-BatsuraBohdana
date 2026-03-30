using System;

namespace Lab4CSharp
{
    public static class Task1
    {
        public static void Execute()
        {
            Console.WriteLine("--- Завдання 1: Перевантаження Triangle ---");
            Triangle t = new Triangle(3, 4, 5, 1);
            Console.WriteLine($"Початковий: {(string)t}");
            
            t++; Console.WriteLine($"Після ++: {(string)t}");
            t = t * 2; Console.WriteLine($"Після * 2: {(string)t}");
            
            Console.WriteLine($"Сторона b через індексатор [1]: {t[1]}");
            
            if (t) Console.WriteLine("Трикутник існує.");
        }
    }
}