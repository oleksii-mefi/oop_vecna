using System;

namespace lab9
{
    public class DecimalCounter
    {
        // Приватне поле для зберігання поточного значення.
        // Це деталь реалізації, прихована від зовнішнього світу.
        private int _currentValue;
        public int CurrentValue
        {
            get { return _currentValue; }
            private set { _currentValue = value; }
        }

   
        public int MinValue { get; private set; }

        public int MaxValue { get; private set; }

      
        /// Конструктор за замовчуванням.
        /// Ініціалізує лічильник значенням 0 в діапазоні від 0 до 100.
       
        public DecimalCounter()
        {
            // Використовуємо приватні 'set'-ери для ініціалізації властивостей
            this.MinValue = 0;
            this.MaxValue = 100;
            this.CurrentValue = 0;
        }

        /// <summary>
        /// Конструктор для створення довільного лічильника.
        
        public DecimalCounter(int initialValue, int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Мінімальне значення не може бути більшим за максимальне.");
            }

            if (initialValue < minValue || initialValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(initialValue),
                    $"Початкове значення ({initialValue}) виходить за межі діапазону [{minValue}, {maxValue}].");
            }

            // Ініціалізуємо властивості через їхні приватні 'set'-ери
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.CurrentValue = initialValue;
        }

        
        /// Збільшує значення лічильника на одиницю.
       
        public void Increase()
        {
            if (CurrentValue >= MaxValue) // Читаємо значення через публічний 'get'
            {
                throw new InvalidOperationException($"Неможливо збільшити. Лічильник досяг максимального значення ({MaxValue}).");
            }
            CurrentValue++; // Змінюємо значення через приватний 'set'
        }

        
        /// Зменшує значення лічильника на одиницю.
        
        public void Decrease()
        {
            if (CurrentValue <= MinValue) // Читаємо значення через публічний 'get'
            {
                throw new InvalidOperationException($"Неможливо зменшити. Лічильник досяг мінімального значення ({MinValue}).");
            }
            CurrentValue--; // Змінюємо значення через приватний 'set'
        }

      
        /// Перевизначений метод для зручного відображення стану об'єкта у вигляді рядка.
        
        public override string ToString()
        {
            return $"Значення: {CurrentValue} (Діапазон: [{MinValue}, {MaxValue}])";
        }
    }
}