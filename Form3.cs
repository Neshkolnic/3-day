using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_day
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 8;
            dataGridView1.ColumnCount = 8;
            for (int i = 0; i < 8; i++)
            {
                dataGridView1.Columns[i].Width = dataGridView1.Rows[i].Height;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int[,] matrix = new int[8, 8];

            // Заполняем матрицу случайными числами из интервала [-9, 9]
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = rand.Next(-9, 10);
                }
            }

            // Определяем максимальный элемент в каждой строке и меняем его местами с последним элементом строки
            for (int i = 0; i < 8; i++)
            {
                int maxIndex = 0;
                int maxElement = matrix[i, 0];
                for (int j = 1; j < 8; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        maxIndex = j;
                    }
                }
                // Меняем местами максимальный элемент и последний элемент в строке
                int temp = matrix[i, maxIndex];
                matrix[i, maxIndex] = matrix[i, 7];
                matrix[i, 7] = temp;
            }

            // Выводим матрицу на DataGridView
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dataGridView1[j, i].Value = matrix[i, j];
                }
            }
        }
    }
    
}
