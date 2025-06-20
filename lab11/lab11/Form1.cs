using System;
using System.Windows.Forms;

namespace lab11
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
                string selectedShape = comboBoxShapes.SelectedItem.ToString();
                UpdateInputFields(selectedShape);
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
                    string shapeDisplayName = comboBoxShapes.SelectedItem.ToString();
                    double area = shape.CalculateArea();
                    labelResult.Text = $"Фігура: {shapeDisplayName}\nПлоща: {area:F2}";
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
    }
}