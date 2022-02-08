/*Условие: Разработать программу, выделив процедуры.*/
/**Задача 4.3.3 Условие: даны два целочисленных массива с положительными элементами X1, X2...Xn и Y1, Y2...Yn. 
Если все элементы массива X меньше всех элементов массива Y с соответствующими индексами, сформировать массив Z1 Z2...Zn
по правилу */

/*Condition: Develop a program by selecting procedures.*/
/**Problem 4.3.3 Condition: two integer arrays with positive elements X1, X2...Xn and Y1, Y2...Yn are given.
If all elements of array X are less than all elements of array Y with corresponding indexes, form an array Z1 Z2...Zn
according to the rule */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23_variant_CSarp_4_3_3
{
    public partial class ArrRulesProcedure : Form
    {
        public ArrRulesProcedure()
        {
            InitializeComponent();
        }
        private void buttonMatrDim_Click(object sender, EventArgs e)
        {
            ushort n = ushort.Parse(textBoxInputEl.Text);                           //n x n матрица
            dataGridView1.RowCount = 1;                                       //кол-во строк
            dataGridView1.ColumnCount = n;                                    //столбцов    
            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = n;
            dataGridView3.RowCount = 1;                                       //одномерный массив С
            dataGridView3.ColumnCount = n;
            dataGridView1.Rows[0].HeaderCell.Value = "Матрица X";
            dataGridView2.Rows[0].HeaderCell.Value = "Матрица Y";
            dataGridView3.Rows[0].HeaderCell.Value = "Матрица Z";
            Random rnd = new Random();
            double[] tableArr_X = new double[n];
            double[] tableArr_Y = new double[n];
            double[] tableArr_Z = new double[n];
            ushort ArrayElLess = 0;                                         //счетчик кол-во элементов меньше

            for (int count_column = 0; count_column < n; count_column++)                                         //заполняем значения X
            {
                tableArr_X[count_column] = rnd.Next(0, 25);                 //заполняем массив случайными значениями
                tableArr_Y[count_column] = rnd.Next(0, 25);
                dataGridView1.Rows[0].Cells[count_column].Value = tableArr_X[count_column];
                dataGridView2.Rows[0].Cells[count_column].Value = tableArr_Y[count_column];
                if (tableArr_X[count_column] < tableArr_Y[count_column])                     //Если элемент Aii меньше хоть одного текущего элемента i-ой строки матрицы
                    ArrayElLess++;
            }
            if (ArrayElLess == n)                                                                     //если все элементы массива X меньше всех эл. массива Y
            {
                for (int count_column = 0; count_column < n; count_column++)                                         //заполняем значения X
                {
                    tableArr_Z[count_column] = Factorial(tableArr_Y[count_column]) / (Factorial(tableArr_Y[count_column]) * (Factorial(tableArr_Y[count_column]) - Factorial(tableArr_X[count_column])));
                    dataGridView3.Rows[0].Cells[count_column].Value = tableArr_Z[count_column].ToString("0.######");
                }
            }
            double Factorial(double x)
            {
                if (x == 0 || x == 1)                                                           // базовое или частное решение
                {
                    return 1;
                }
                else
                {
                    return x * Factorial(x - 1);                                                //Рекурсивный вызов
                }
            }
        }
    }
}