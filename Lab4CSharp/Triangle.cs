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

        public static Triangle operator ++(Triangle t) { t.a++; t.b++; t.c++; return t; }
        public static Triangle operator --(Triangle t) { t.a--; t.b--; t.c--; return t; }

        public static bool operator true(Triangle t) => (t.a + t.b > t.c) && (t.a + t.c > t.b) && (t.b + t.c > t.a);
        public static bool operator false(Triangle t) => !((t.a + t.b > t.c) && (t.a + t.c > t.b) && (t.b + t.c > t.a));

        public static Triangle operator *(Triangle t, int scalar) => new Triangle(t.a * scalar, t.b * scalar, t.c * scalar, t.color);

        public static implicit operator string(Triangle t) => $"Triangle: a={t.a}, b={t.b}, c={t.c}, color={t.color}";
        public static explicit operator Triangle(string s)
        {
            var p = s.Split(',');
            return new Triangle(int.Parse(p[0]), int.Parse(p[1]), int.Parse(p[2]), int.Parse(p[3]));
        }
    }
}
