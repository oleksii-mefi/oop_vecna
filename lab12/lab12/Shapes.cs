using System;

namespace lab11
{
    // 1. СТВОРЕННЯ ВЛАСНОГО ІНТЕРФЕЙСУ
    public interface IShapeInfo
    {
        string GetFullInfo();
    }

    // 2. ОНОВЛЕННЯ БАТЬКІВСЬКОГО КЛАСУ
    /// <summary>
    /// Базовий клас тепер реалізує наш інтерфейс, а також IComparable та ICloneable.
    /// </summary>
    public abstract class Чотирикутник : IShapeInfo, IComparable, ICloneable
    {
        // Реалізація з власного інтерфейсу IShapeInfo
        public virtual string GetFullInfo()
        {
            return $"Фігура: {this.GetType().Name}, Площа: {this.CalculateArea():F2}";
        }

        // Метод для обчислення площі (залишається абстрактним)
        public abstract double CalculateArea();

        // Реалізація стандартного інтерфейсу IComparable
        // Дозволяє порівнювати об'єкти (для сортування). Будемо порівнювати за площею.
        public int CompareTo(object obj)
        {
            // Перевірка, чи об'єкт не null і чи є він Чотирикутником
            if (obj is Чотирикутник otherShape)
            {
                // Порівнюємо площі. this.CalculateArea().CompareTo(...) - стандартний спосіб.
                return this.CalculateArea().CompareTo(otherShape.CalculateArea());
            }
            // Якщо не можемо порівняти, кидаємо виняток
            throw new ArgumentException("Об'єкт не є Чотирикутником і не може бути порівняний.");
        }

        // Реалізація стандартного інтерфейсу ICloneable
        // Кожен дочірній клас має надати свою реалізацію клонування.
        public abstract object Clone();
    }

    // 3. ОНОВЛЕННЯ ДОЧІРНІХ КЛАСІВ

    public class Паралелограм : Чотирикутник
    {
        public double BaseSide { get; protected set; }
        public double Height { get; protected set; }

        public Паралелограм(double baseSide, double height)
        {
            if (baseSide <= 0 || height <= 0)
                throw new ArgumentException("Основа та висота мають бути додатніми числами.");
            BaseSide = baseSide;
            Height = height;
        }

        public override double CalculateArea()
        {
            return BaseSide * Height;
        }

        // Реалізація клонування для Паралелограма
        public override object Clone()
        {
            return new Паралелограм(this.BaseSide, this.Height);
        }
    }

    public class Прямокутник : Паралелограм
    {
        public Прямокутник(double sideA, double sideB) : base(sideA, sideB) { }

        // Реалізація клонування для Прямокутника
        public override object Clone()
        {
            return new Прямокутник(this.BaseSide, this.Height);
        }
    }

    public class Ромб : Чотирикутник
    {
        public double Diagonal1 { get; protected set; }
        public double Diagonal2 { get; protected set; }

        public Ромб(double d1, double d2)
        {
            if (d1 <= 0 || d2 <= 0)
                throw new ArgumentException("Діагоналі мають бути додатніми числами.");
            Diagonal1 = d1;
            Diagonal2 = d2;
        }

        public override double CalculateArea()
        {
            return (Diagonal1 * Diagonal2) / 2.0;
        }

        // Реалізація клонування для Ромба
        public override object Clone()
        {
            return new Ромб(this.Diagonal1, this.Diagonal2);
        }
    }

    public class Квадрат : Прямокутник
    {
        public Квадрат(double side) : base(side, side) { }

        // Реалізація клонування для Квадрата
        public override object Clone()
        {
            // BaseSide успадковується від Паралелограма
            return new Квадрат(this.BaseSide);
        }
    }
}