using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Streams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Fill (int[,] mas, int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    richTextBox1.Text += mas[i, j] + " ";
                }
                richTextBox1.Text += "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Files/file2.txt",true); // вызываем класс, даем имя ; пишем относительный путь
            string str = textBox1.Text; 
            sw.WriteLine(str);
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("Files/file2.txt",Encoding.Default))
            {
                richTextBox1.Text = "";
                // richTextBox1.Text = sr.ReadLine(); считали 1 строку
                // richTextBox1.Text += "\n" + sr.ReadLine(); считали 2 строку
                //richTextBox1.Text = sr.ReadToEnd(); считали все

                while (!sr.EndOfStream) // отриц. знак значит - пока не..
                {
                    richTextBox1.Text += sr.ReadLine() + "\n";
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Row = 0;
            richTextBox1.Text = "";
            int[,] arr = new int[5, 10];

            StreamReader sr = new StreamReader("Files/matrica.txt");

            while (!sr.EndOfStream )
            {
                string[] NumbersInString = sr.ReadLine().Split(' ') ; // по сути - new int 10, это делает split
                for (int i = 0; i < 10; i++)
                {
                    arr[Row, i] = Convert.ToInt32(NumbersInString[i]);
                }
                Row++;
            }

            sr.Close();
            Fill(arr,5,10);
        }
    }
}
