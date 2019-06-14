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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Ed;
            Ed = GlobalTrash.MyGlobalTrash.MiGlobalVariable;

            Form4.svr[] user = new Form4.svr[100];
            Form4.svr[] user2 = new Form4.svr[100];
            Form4.svr[] user3 = new Form4.svr[100];
            user3[Ed].name = textBox1.Text;
            user3[Ed].stoim = Convert.ToDouble(textBox2.Text);
            StreamReader zap = new StreamReader("Service.txt"); // Поток на чтение с файла
            int i = 0, size = 0;
            while (zap.Peek() != -1) // Считывание с файла
            {
                i++;
                user[i].name = zap.ReadLine();
                user[i].stoim = Convert.ToDouble(zap.ReadLine());
                size++;
            }
            zap.Close();
            File.Delete("Service.txt");
            for (int j = 1; j <= size; j++)
            {
                if (j != Ed)
                {
                    user2[j] = user[j];
                }
                else
                {
                    user2[j] = user3[Ed];
                }
            }
            FileStream file2 = new FileStream("Service.txt", FileMode.Create); // Перезапись исходного файла в новый 
            StreamWriter zap1 = new StreamWriter(file2);
            for (int j = 1; j <= size; j++)
            {
                zap1.WriteLine(user2[j].name);
                zap1.WriteLine(user2[j].stoim);
            }
            zap1.Close();

            DataTable dt = new DataTable();
            dt.Columns.Add("Наименование услуги");
            dt.Columns.Add("Стоимость руб.");
            StreamReader zap3 = new StreamReader("Service.txt"); // Поток на чтение с файла
            int d;
            d = 0;
            while (zap3.Peek() != -1) // Считывание с файла
            {
                d++;
                user2[i].name = zap3.ReadLine();
                user2[i].stoim = Convert.ToDouble(zap3.ReadLine());
            }
            zap3.Close();
            for (int t = 1; t <= d; t++)
                //                entry  text    

                dt.Rows.Add(user2[t].name, user2[t].stoim);
            Form4 f4 = this.Owner as Form4;
            f4.dataGridView1.DataSource = dt;
            this.Close();
        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b]");
        }
    }
}
