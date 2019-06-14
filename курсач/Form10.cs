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
    public partial class Form10 : Form
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
        public Form10()
        {
            InitializeComponent();
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

                dt.Rows.Add(user[j].famk, user[j].famv, user[j].data, user[j].time, user[j].service, user[j].namber);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
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

                dt.Rows.Add(user[j].famk, user[j].famv, user[j].data, user[j].time, user[j].service, user[j].namber);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("Вы действительно хотите удалить строку ?", "Удаление строки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                z[] user = new z[100];
                StreamReader zap1 = new StreamReader("Zak.txt"); // Октрывает поток на чтение
                int i = 0, size = 0;
                while (zap1.Peek() != -1) //Считываем данные с файла
                {
                    i++;
                    user[i].famk = zap1.ReadLine();
                        user[i].famv = zap1.ReadLine();
                        user[i].data = zap1.ReadLine();
                        user[i].time = zap1.ReadLine();
                        user[i].service = zap1.ReadLine();
                        user[i].namber = zap1.ReadLine();
                    size++;
                }
                int del;
                del = dataGridView1.CurrentCell.RowIndex;
                del++;
                z[] user2 = new z[100];
                for (int j = 1; j <= size; j++) // Перезапись исходного массива в новый без удаляемого элемента, т.е. сдвиг
                {
                    if (j < del)
                    {
                        user2[j] = user[j];
                    }
                    if (j > del)
                    {
                        user2[j - 1] = user[j];
                    }
                }
                zap1.Close();
                File.Delete("Zak.txt");
                FileStream file2 = new FileStream("Zak.txt", FileMode.Create); // Перезапись исходного файла
                StreamWriter zap2 = new StreamWriter(file2);
                for (int j = 1; j < size; j++)
                {
                    zap2.WriteLine(user2[j].famk);
                    zap2.WriteLine(user2[j].famv);
                    zap2.WriteLine(user2[j].data);
                    zap2.WriteLine(user2[j].time);
                     zap2.WriteLine(user2[j].service);
                     zap2.WriteLine(user2[j].namber);

                }
                zap2.Close();
                DataTable dt = new DataTable();
                dt.Columns.Add("Фамилия клиента");
            dt.Columns.Add("Фамилия врача");
            dt.Columns.Add("Дата");
            dt.Columns.Add("Время");
            dt.Columns.Add("Услуга");
            dt.Columns.Add("Контактный телефон");
                StreamReader zap = new StreamReader("Zak.txt");
                int p = 0;
                while (zap.Peek() != -1) // Считывание с файла
                {
                    p++;
                    user2[i].famk = zap.ReadLine();
                        user2[i].famv = zap.ReadLine();
                        user2[i].data = zap.ReadLine();
                        user2[i].time = zap.ReadLine();
                        user2[i].service = zap.ReadLine();
                        user2[i].namber = zap.ReadLine();
                }
                zap.Close();
                for (int j = 1; j <= p; j++)
                    dt.Rows.Add(user2[j].famk, user2[j].famv, user2[j].data, user2[j].time, user2[j].service, user2[j].namber);
                dataGridView1.DataSource = dt;
            }

        }



        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void назадКГлавнойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        private void врачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int n = 1111;
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false) && (radioButton3.Checked == false))
            {
                MessageBox.Show("Выберите критерий поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Введите текст поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (radioButton1.Checked == true)
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            dataGridView1.Rows[i].Selected = false;
                            if (dataGridView1.Rows[i].Cells[0].Value != null)
                                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(textBox1.Text))
                                {
                                    n = i;
                                    break;
                                }

                        }
                    }
                    if (radioButton2.Checked == true)
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            dataGridView1.Rows[i].Selected = false;
                            if (dataGridView1.Rows[i].Cells[1].Value != null)
                                if (dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(textBox1.Text))
                                {
                                    n = i;
                                    break;
                                }

                        }
                    }
                    if (radioButton3.Checked == true)
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            dataGridView1.Rows[i].Selected = false;
                            if (dataGridView1.Rows[i].Cells[4].Value != null)
                                if (dataGridView1.Rows[i].Cells[4].Value.ToString().Contains(textBox1.Text))
                                {
                                    n = i;
                                    break;
                                }

                        }
                    }

                    if (n != 1111)
                        dataGridView1.Rows[n].Selected = true;
                    else
                        MessageBox.Show("Заказ не найден!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                textBox1.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss dddd");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
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
