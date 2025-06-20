using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateShapesComboBox();
        }

        #region Код для обчислення однієї фігури (залишається без змін)

        private void PopulateShapesComboBox()
        {
            comboBoxShapes.Items.Add("Паралелограм");
            comboBoxShapes.Items.Add("Прямокутник");
            comboBoxShapes.Items.Add("Ромб");
            comboBoxShapes.Items.Add("Квадрат");
            comboBoxShapes.SelectedIndex = 0;
        }

        private void comboBoxShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShapes.SelectedItem != null)
            {
                UpdateInputFields(comboBoxShapes.SelectedItem.ToString());
            }
        }

        private void UpdateInputFields(string shapeName)
        {
            textBox1.Clear();
            textBox2.Clear();
            labelResult.Text = "Результат:";

            switch (shapeName)
            {
                case "Паралелограм":
                    label1.Text = "Основа:";
                    label2.Text = "Висота:";
                    label1.Visible = true;
                    textBox1.Visible = true;
                    label2.Visible = true;
                    textBox2.Visible = true;
                    break;
                case "Прямокутник":
                    label1.Text = "Сторона A:";
                    label2.Text = "Сторона B:";
                    label1.Visible = true;
                    textBox1.Visible = true;
                    label2.Visible = true;
                    textBox2.Visible = true;
                    break;
                case "Ромб":
                    label1.Text = "Діагональ 1:";
                    label2.Text = "Діагональ 2:";
                    label1.Visible = true;
                    textBox1.Visible = true;
                    label2.Visible = true;
                    textBox2.Visible = true;
                    break;
                case "Квадрат":
                    label1.Text = "Сторона:";
                    label1.Visible = true;
                    textBox1.Visible = true;
                    label2.Visible = false;
                    textBox2.Visible = false;
                    break;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (comboBoxShapes.SelectedItem == null) return;

            string selectedShape = comboBoxShapes.SelectedItem.ToString();
            Чотирикутник shape = null;

            try
            {
                double val1 = double.Parse(textBox1.Text);
                double val2 = textBox2.Visible ? double.Parse(textBox2.Text) : 0;

                switch (selectedShape)
                {
                    case "Паралелограм":
                        shape = new Паралелограм(val1, val2);
                        break;
                    case "Прямокутник":
                        shape = new Прямокутник(val1, val2);
                        break;
                    case "Ромб":
                        shape = new Ромб(val1, val2);
                        break;
                    case "Квадрат":
                        shape = new Квадрат(val1);
                        break;
                }

                if (shape != null)
                {
                    labelResult.Text = shape.GetFullInfo();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Помилка даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася невідома помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region НОВИЙ КОД: Демонстрація роботи з масивом
        private void btnArrayDemo_Click(object sender, EventArgs e)
        {
            // Очищуємо поле виводу перед демонстрацією
            listBoxResults.Items.Clear();

            try
            {
                // Створюємо список, щоб легко додати першу половину
                List<Чотирикутник> shapesList = new List<Чотирикутник>
                {
                    new Квадрат(5),       // Площа = 25
                    new Ромб(10, 8),      // Площа = 40
                    new Прямокутник(4, 6) // Площа = 24
                };

                // Створюємо масив, розмір якого вдвічі більший за початковий список
                Чотирикутник[] shapeArray = new Чотирикутник[shapesList.Count * 2];
                // Копіюємо першу половину в масив
                shapesList.CopyTo(shapeArray, 0);

                // Заповнюємо другу половину масиву КЛОНАМИ першої
                for (int i = 0; i < shapesList.Count; i++)
                {
                    // Використовуємо метод Clone() і приводимо тип до Чотирикутника
                    shapeArray[i + shapesList.Count] = (Чотирикутник)shapeArray[i].Clone();
                }

                // Виводимо початковий стан масиву
                listBoxResults.Items.Add("--- Початковий масив (з клонами) ---");
                foreach (var shape in shapeArray)
                {
                    listBoxResults.Items.Add(shape.GetFullInfo());
                }
                listBoxResults.Items.Add(""); // Порожній рядок для розділення

                // СОРТУВАННЯ МАСИВУ
                // Це працює, тому що клас Чотирикутник реалізує IComparable
                Array.Sort(shapeArray);

                // Виводимо відсортований масив
                listBoxResults.Items.Add("--- Відсортований масив (за площею) ---");
                foreach (var shape in shapeArray)
                {
                    listBoxResults.Items.Add(shape.GetFullInfo());
                }
            }
            catch (Exception ex)
            {
                // Обробка будь-яких виняткових ситуацій під час демонстрації
                MessageBox.Show($"Під час демонстрації сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}