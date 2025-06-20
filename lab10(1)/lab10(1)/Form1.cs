using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab10_1_ // Ваш простір імен
{
    public partial class Form1 : Form
    {
        private int[,] matrix = new int[8, 8];
        private const int MatrixSize = 8;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            // Ми викликаємо методи ініціалізації та генерації ПІСЛЯ InitializeComponent
            InitializeDataGridViewSafely();
            GenerateAndDisplayRandomMatrix();
        }

        // БІЛЬШ БЕЗПЕЧНИЙ МЕТОД ІНІЦІАЛІЗАЦІЇ ТАБЛИЦІ
        private void InitializeDataGridViewSafely()
        {
            // Зупиняємо будь-які автоматичні маніпуляції з таблицею
            dataGridViewMatrix.AutoGenerateColumns = false;
            dataGridViewMatrix.AllowUserToAddRows = false;

            // Очищуємо всі стовпці та рядки, які могли бути створені дизайнером
            dataGridViewMatrix.Columns.Clear();
            dataGridViewMatrix.Rows.Clear();

            // Дозволяємо редагування
            dataGridViewMatrix.ReadOnly = false;

            // Налаштовуємо вигляд
            dataGridViewMatrix.RowHeadersVisible = true;
            dataGridViewMatrix.RowHeadersWidth = 50;

            // СТВОРЮЄМО СТОВПЦІ ПРОГРАМНО
            for (int i = 0; i < MatrixSize; i++)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    HeaderText = (i + 1).ToString(),
                    Width = 40,
                    Name = $"Col{i}" // Унікальне ім'я для кожного стовпця
                };
                dataGridViewMatrix.Columns.Add(column);
            }

            // СТВОРЮЄМО РЯДКИ ПРОГРАМНО
            dataGridViewMatrix.RowCount = MatrixSize;
            for (int i = 0; i < MatrixSize; i++)
            {
                dataGridViewMatrix.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        // Метод для генерації та відображення випадкової матриці
        private void GenerateAndDisplayRandomMatrix()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    int value = random.Next(-20, 50); // Генеруємо числа в діапазоні
                    matrix[i, j] = value;
                    dataGridViewMatrix.Rows[i].Cells[j].Value = value;
                }
            }
        }

        // Метод для зчитування даних з таблиці в наш масив matrix
        private bool ReadMatrixFromGrid()
        {
            // Створюємо новий масив, щоб не посилатися на старі дані
            matrix = new int[MatrixSize, MatrixSize];

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    // Перевіряємо, чи введено коректне число
                    if (dataGridViewMatrix.Rows[i].Cells[j].Value != null &&
                        int.TryParse(dataGridViewMatrix.Rows[i].Cells[j].Value.ToString(), out int cellValue))
                    {
                        matrix[i, j] = cellValue;
                    }
                    else
                    {
                        MessageBox.Show($"Некоректне значення у комірці (Рядок: {i + 1}, Стовпець: {j + 1}).\nБудь ласка, введіть ціле число.",
                                        "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Зупиняємо обчислення
                    }
                }
            }
            return true; // Всі дані коректні
        }

        // --- Обробники подій для кнопок ---

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!ReadMatrixFromGrid())
            {
                return; // Якщо дані невірні, виходимо
            }

            richTextBoxResults.Clear();
            FindMatchingRowsAndColumns();
            CalculateSumOfRowsWithNegatives();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateAndDisplayRandomMatrix();
        }

        // --- Логіка обчислень (залишається без змін) ---

        private void FindMatchingRowsAndColumns()
        {
            var matchingKValues = new List<int>();
            for (int k = 0; k < MatrixSize; k++)
            {
                bool isMatch = true;
                for (int j = 0; j < MatrixSize; j++)
                {
                    if (matrix[k, j] != matrix[j, k])
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    matchingKValues.Add(k + 1);
                }
            }
            if (matchingKValues.Count > 0)
            {
                richTextBoxResults.AppendText("Номери (k), де k-тий рядок співпадає з k-тим стовпцем:\n");
                richTextBoxResults.AppendText($"   {string.Join(", ", matchingKValues)}\n\n");
            }
            else
            {
                richTextBoxResults.AppendText("Немає рядків, що співпадають з відповідними стовпцями.\n\n");
            }
        }

        private void CalculateSumOfRowsWithNegatives()
        {
            long totalSum = 0;
            bool foundAny = false;
            richTextBoxResults.AppendText("Суми елементів рядків, що містять від'ємні числа:\n");

            for (int i = 0; i < MatrixSize; i++)
            {
                bool hasNegative = false;
                for (int j = 0; j < MatrixSize; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (hasNegative)
                {
                    foundAny = true;
                    long currentRowSum = 0;
                    for (int j = 0; j < MatrixSize; j++)
                    {
                        currentRowSum += matrix[i, j];
                    }
                    totalSum += currentRowSum;
                    richTextBoxResults.AppendText($"   Рядок {i + 1}: Сума = {currentRowSum}\n");
                }
            }

            if (foundAny)
            {
                richTextBoxResults.AppendText($"\nЗагальна сума елементів у цих рядках: {totalSum}\n");
            }
            else
            {
                richTextBoxResults.AppendText("Жоден рядок не містить від'ємних елементів.\n");
            }
        }
    }
}