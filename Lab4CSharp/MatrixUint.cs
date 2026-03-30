using System;

namespace Lab4CSharp
{
    public class MatrixUint
    {
        // Поля
        protected uint[,] IntArray;
        protected int n, m;
        protected int codeError;
        private static int num_m = 0;

        // Конструктори
        public MatrixUint()
        {
            n = 1; m = 1;
            IntArray = new uint[n, m];
            IntArray[0, 0] = 0;
            num_m++;
        }

        public MatrixUint(int row, int col)
        {
            n = row; m = col;
            IntArray = new uint[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++) IntArray[i, j] = 0;
            num_m++;
        }

        public MatrixUint(int row, int col, uint initValue)
        {
            n = row; m = col;
            IntArray = new uint[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++) IntArray[i, j] = initValue;
            num_m++;
        }

        // Деструктор
        ~MatrixUint()
        {
            Console.WriteLine("Об'єкт MatrixUint видалено з пам'яті.");
        }

        // Методи
        public void Input()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"M[{i},{j}]: ");
                    if (!uint.TryParse(Console.ReadLine(), out IntArray[i, j])) IntArray[i, j] = 0;
                }
        }

        public void Display()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) Console.Write($"{IntArray[i, j], 5}");
                Console.WriteLine();
            }
        }

        public void AssignValue(uint val)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++) IntArray[i, j] = val;
        }

        public static int GetNumMatrix() => num_m;

        // Властивості
        public int Rows => n;
        public int Cols => m;
        public int CodeError { get => codeError; set => codeError = value; }

        // Індексатор з двома індексами [i, j]
        public uint this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= n || j < 0 || j >= m) { codeError = -1; return 0; }
                return IntArray[i, j];
            }
            set
            {
                if (i < 0 || i >= n || j < 0 || j >= m) codeError = -1;
                else IntArray[i, j] = value;
            }
        }

        // Індексатор з одним індексом [k] (k = i * m + j)
        public uint this[int k]
        {
            get
            {
                int i = k / m;
                int j = k % m;
                if (i < 0 || i >= n || j < 0 || j >= m) { codeError = -1; return 0; }
                return IntArray[i, j];
            }
            set
            {
                int i = k / m;
                int j = k % m;
                if (i < 0 || i >= n || j < 0 || j >= m) codeError = -1;
                else IntArray[i, j] = value;
            }
        }

        // --- Перевантаження операторів ---

        public static MatrixUint operator ++(MatrixUint mat)
        {
            for (int i = 0; i < mat.n; i++)
                for (int j = 0; j < mat.m; j++) mat.IntArray[i, j]++;
            return mat;
        }

        public static MatrixUint operator --(MatrixUint mat)
        {
            for (int i = 0; i < mat.n; i++)
                for (int j = 0; j < mat.m; j++) mat.IntArray[i, j]--;
            return mat;
        }

        public static bool operator true(MatrixUint mat)
        {
            if (mat.n == 0 || mat.m == 0) return false;
            foreach (var x in mat.IntArray) if (x != 0) return true;
            return false;
        }
        public static bool operator false(MatrixUint mat) => !(mat ? true : false);

        public static bool operator !(MatrixUint mat) => mat.n != 0 && mat.m != 0;

        public static MatrixUint operator +(MatrixUint m1, MatrixUint m2)
        {
            if (m1.n != m2.n || m1.m != m2.m) return m1;
            MatrixUint res = new MatrixUint(m1.n, m1.m);
            for (int i = 0; i < m1.n; i++)
                for (int j = 0; j < m1.m; j++) res[i, j] = m1[i, j] + m2[i, j];
            return res;
        }

        public static MatrixUint operator +(MatrixUint mat, uint scalar)
        {
            MatrixUint res = new MatrixUint(mat.n, mat.m);
            for (int i = 0; i < mat.n; i++)
                for (int j = 0; j < mat.m; j++) res[i, j] = mat[i, j] + scalar;
            return res;
        }

        // Множення матриць (Завдання 4.2.c.i)
        public static MatrixUint operator *(MatrixUint m1, MatrixUint m2)
        {
            if (m1.m != m2.n) return m1;
            MatrixUint res = new MatrixUint(m1.n, m2.m);
            for (int i = 0; i < m1.n; i++)
                for (int j = 0; j < m2.m; j++)
                    for (int k = 0; k < m1.m; k++)
                        res[i, j] += m1[i, k] * m2[k, j];
            return res;
        }

        public static bool operator ==(MatrixUint m1, MatrixUint m2)
        {
            if (m1.n != m2.n || m1.m != m2.m) return false;
            for (int i = 0; i < m1.n; i++)
                for (int j = 0; j < m1.m; j++)
                    if (m1[i, j] != m2[i, j]) return false;
            return true;
        }

        public static bool operator !=(MatrixUint m1, MatrixUint m2) => !(m1 == m2);

        public override bool Equals(object obj) => obj is MatrixUint mat && this == mat;
        public override int GetHashCode() => IntArray.GetHashCode();
    }
}