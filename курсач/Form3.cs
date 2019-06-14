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
    namespace GlobalTrash
    {
        class MyGlobalTrash
        {
            public static int MiGlobalVariable;

            public static void MiGlobalFunction()
            {
            }
        }
    }
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Специализация");
            dt.Columns.Add("Должность");
            dt.Columns.Add("Разряд");
            doc[] user = new doc[100];
            StreamReader zap = new StreamReader("Doc.txt"); // Поток на чтение с файла
            int i = 0;
            while (zap.Peek() != -1) // Считывание с файла
            {
                i++;

                user[i].fam = zap.ReadLine();
                user[i].spec = zap.ReadLine();
                user[i].dzn = zap.ReadLine();
                user[i].raz = Convert.ToInt32(zap.ReadLine());

            }
            zap.Close();

            for (int j = 1; j <= i; j++)

                dt.Rows.Add(user[j].fam, user[j].spec, user[j].dzn, user[j].raz);
            dataGridView1.DataSource = dt;
        }
        public struct doc
        {
            public string fam; public string spec; public string dzn; public int raz;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            doc[] user = new doc[100];
            doc[] user2 = new doc[100];
            StreamReader zap = new StreamReader("Doc.txt"); // Октрываем поток на чтение
            int i = 0, size = 0;
            while (zap.Peek() != -1) // Считывание данных с файла
            {
                i++;
                user[i].fam = zap.ReadLine();
                user[i].spec = zap.ReadLine();
                user[i].dzn = zap.ReadLine();
                user[i].raz = Convert.ToInt32(zap.ReadLine());
                size++;
            }
            zap.Close();
            int Ed;
            Ed = dataGridView1.CurrentCell.RowIndex;
            Ed++;
            GlobalTrash.MyGlobalTrash.MiGlobalVariable = Ed;
            Form6 f6 = new Form6();
            f6.textBox1.Text = user[Ed].fam;
            f6.comboBox1.Text = user[Ed].spec;
            f6.textBox3.Text = user[Ed].dzn;
            f6.textBox4.Text = Convert.ToString(user[Ed].raz);
            f6.Owner = this;
            f6.ShowDialog();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить строку ?", "Удаление строки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                doc[] user = new doc[100];
                StreamReader zap1 = new StreamReader("Doc.txt"); // Октрывает поток на чтение
                int i = 0, size = 0;
                while (zap1.Peek() != -1) //Считываем данные с файла
                {
                    i++;
                    user[i].fam = zap1.ReadLine();
                    user[i].spec = zap1.ReadLine();
                    user[i].dzn = zap1.ReadLine();
                    user[i].raz = Convert.ToInt32(zap1.ReadLine());
                    size++;
                }
                int del;
                del = dataGridView1.CurrentCell.RowIndex;
                del++;
                doc[] user2 = new doc[100];
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
                File.Delete("Doc.txt");
                FileStream file2 = new FileStream("Doc.txt", FileMode.Create); // Перезапись исходного файла
                StreamWriter zap2 = new StreamWriter(file2);
                for (int j = 1; j < size; j++)
                {
                    zap2.WriteLine(user2[j].fam);
                    zap2.WriteLine(user2[j].spec);
                    zap2.WriteLine(user2[j].dzn);
                    zap2.WriteLine(user2[j].raz);

                }
                zap2.Close();
                DataTable dt = new DataTable();
                dt.Columns.Add("Фамилия");
                dt.Columns.Add("Специлизация");
                dt.Columns.Add("Должность");
                dt.Columns.Add("Разряд");
                StreamReader zap = new StreamReader("Doc.txt");
                int p = 0;
                while (zap.Peek() != -1) // Считывание с файла
                {
                    p++;
                    user2[i].fam = zap.ReadLine();
                    user2[i].spec = zap.ReadLine();
                    user2[i].dzn = zap.ReadLine();
                    user2[i].raz = Convert.ToInt32(zap.ReadLine());
                }
                zap.Close();
                for (int j = 1; j <= p; j++)
                    dt.Rows.Add(user2[j].fam, user2[j].spec, user2[j].dzn, user2[j].raz);
                dataGridView1.DataSource = dt;
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Специализация");
            dt.Columns.Add("Должность");
            dt.Columns.Add("Разряд");
            doc[] user = new doc[100];
            StreamReader zap = new StreamReader("Doc.txt"); // Поток на чтение с файла
            int i = 0;
            while (zap.Peek() != -1) // Считывание с файла
            {
                i++;

                user[i].fam = zap.ReadLine();
                user[i].spec = zap.ReadLine();
                user[i].dzn = zap.ReadLine();
                user[i].raz = Convert.ToInt32(zap.ReadLine());

            }
            zap.Close();

            for (int j = 1; j <= i; j++)

                dt.Rows.Add(user[j].fam, user[j].spec, user[j].dzn, user[j].raz);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int n = 1111;
            if (textBox1.Text == "") 
            MessageBox.Show("Введите фамилию врача", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (n!=1111)
            dataGridView1.Rows[n].Selected = true;
            else
            MessageBox.Show("Врач не найден", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
        }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            string vr ="";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Selected == true)
                {
                    vr = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    break;
                }
            }
            Form7 f7 = new Form7();
            f7.textBox2.Text = vr;
            f7.Show();
            this.Close();
           

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
           toolTip1.SetToolTip(pictureBox1, "Нажмите для поиска врача");
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Введите фамилию врача для поиска");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Нажмите для добавления нового врача");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
        toolTip1.SetToolTip(pictureBox3, "Нажмите для удаления записи");
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox4, "Нажмите для редактирования записи");
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox5, "Нажмите для обновления таблицы");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
        toolTip1.SetToolTip(button1, "Перейти к оформлению заказа");
        }

        private void врачиToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Выберите критерии и нажмите для подбора необходимого врача");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo f1 = new FileInfo("Poisk.txt");
            f1.Delete();
            string sp = "";
            string dz = "";
            if (radioButton1.Checked == true)
                sp = "детский";
            if (radioButton2.Checked == true)
                sp = "взрослый";
            if (checkBox1.Checked == true)
                dz = "терапевт";
            if (checkBox2.Checked == true)
                dz = "хирург";
            if (checkBox3.Checked == true)
                dz = "стоматолог";
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false))
                MessageBox.Show("Выберите специализацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if ((checkBox1.Checked == false) && (checkBox2.Checked == false) && (checkBox3.Checked == false))
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string znach = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        if (sp == znach)
                        {
                            FileStream file1 = new FileStream("Poisk.txt", FileMode.Append);
                            StreamWriter zap1 = new StreamWriter(file1);
                            zap1.WriteLine(dataGridView1.Rows[i].Cells[0].Value);
                            zap1.WriteLine(dataGridView1.Rows[i].Cells[1].Value);
                            zap1.WriteLine(dataGridView1.Rows[i].Cells[2].Value);
                            zap1.WriteLine(dataGridView1.Rows[i].Cells[3].Value);
                            zap1.Close();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string znachd = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                        string znach = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        if ((sp == znach) && (dz == znachd))
                        {
                            FileStream file1 = new FileStream("Poisk.txt", FileMode.Append);
                            StreamWriter zap1 = new StreamWriter(file1);
                            zap1.WriteLine(dataGridView1.Rows[i].Cells[0].Value);
                            zap1.WriteLine(dataGridView1.Rows[i].Cells[1].Value);
                            zap1.WriteLine(dataGridView1.Rows[i].Cells[2].Value);
                            zap1.WriteLine(dataGridView1.Rows[i].Cells[3].Value);
                            zap1.Close();
                        }
                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Фамилия");
                dt.Columns.Add("Специализация");
                dt.Columns.Add("Должность");
                dt.Columns.Add("Разряд");
                doc[] user = new doc[100];
                StreamReader zap = new StreamReader("Poisk.txt"); // Поток на чтение с файла
                int p = 0;
                while (zap.Peek() != -1) // Считывание с файла
                {
                    p++;

                    user[p].fam = zap.ReadLine();
                    user[p].spec = zap.ReadLine();
                    user[p].dzn = zap.ReadLine();
                    user[p].raz = Convert.ToInt32(zap.ReadLine());

                }
                zap.Close();

                for (int j = 1; j <= p; j++)

                    dt.Rows.Add(user[j].fam, user[j].spec, user[j].dzn, user[j].raz);
                dataGridView1.DataSource = dt;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss dddd");
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
