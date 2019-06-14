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

namespace курсач
{
    public partial class Form8 : Form
    {
        public struct svr
        {
            public string name; public double stoim;
        }
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
            DataTable dt = new DataTable();
            dt.Columns.Add("Наименование услуги");
            dt.Columns.Add("Стоимость руб.");
            svr[] user = new svr[100];
            StreamReader zap = new StreamReader("Service.txt"); // Поток на чтение с файла
            int i = 0;
            while (zap.Peek() != -1) // Считывание с файла
            {
                i++;

                user[i].name = zap.ReadLine();
                user[i].stoim = Convert.ToDouble(zap.ReadLine());

            }
            zap.Close();

            for (int j = 1; j <= i; j++)

                dt.Rows.Add(user[j].name, user[j].stoim);
            f4.dataGridView1.DataSource = dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
                MessageBox.Show("Заполните все поля!!!!", "Ошибка", MessageBoxButtons.OKCancel);
            else
            {
                 Service s = new Service(textBox1.Text,Convert.ToDouble(textBox2.Text));
                if (!(textBox1.Text == "") && !(textBox2.Text == ""))
                {
                    FileStream file1 = new FileStream("Service.txt", FileMode.Append);
                    StreamWriter zap1 = new StreamWriter(file1);
                    zap1.WriteLine(textBox1.Text);
                    zap1.WriteLine(textBox2.Text);
                    zap1.Close();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Наименование услуги");
                    dt.Columns.Add("Стоимость руб.");
                    svr[] user = new svr[100];
                    StreamReader zap = new StreamReader("Service.txt"); // Поток на чтение с файла
                    int i = 0;
                    while (zap.Peek() != -1) // Считывание с файла
                    {
                        i++;

                        user[i].name = zap.ReadLine();
                        user[i].stoim = Convert.ToDouble(zap.ReadLine());

                    }
                    zap.Close();

                    for (int j = 1; j <= i; j++)

                        dt.Rows.Add(user[j].name, user[j].stoim);
                    Form4 f4 = new Form4();
                    f4.dataGridView1.DataSource = dt;
                }
                MessageBox.Show("Данные добавлены!!!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
     
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b]");
        }
    }
}
