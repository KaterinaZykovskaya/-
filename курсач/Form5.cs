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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public struct doc
        {
            public string fam; public string spec; public string dzn; public int raz;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (comboBox1.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
                MessageBox.Show("Заполните все поля!!!!", "Ошибка", MessageBoxButtons.OKCancel);
            else
            {
                Doctor v = new Doctor(textBox1.Text, comboBox1.Text, textBox3.Text, Convert.ToInt32(textBox4.Text));
                if (!(textBox1.Text == "") && !(comboBox1.Text == "") && !(textBox3.Text == "") && !(textBox4.Text == ""))
                {
                    FileStream file1 = new FileStream("Doc.txt", FileMode.Append);
                    StreamWriter zap1 = new StreamWriter(file1);
                    zap1.WriteLine(textBox1.Text);
                    zap1.WriteLine(comboBox1.Text);
                    zap1.WriteLine(textBox3.Text);
                    zap1.WriteLine(textBox4.Text);
                    zap1.Close();
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
                    Form3 f3 = new Form3();
                    f3.dataGridView1.DataSource = dt;
                }
                MessageBox.Show("Данные добавлены!!!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b]");
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
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
            f3.dataGridView1.DataSource = dt;

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Нажмите для добавления данных");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Вернуться к таблице врачей");
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

    }
}
