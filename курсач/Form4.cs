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
    public partial class Form4 : Form
    {
        public struct svr
        {
            public string name; public double stoim;
        }
        public Form4()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Стоимость, руб.");
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
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить строку ?", "Удаление строки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                svr[] user = new svr[100];
                StreamReader zap1 = new StreamReader("Service.txt"); // Октрывает поток на чтение
                int i = 0, size = 0;
                while (zap1.Peek() != -1) //Считываем данные с файла
                {
                    i++;
                    user[i].name = zap1.ReadLine();
                    user[i].stoim = Convert.ToDouble(zap1.ReadLine());
                    size++;
                }
                int del;
                del = dataGridView1.CurrentCell.RowIndex;
                del++;
                svr[] user2 = new svr[100];
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
                File.Delete("Service.txt");
                FileStream file2 = new FileStream("Service.txt", FileMode.Create); // Перезапись исходного файла
                StreamWriter zap2 = new StreamWriter(file2);
                for (int j = 1; j < size; j++)
                {
                    zap2.WriteLine(user2[j].name);
                    zap2.WriteLine(user2[j].stoim);

                }
                zap2.Close();
                DataTable dt = new DataTable();
                dt.Columns.Add("Наименование услуги");
                dt.Columns.Add("Стоимость руб.");
                StreamReader zap = new StreamReader("Service.txt");
                int p = 0;
                while (zap.Peek() != -1) // Считывание с файла
                {
                    p++;
                    user2[i].name = zap.ReadLine();
                    user2[i].stoim = Convert.ToDouble(zap.ReadLine());
                }
                zap.Close();
                for (int j = 1; j <= p; j++)
                    dt.Rows.Add(user2[j].name, user2[j].stoim);
                dataGridView1.DataSource = dt;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Стоимость, руб.");
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
            dataGridView1.DataSource = dt;
        }

        private void врачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            svr[] user = new svr[100];
            svr[] user2 = new svr[100];
            StreamReader zap = new StreamReader("Service.txt"); // Октрываем поток на чтение
            int i = 0, size = 0;
            while (zap.Peek() != -1) // Считывание данных с файла
            {
                i++;
                user[i].name = zap.ReadLine();
                user[i].stoim = Convert.ToDouble(zap.ReadLine());
                size++;
            }
            zap.Close();
            int Ed;
            Ed = dataGridView1.CurrentCell.RowIndex;
            Ed++;
            GlobalTrash.MyGlobalTrash.MiGlobalVariable = Ed;
            Form9 f9 = new Form9();
            f9.textBox1.Text = user[Ed].name;
            f9.textBox2.Text = Convert.ToString(user[Ed].stoim);
            f9.Owner = this;
            f9.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int n = 1111;
            if (textBox1.Text == "")
                MessageBox.Show("Введите наименование услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
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
                if (n != 1111)
                    dataGridView1.Rows[n].Selected = true;
                else
                    MessageBox.Show("Запрашиваемой вами услуги нет!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ys = "";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Selected == true)
                {
                    ys = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    break;
                }
            }
            Form7 f7 = new Form7();
            f7.textBox4.Text = ys;
            f7.Show();

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Добавить");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox3, "Удалить");
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox4, "Редактировать");
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox5, "Нажмите для обновления таблицы");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, "Поиск услуги");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Перейти к оформлению заказа на выбранную услугу");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss dddd");
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            int n = 1111;
            if (textBox1.Text == "")
                MessageBox.Show("Введите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
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
                if (n != 1111)
                    dataGridView1.Rows[n].Selected = true;
                else
                    MessageBox.Show("Услуга не найдена", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
            }

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
