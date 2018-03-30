using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuTianCheng;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmdXML cx = new cmdXML();
            //判断编辑框有无做出改变           
            //将添加的值加入xml文件中
            //添加记录
            string[] str1 = {textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,System.DateTime.Now.ToString("yyyyMMddHHmmssfff") };
            
            storeFur stf = new storeFur(str1);
            cx.AddFurElement("mainStore.xml",stf, "/store");
            //告诉主对话框刷新datagridview
            Form1 fm1 = (Form1)this.Owner;
            fm1.formRefresh();
            //关闭对话框
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
