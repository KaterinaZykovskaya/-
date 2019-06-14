using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсач
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            label2.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.F2)
            {
                textBox1.Visible = true;
                label2.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text=="")
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
                Form3 f3 = new Form3();
                f3.pictureBox2.Visible = false;
                f3.pictureBox3.Visible = false;
                f3.pictureBox4.Visible = false;
                Form4 f4 = new Form4();
                f4.pictureBox2.Visible = false;
                f4.pictureBox3.Visible = false;
                f4.pictureBox4.Visible = false;
                Form10 f10 = new Form10();
                f10.pictureBox2.Visible = false;
                f10.pictureBox3.Visible = false;

            }
            else
                if (textBox1.Text=="admin")
            {
                Form2 f2 = new Form2();
                f2.списокЗаказовToolStripMenuItem.Visible = true;
                f2.Show();
                this.Hide();
                Form3 f3 = new Form3();
                f3.pictureBox2.Visible = true ;
                f3.pictureBox3.Visible = true;
                f3.pictureBox4.Visible = true;
                Form4 f4 = new Form4();
                f4.pictureBox2.Visible = true;
                f4.pictureBox3.Visible = true;
                f4.pictureBox4.Visible = true;
                Form10 f10 = new Form10();
                f10.pictureBox2.Visible = true;
                f10.pictureBox3.Visible = true;
            }
        }
    }
}
