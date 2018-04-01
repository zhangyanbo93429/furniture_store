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
            textBox5.Text = "不可用";
            textBox5.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //判断输入数据是否正常
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("信息不完善");
                return;
            }
            try
            {
                float.Parse(textBox3.Text);
                float.Parse(textBox4.Text);
                
            }
            catch
            {
                MessageBox.Show("价格必须是一个数字");
                return;
            }

            try
            {
                int.Parse(textBox6.Text);
            }
            catch
            {
                MessageBox.Show("数目必须是个整数");
                return;
            }
            //将添加的值加入库存xml中
            string[] str1 = {textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,System.DateTime.Now.ToString("yyyyMMddHHmmssfff"), Convert.ToString(textBox6.Text) };            
            storeFur stf = new storeFur(str1);
            
                
            cmdXML cx = new cmdXML();
           
            //进货记录添加
            cx.AddFurElement("jinHuo.xml",stf,"inhere");
            //库存状况更新
            cx.hebingSingleNode("mainStore.xml","store",stf);
            //告诉主对话框刷新datagridview
            Form1 fm1 = (Form1)this.Owner;
            fm1.formRefresh("mainStore.xml", "store");
            //关闭对话框
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
