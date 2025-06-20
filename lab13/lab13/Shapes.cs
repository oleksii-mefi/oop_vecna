using System;
using System.Collections;
using System.Collections.Generic;

// УВАГА: Простір імен оновлено на lab13
namespace lab13
{
    // Інтерфейс
    public interface IShapeInfo
    {
        string GetFullInfo();
    }

    // Базовий клас
    public abstract class Чотирикутник : IShapeInfo, IComparable, ICloneable
    {
        public virtual string GetFullInfo()
        {
            return $"Фігура: {this.GetType().Name,-15} Площа: {this.CalculateArea():F2}";
        }
        public abstract double CalculateArea();
        public int CompareTo(object obj)
        {
            if (obj is Чотирикутник otherShape)
            {
                return this.CalculateArea().CompareTo(otherShape.CalculateArea());
            }
            throw new ArgumentException("Об'єкт не є Чотирикутником і не може бути порівняний.");
        }
        public abstract object Clone();
    }

    // Дочірні класи
    public class Паралелограм : Чотирикутник
    {
        public double BaseSide { get; protected set; }
        public double Height { get; protected set; }
        public Паралелограм(double baseSide, double height)
        {
            if (baseSide <= 0 || height <= 0) throw new ArgumentException("Основа та висота мають бути додатніми числами.");
            BaseSide = baseSide;
            Height = height;
        }
        public override double CalculateArea() { return BaseSide * Height; }
        public override object Clone() { return new Паралелограм(this.BaseSide, this.Height); }
    }

    public class Прямокутник : Паралелограм
    {
        public Прямокутник(double sideA, double sideB) : base(sideA, sideB) { }
        public override object Clone() { return new Прямокутник(this.BaseSide, this.Height); }
    }

    public class Ромб : Чотирикутник
    {
        public double Diagonal1 { get; protected set; }
        public double Diagonal2 { get; protected set; }
        public Ромб(double d1, double d2)
        {
            if (d1 <= 0 || d2 <= 0) throw new ArgumentException("Діагоналі мають бути додатніми числами.");
            Diagonal1 = d1;
            Diagonal2 = d2;
        }
        public override double CalculateArea() { return (Diagonal1 * Diagonal2) / 2.0; }
        public override object Clone() { return new Ромб(this.Diagonal1, this.Diagonal2); }
    }

    public class Квадрат : Прямокутник
    {
        public Квадрат(double side) : base(side, side) { }
        public override object Clone() { return new Квадрат(this.BaseSide); }
    }

    // Клас-колекція для завдання 13
    public class QuadCollection
    {
        private Stack _nonGenericStack;
        private Stack<Чотирикутник> _genericStack;

        public QuadCollection()
        {
            _nonGenericStack = new Stack();
            _genericStack = new Stack<Чотирикутник>();
        }

        public void AddShape(Чотирикутник shape)
        {
            if (shape == null) return;
            _nonGenericStack.Push(shape);
            _genericStack.Push(shape);
        }

        public List<string> GetNonGenericStackInfo()
        {
            var infoList = new List<string>();
            foreach (object item in _nonGenericStack)
            {
                if (item is Чотирикутник shape) { infoList.Add(shape.GetFullInfo()); }
            }
            return infoList;
        }

        public List<string> GetGenericStackInfo()
        {
            var infoList = new List<string>();
            foreach (Чотирикутник shape in _genericStack)
            {
                infoList.Add(shape.GetFullInfo());
            }
            return infoList;
        }

        public string PeekTopElementInfo()
        {
            if (_genericStack.Count > 0)
            {
                Чотирикутник topShape = _genericStack.Peek();
                return topShape.GetFullInfo();
            }
            return "Стек порожній.";
        }
    }
}