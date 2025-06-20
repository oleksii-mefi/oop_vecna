using System;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        // Один об'єкт лічильника, з яким ми працюємо.
        // Початково він null, тобто лічильник ще не створено.
        private DecimalCounter counter;

        public Form1()
        {
            InitializeComponent();
            UpdateUI(); // Оновити інтерфейс при запуску
        }
       
        /// Метод для оновлення стану елементів керування на формі.
        private void UpdateUI()
        {
            if (counter == null)
            {
                // Якщо лічильник не створено
                lblCounterState.Text = "Лічильник не створено";
                button1.Enabled = false; // "зменшити"
                button2.Enabled = false; // "збільшити"
            }
            else
            {
                // Якщо лічильник існує, показуємо його стан
                lblCounterState.Text = counter.ToString();
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        // Обробник кнопки "Створити за замовчуванням"
        private void btnCreateDefault_Click(object sender, EventArgs e)
        {
            // Просто створюємо об'єкт за допомогою конструктора за замовчуванням
            counter = new DecimalCounter();
            MessageBox.Show("Створено лічильник за замовчуванням.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateUI(); // Оновлюємо інтерфейс, щоб показати новий стан
        }

        // Обробник кнопки "Створити довільний"
        private void btnCreateCustom_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитуємо дані з текстових полів
                int initial = int.Parse(txtInitialValue.Text);
                int min = int.Parse(txtMinValue.Text);
                int max = int.Parse(txtMaxValue.Text);

                // Створюємо лічильник з цими параметрами
                counter = new DecimalCounter(initial, min, max);
                MessageBox.Show("Довільний лічильник успішно створено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Обробка помилок створення лічильника (неправильний діапазон, значення поза діапазоном)
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка вхідних даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
                counter = null; // Якщо створення не вдалося, лічильник залишається неініціалізованим
            }
            // Обробка помилок введення (якщо ввели не число)
            catch (FormatException)
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення у всі поля.", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                counter = null;
            }

            UpdateUI(); // Оновлюємо інтерфейс
        }

        // Обробник кнопки "Збільшити" (у вас це button2)
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                counter?.Increase(); // Знак '?' перевіряє, чи counter не null
                UpdateUI();
            }
            catch (InvalidOperationException ex)
            {
                // Ловимо виключення, якщо досягнуто межі діапазону
                MessageBox.Show(ex.Message, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Обробник кнопки "Зменшити" (у вас це button1)
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                counter?.Decrease();
                UpdateUI();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}