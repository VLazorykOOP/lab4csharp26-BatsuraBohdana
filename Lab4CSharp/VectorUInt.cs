using System;

namespace Lab4CSharp
{
    public class VectorUInt
    {
        // Поля
        protected uint[] IntArray;
        protected uint size;
        protected int codeError;
        private static uint num_vec = 0; // Кількість створених об'єктів

        // Конструктори
        public VectorUInt()
        {
            size = 1;
            IntArray = new uint[size];
            IntArray[0] = 0;
            num_vec++;
        }

        public VectorUInt(uint s)
        {
            size = s;
            IntArray = new uint[size];
            for (int i = 0; i < size; i++) IntArray[i] = 0;
            num_vec++;
        }

        public VectorUInt(uint s, uint initValue)
        {
            size = s;
            IntArray = new uint[size];
            for (int i = 0; i < size; i++) IntArray[i] = initValue;
            num_vec++;
        }

        // Деструктор
        ~VectorUInt()
        {
            Console.WriteLine("Об'єкт VectorUInt видалено з пам'яті.");
        }

        // Методи
        public void Input()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                if (!uint.TryParse(Console.ReadLine(), out IntArray[i])) IntArray[i] = 0;
            }
        }

        public void Display()
        {
            Console.WriteLine("Вектор: " + string.Join(", ", IntArray));
        }

        public void AssignValue(uint val)
        {
            for (int i = 0; i < size; i++) IntArray[i] = val;
        }

        public static uint GetNumVec() => num_vec;

        // Властивості
        public uint Size => size;
        public int CodeError { get => codeError; set => codeError = value; }

        // Індексатор
        public uint this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    codeError = -1;
                    return 0;
                }
                return IntArray[index];
            }
            set
            {
                if (index < 0 || index >= size) codeError = -1;
                else IntArray[index] = value;
            }
        }

        // --- ПЕРЕВАНТАЖЕННЯ ---

        // Унарні ++ та --
        public static VectorUInt operator ++(VectorUInt v)
        {
            for (int i = 0; i < v.size; i++) v.IntArray[i]++;
            return v;
        }

        public static VectorUInt operator --(VectorUInt v)
        {
            for (int i = 0; i < v.size; i++) v.IntArray[i]--;
            return v;
        }

        // Сталі true/false
        public static bool operator true(VectorUInt v)
        {
            if (v.size == 0) return false;
            foreach (var x in v.IntArray) if (x != 0) return true;
            return false;
        }
        public static bool operator false(VectorUInt v) => !(v ? true : false);

        // Логічне !
        public static bool operator !(VectorUInt v) => v.size != 0;

        // Побітове ~
        public static VectorUInt operator ~(VectorUInt v)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (int i = 0; i < v.size; i++) res.IntArray[i] = ~v.IntArray[i];
            return res;
        }

        // Бінарний + (Приклад для всіх арифметичних)
        public static VectorUInt operator +(VectorUInt v1, VectorUInt v2)
        {
            uint maxS = Math.Max(v1.size, v2.size);
            uint minS = Math.Min(v1.size, v2.size);
            VectorUInt res = new VectorUInt(maxS);
            
            // Копіюємо дані з більшого
            VectorUInt longer = v1.size >= v2.size ? v1 : v2;
            for (int i = 0; i < maxS; i++) res.IntArray[i] = longer.IntArray[i];

            // Додаємо спільні елементи
            for (int i = 0; i < minS; i++) res.IntArray[i] = v1.IntArray[i] + v2.IntArray[i];
            return res;
        }

        public static VectorUInt operator +(VectorUInt v, uint scalar)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (int i = 0; i < v.size; i++) res.IntArray[i] = v.IntArray[i] + scalar;
            return res;
        }

        // Бінарний *
        public static VectorUInt operator *(VectorUInt v1, VectorUInt v2)
        {
            uint minS = Math.Min(v1.size, v2.size);
            VectorUInt res = new VectorUInt(Math.Max(v1.size, v2.size));
            VectorUInt longer = v1.size >= v2.size ? v1 : v2;
            for (int i = 0; i < res.size; i++) res.IntArray[i] = longer.IntArray[i];
            for (int i = 0; i < minS; i++) res.IntArray[i] = v1.IntArray[i] * v2.IntArray[i];
            return res;
        }

        // Порівняння == (Повертає true, якщо кожна пара однакова)
        public static bool operator ==(VectorUInt v1, VectorUInt v2)
        {
            if (v1.size != v2.size) return false;
            for (int i = 0; i < v1.size; i++) if (v1.IntArray[i] != v2.IntArray[i]) return false;
            return true;
        }
        public static bool operator !=(VectorUInt v1, VectorUInt v2) => !(v1 == v2);

        // Оператор >
        public static bool operator >(VectorUInt v1, VectorUInt v2)
        {
            if (v1.size != v2.size) return false;
            for (int i = 0; i < v1.size; i++) if (!(v1.IntArray[i] > v2.IntArray[i])) return false;
            return true;
        }
        public static bool operator <(VectorUInt v1, VectorUInt v2)
        {
            if (v1.size != v2.size) return false;
            for (int i = 0; i < v1.size; i++) if (!(v1.IntArray[i] < v2.IntArray[i])) return false;
            return true;
        }

        // Потрібно перевизначити для коректності
        public override bool Equals(object obj) => obj is VectorUInt v && this == v;
        public override int GetHashCode() => IntArray.GetHashCode();
    }
}