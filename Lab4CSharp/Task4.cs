using System;

namespace Lab4CSharp
{
    public static class Task4
    {
        public static void Execute()
        {
            Console.WriteLine("\n--- Завдання 4: Тестування MatrixUint ---");

            MatrixUint m1 = new MatrixUint(2, 2, 5);
            MatrixUint m2 = new MatrixUint(2, 2, 2);

            Console.WriteLine("Матриця M1:");
            m1.Display();

            Console.WriteLine("\nМатриця M2:");
            m2.Display();

            MatrixUint mSum = m1 + m2;
            Console.WriteLine("\nРезультат M1 + M2:");
            mSum.Display();

            MatrixUint mMult = m1 * m2;
            Console.WriteLine("\nРезультат M1 * M2 (множення матриць):");
            mMult.Display();

            Console.WriteLine($"\nКількість створених матриць: {MatrixUint.GetNumMatrix()}");
            
            Console.WriteLine($"\nЗвернення до M1 через індекс k=2 (i=1, j=0): {m1[2]}");
            
            m1[5, 5] = 100; 
            Console.WriteLine($"CodeError після виходу за межі: {m1.CodeError}");
        }
    }
}
