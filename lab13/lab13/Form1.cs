using System;
using System.Collections.Generic;
using System.Windows.Forms;

// УВАГА: Простір імен оновлено на lab13
namespace lab13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateShapesComboBox();
        }

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
                    label1.Text = "Основа:"; label2.Text = "Висота:";
                    label1.Visible = true; textBox1.Visible = true;
                    label2.Visible = true; textBox2.Visible = true;
                    break;
                case "Прямокутник":
                    label1.Text = "Сторона A:"; label2.Text = "Сторона B:";
                    label1.Visible = true; textBox1.Visible = true;
                    label2.Visible = true; textBox2.Visible = true;
                    break;
                case "Ромб":
                    label1.Text = "Діагональ 1:"; label2.Text = "Діагональ 2:";
                    label1.Visible = true; textBox1.Visible = true;
                    label2.Visible = true; textBox2.Visible = true;
                    break;
                case "Квадрат":
                    label1.Text = "Сторона:";
                    label1.Visible = true; textBox1.Visible = true;
                    label2.Visible = false; textBox2.Visible = false;
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
                    case "Паралелограм": shape = new Паралелограм(val1, val2); break;
                    case "Прямокутник": shape = new Прямокутник(val1, val2); break;
                    case "Ромб": shape = new Ромб(val1, val2); break;
                    case "Квадрат": shape = new Квадрат(val1); break;
                }
                if (shape != null) { labelResult.Text = shape.GetFullInfo(); }
            }
            catch (FormatException) { MessageBox.Show("Будь ласка, введіть коректні числові значення.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message, "Помилка даних", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show($"Сталася невідома помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCollectionDemo_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            try
            {
                var myCollection = new QuadCollection();
                myCollection.AddShape(new Квадрат(10));
                myCollection.AddShape(new Ромб(12, 10));
                myCollection.AddShape(new Прямокутник(8, 9));

                listBoxResults.Items.Add("--- Вміст неузагальненого Stack ---");
                myCollection.GetNonGenericStackInfo().ForEach(item => listBoxResults.Items.Add(item));
                listBoxResults.Items.Add("");

                listBoxResults.Items.Add("--- Вміст узагальненого Stack<T> ---");
                myCollection.GetGenericStackInfo().ForEach(item => listBoxResults.Items.Add(item));
                listBoxResults.Items.Add("");

                listBoxResults.Items.Add("--- Верхній елемент (метод Peek) ---");
                listBoxResults.Items.Add(myCollection.PeekTopElementInfo());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Під час демонстрації колекції сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}