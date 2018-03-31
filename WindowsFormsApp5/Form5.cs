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
    public partial class Form5 : Form
    {
        public storeFur stf;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //判断输入数据是否正常
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("信息不完善");
                return;
            }
            try
            {
                float.Parse(textBox3.Text);
                float.Parse(textBox4.Text);
                float.Parse(textBox5.Text);
            }
            catch
            {
                MessageBox.Show("价格必须是一个数字");
                return;
            }

            //删除库存节点
            cmdXML cx = new cmdXML();
            cx.deleteSingleNode("mainStore.xml", "store", stf.date);
            //添加出货记录
            stf.outprice = textBox5.Text;
            cx.AddFurElement("chuHuo.xml",stf,"outhere");
            
            //告诉主对话框刷新datagridview
            Form1 fm1 = (Form1)this.Owner;
            fm1.formRefresh("mainStore.xml", "store");
            //关闭对话框
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = stf.variety;
            textBox2.Text = stf.number;
            textBox3.Text = stf.inprice;
            textBox4.Text = stf.onprice;


            textBox5.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
