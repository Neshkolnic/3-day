using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3_day
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Добавляем колонки в DataGridView
            dataGridView1.Columns.Add("ColumnIndex", "№");
            dataGridView1.Columns.Add("ColumnValue", "Значение");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n, L, M;
            


            if (int.TryParse(textBox1.Text, out n) && int.TryParse(textBox2.Text, out L) && int.TryParse(textBox3.Text, out M))
            {
                
                label5.Text = CalculateAverage(random_mass(n), L, M).ToString();
            }
            else
            {
                MessageBox.Show("Ошибка: введены некорректные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        
        private double[] random_mass(int n)
        {
            
            double[] progression = new double [n];

            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                progression[i] = rand.NextDouble()*100; // Генерируем случайное число типа double от 0 до 1
            }

            // Очищаем DataGridView перед добавлением новых данных
            dataGridView1.Rows.Clear();

            // Добавляем строки в DataGridView для отображения результатов
            if (progression != null)
            {
                for (int i = 0; i < progression.Length; i++)
                {
                    dataGridView1.Rows.Add(i + 1, progression[i]);
                }
            }
            else
            {
                MessageBox.Show("Ошибка: значение N должно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return progression;
        }

        private double CalculateAverage(double[] array, int k, int l)
        {
            // Проверяем, что массив не равен null и индексы k и l входят в допустимый диапазон
            if (array == null || k < 0 || l < 0 || k >= array.Length || l >= array.Length || k > l)
            {
                MessageBox.Show("Ошибка: некорректные индексы K и L.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return double.NaN; // Возвращаем NaN в случае ошибки
            }

            // Вычисляем сумму элементов массива с индексами от k до l
            double sum = 0;
            for (int i = k-1; i <= l-1; i++)
            {
                sum += array[i];
            }

            // Вычисляем среднее арифметическое
            double average;
            average = sum / ((l - k) + 1);

            return average;
        }

    }
}
