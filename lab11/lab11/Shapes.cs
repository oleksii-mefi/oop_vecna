using System;

namespace lab11
{
    public abstract class Чотирикутник
    {
        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        public abstract double CalculateArea();
    }

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
    }

    public class Прямокутник : Паралелограм
    {
        public Прямокутник(double sideA, double sideB) : base(sideA, sideB)
        {
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
    }

    public class Квадрат : Прямокутник
    {
        public Квадрат(double side) : base(side, side)
        {
        }
    }
}