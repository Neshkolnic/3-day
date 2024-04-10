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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void заданиеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void заданиеToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Добавляем колонки в DataGridView
            dataGridView1.Columns.Add("ColumnIndex", "№");
            dataGridView1.Columns.Add("ColumnValue", "Значение");

        }

        private double[] Geimetric_progr(int n, double a, double d)
        {
            if (n <= 0)
            {
                return null;
            }
            double[] result = new double[n+1];
            for (int i = 1; i < result.Length; i++)
            {
                result[i-1] = a * Math.Pow(d, i-1);
            }

            return result;
        }

        private void DisplayGeometricProgression(int n, double a, double d)
        {
            // Получаем массив с результатами геометрической прогрессии
            double[] progression = Geimetric_progr(n, a, d);

            // Очищаем DataGridView перед добавлением новых данных
            dataGridView1.Rows.Clear();

            // Добавляем строки в DataGridView для отображения результатов
            if (progression != null)
            {
                for (int i = 0; i < progression.Length-1; i++)
                {
                    dataGridView1.Rows.Add(i + 1, progression[i]);
                }
            }
            else
            {
                MessageBox.Show("Ошибка: значение N должно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            double a, d;
            if (int.TryParse(textBox1.Text, out n) && double.TryParse(textBox2.Text, out a) && double.TryParse(textBox3.Text, out d))
            {
                DisplayGeometricProgression(n, a, d);
            }
            else
            {
                MessageBox.Show("Ошибка: введены некорректные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
