using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4CSharp
{
    public struct EmployeeStruct
    {
        public string FullName;
        public string Position;
        public int BirthYear;
        public decimal Salary;

        public override string ToString() => $"{FullName} | {Position} | {BirthYear} | {Salary}грн";
    }

    // --- ВАРІАНТ 2: ЗАПИС (Record) ---
    public record EmployeeRecord(string FullName, string Position, int BirthYear, decimal Salary);

    public static class Task3
    {
        public static void Execute()
        {
            Console.WriteLine("\n--- Завдання 3: Структури, Кортежі та Записи ---");

            List<EmployeeStruct> structList = new List<EmployeeStruct>
            {
                new EmployeeStruct { FullName = "Іваненко І.І.", Position = "Менеджер", BirthYear = 1990, Salary = 25000 },
                new EmployeeStruct { FullName = "Петренко П.П.", Position = "Розробник", BirthYear = 1995, Salary = 45000 }
            };

            // 2. ПРИКЛАД З КОРТЕЖАМИ (Tuples)
            var tupleList = new List<(string FullName, string Position, int BirthYear, decimal Salary)>
            {
                ("Сидоренко С.С.", "Дизайнер", 1992, 30000),
                ("Бацура Б.О.", "Інженер", 2004, 50000)
            };

            List<EmployeeRecord> recordList = new List<EmployeeRecord>
            {
                new EmployeeRecord("Коваленко К.К.", "Аналітик", 1988, 35000)
            };

            Console.WriteLine("\nПочатковий список (структури):");
            PrintList(structList);

            // Видалення за прізвищем
            string nameToDelete = "Іваненко І.І.";
            structList.RemoveAll(e => e.FullName == nameToDelete);
            Console.WriteLine($"\nПісля видалення '{nameToDelete}':");
            PrintList(structList);

            int indexAfter = 0; 
            var newEmp = new EmployeeStruct { FullName = "Новий Співробітник", Position = "Стажер", BirthYear = 2005, Salary = 15000 };
            
            if (indexAfter >= 0 && indexAfter < structList.Count)
                structList.Insert(indexAfter + 1, newEmp);

            Console.WriteLine($"\nПісля додавання стажера після елемента №{indexAfter}:");
            PrintList(structList);
        }

        static void PrintList<T>(IEnumerable<T> list)
        {
            int i = 0;
            foreach (var item in list)
                Console.WriteLine($"{i++}. {item}");
        }
    }
}
