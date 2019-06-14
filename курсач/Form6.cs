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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Ed;
            Ed = GlobalTrash.MyGlobalTrash.MiGlobalVariable;

            Form3.doc[] user = new Form3.doc[100];
            Form3.doc[] user2 = new Form3.doc[100];
            Form3.doc[] user3 = new Form3.doc[100];
            user3[Ed].fam = textBox1.Text;
            user3[Ed].spec = comboBox1.Text;
            user3[Ed].dzn = textBox3.Text;
            user3[Ed].raz = Convert.ToInt32(textBox4.Text);
            StreamReader zap = new StreamReader("Doc.txt"); // Поток на чтение с файла
            int i = 0, size = 0;
            while (zap.Peek() != -1) // Считывание с файла
            {
                i++;
                user[i].fam = zap.ReadLine();
                user[i].spec = zap.ReadLine();
                user[i].dzn = zap.ReadLine();
                user[i].raz = Convert.ToInt32(zap.ReadLine());
                size++;
            }
            zap.Close();
            File.Delete("Doc.txt");
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
            FileStream file2 = new FileStream("Doc.txt", FileMode.Create); // Перезапись исходного файла в новый 
            StreamWriter zap1 = new StreamWriter(file2);
            for (int j = 1; j <= size; j++)
            {
                zap1.WriteLine(user2[j].fam);
                zap1.WriteLine(user2[j].spec);
                zap1.WriteLine(user2[j].dzn);
                zap1.WriteLine(user2[j].raz);
            }
            zap1.Close();

            DataTable dt = new DataTable();
            dt.Columns.Add("Фамилия врача");
            dt.Columns.Add("Специлизация");
            dt.Columns.Add("Должность");
            dt.Columns.Add("Разряд");
            StreamReader zap3 = new StreamReader("Doc.txt"); // Поток на чтение с файла
            int d;
            d = 0;
            while (zap3.Peek() != -1) // Считывание с файла
            {
                d++;
                user2[i].fam = zap3.ReadLine();
                user2[i].spec = zap3.ReadLine();
                user2[i].dzn = zap3.ReadLine();
                user2[i].raz = Convert.ToInt32(zap3.ReadLine());
            }
            zap3.Close();
            for (int t = 1; t <= d; t++)
                //                entry  text    

                dt.Rows.Add(user2[t].fam, user2[t].spec, user2[t].dzn, user2[t].raz);
            Form3 f3 = this.Owner as Form3;
            f3.dataGridView1.DataSource = dt;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b]");
        }
    }
}