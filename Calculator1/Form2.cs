using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //像个憨憨一样疯狂吐槽
            textBox1.Text = "请在下面文本框输入您的吐槽：";
            if (textBox2.Text.Length >0&& textBox2.Text.Length<1000)
            {
                textBox1.Text = "吐槽字数少于1000，请在下面文本框输入您的吐槽：";
                textBox2.Text = "";
            }
        }

        //private void TextBox2_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
