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
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
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
            try
            {
                int.Parse(textBox6.Text);

            }
            catch
            {
                MessageBox.Show("数目必须是个整数");
                return;
            }

           
            //添加出货记录
            cmdXML cx = new cmdXML();
            
            stf.outprice = textBox5.Text;
            stf.shumu = int.Parse(textBox6.Text);

            cx.AddFurElement("chuHuo.xml",stf,"outhere");
            string snews = cx.fenliSingleNode("mainStore.xml", "store", stf);
            
            switch (snews)
            {
                case "fail<":
                    MessageBox.Show("库存不足");
                    break;
                case "failNo":
                    MessageBox.Show("无相应产品");
                    break;
                case "succeedbut0":
                    MessageBox.Show("最后一件该商品卖出啦");
                    break;
                case "":
                    MessageBox.Show("这种情况一般不会出现，如果出现请联系coder");
                    break;
                default:
                    MessageBox.Show("出货成功，剩余"+snews);
                    break;

            }

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
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;

            textBox5.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
