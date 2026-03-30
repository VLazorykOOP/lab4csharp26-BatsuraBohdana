using System;

namespace Lab4CSharp
{
    public static class Task2
    {
        public static void Execute()
        {
            Console.WriteLine("\n--- Завдання 2: Тестування VectorUInt ---");

            VectorUInt v1 = new VectorUInt(3, 10);
            VectorUInt v2 = new VectorUInt(3, 5);

            Console.Write("V1: "); v1.Display();
            Console.Write("V2: "); v2.Display();

            VectorUInt vSum = v1 + v2;
            Console.Write("V1 + V2: "); vSum.Display();

            VectorUInt vScalar = v1 + 100u;
            Console.Write("V1 + 100: "); vScalar.Display();

            v1++;
            Console.Write("V1 після ++: "); v1.Display();

            Console.WriteLine($"Кількість створених векторів: {VectorUInt.GetNumVec()}");
            
            Console.WriteLine("Перевірка індексатора V1[1]: " + v1[1]);
            v1[10] = 5; // Помилка індексу
            Console.WriteLine("CodeError після невірного індексу: " + v1.CodeError);
        }
    }
}