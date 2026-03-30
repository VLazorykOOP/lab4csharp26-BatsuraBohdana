using System;

namespace Lab4CSharp
{
    public class Triangle
    {
        protected int a, b, c;
        protected int color;

        public Triangle(int sideA, int sideB, int sideC, int triangleColor)
        {
            a = sideA; b = sideB; c = sideC;
            color = triangleColor;
        }

        // Індексатор (Завдання 1.1)
        public int this[int index]
        {
            get => index switch
            {
                0 => a, 1 => b, 2 => c, 3 => color,
                _ => throw new IndexOutOfRangeException("Невірний індекс! Дозволено 0-3.")
            };
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: color = value; break;
                    default: Console.WriteLine("Помилка: невірний індекс!"); break;
                }
            }
        }

        // Оператори ++ та -- (Завдання 1.2)
        public static Triangle operator ++(Triangle t) { t.a++; t.b++; t.c++; return t; }
        public static Triangle operator --(Triangle t) { t.a--; t.b--; t.c--; return t; }

        // Оператори true/false (Завдання 1.3)
        public static bool operator true(Triangle t) => (t.a + t.b > t.c) && (t.a + t.c > t.b) && (t.b + t.c > t.a);
        public static bool operator false(Triangle t) => !((t.a + t.b > t.c) && (t.a + t.c > t.b) && (t.b + t.c > t.a));

        // Оператор * на скаляр (Завдання 1.4)
        public static Triangle operator *(Triangle t, int scalar) => new Triangle(t.a * scalar, t.b * scalar, t.c * scalar, t.color);

        // Перетворення типів (Завдання 1.5)
        public static implicit operator string(Triangle t) => $"Triangle: a={t.a}, b={t.b}, c={t.c}, color={t.color}";
        public static explicit operator Triangle(string s)
        {
            var p = s.Split(',');
            return new Triangle(int.Parse(p[0]), int.Parse(p[1]), int.Parse(p[2]), int.Parse(p[3]));
        }
    }
}