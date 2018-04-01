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
    public partial class Form3 : Form
    {
        public storeFur stf;
        public string targetXML;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //判断输入数据是否正常
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == ""&& textBox5.Text == ""&& textBox6.Text == "")
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
            if (targetXML == "出货记录")
            {
                try
                {
                    float.Parse(textBox5.Text);  
                }
                catch
                {
                    MessageBox.Show("价格必须是一个数字");
                    return;
                }
            }
            //将添加的值加入xml文件中
            cmdXML cx = new cmdXML(); 
            string[] str1 = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, stf.date,textBox6.Text };
            storeFur stf_l = new storeFur(str1);
            //告诉主对话框刷新datagridview
            Form1 fm1 = (Form1)this.Owner;
            switch (targetXML)
            {
                case "库存状况":
                    cx.updateSingleNode("mainStore.xml", "store", stf.date, stf_l);
                    fm1.formRefresh("mainStore.xml", "store");
                    break;
                case "进货记录":
                    cx.updateSingleNode("jinHuo.xml", "inhere", stf.date, stf_l);
                    fm1.formRefresh("jinHuo.xml", "inhere");
                    break;
                case "出货记录":
                    cx.updateSingleNode("chuHuo.xml", "outhere", stf.date, stf_l);
                    fm1.formRefresh("chuHuo.xml", "outhere");
                    break;
                
            }         
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

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = stf.variety;
            textBox2.Text = stf.number;
            textBox3.Text = stf.inprice;
            textBox4.Text = stf.onprice;
            textBox5.Text = stf.outprice;
            textBox6.Text = Convert.ToString(stf.shumu);
        }
    }
}
