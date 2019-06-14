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
    public partial class Form7 : Form
    {
        public struct z
        {
            public string famk;
            public string famv;
            public string data;
            public string time;
            public string service;
            public string namber;
        }

        public Form7()
        {
            InitializeComponent();
        }

        private void врачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "")  || (textBox2.Text == "") || (textBox4.Text == "") )
                MessageBox.Show("Заполните все поля!!!!", "Ошибка", MessageBoxButtons.OKCancel);
            else
            {
                Zakaz v = new Zakaz(textBox1.Text, textBox2.Text, Convert.ToString(dateTimePicker1.Value), maskedTextBox1.Text, textBox4.Text, maskedTextBox2.Text);
                if (!(textBox1.Text == "") && !(textBox2.Text == "") && !(textBox4.Text == ""))
                {
                    FileStream file1 = new FileStream("Zak.txt", FileMode.Append);
                    StreamWriter zap1 = new StreamWriter(file1);
                    zap1.WriteLine(textBox1.Text);
                    zap1.WriteLine(textBox2.Text);
                    zap1.WriteLine(dateTimePicker1.Value);
                    zap1.WriteLine(maskedTextBox1.Text);
                    zap1.WriteLine(textBox4.Text);
                    zap1.WriteLine(maskedTextBox2.Text);
                    zap1.Close();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Фамилия клиента");
                    dt.Columns.Add("Фамилия врача");
                    dt.Columns.Add("Дата");
                    dt.Columns.Add("Время");
                    dt.Columns.Add("Услуга");
                    dt.Columns.Add("Контактный телефон");
                    z[] user = new z[100];
                    StreamReader zap = new StreamReader("Zak.txt"); // Поток на чтение с файла
                    int i = 0;
                    while (zap.Peek() != -1) // Считывание с файла
                    {
                        i++;

                        user[i].famk = zap.ReadLine();
                        user[i].famv = zap.ReadLine();
                        user[i].data = zap.ReadLine();
                        user[i].time = zap.ReadLine();
                        user[i].service = zap.ReadLine();
                        user[i].namber = zap.ReadLine();
                    }
                    zap.Close();

                    for (int j = 1; j <= i; j++)

                        dt.Rows.Add(user[j].famk, user[j].famv, user[j].data, user[j].time,user[j].service,user[j].namber);
                    Form10 f10 = new Form10();
                    f10.dataGridView1.DataSource = dt;
                }
                MessageBox.Show("Спасибо за ваш заказ", "Заказы", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Form2 f2 = new Form2();
                f2.Show();
                this.Close();
            }
 
        }

        private void назадКГлавнойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b]");
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b]");
        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Запускаем нужный файл
                System.Diagnostics.Process.Start("index.htm");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
