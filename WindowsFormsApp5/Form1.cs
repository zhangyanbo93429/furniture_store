using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using PuTianCheng;
using System.IO;
namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        XmlHelper xh;
        cmdXML cx;
       
        public Form1()
        {
            InitializeComponent();
            //并打开一个xml文件，如不存在，则创建之
            xh = new XmlHelper();
            cx = new cmdXML();
           
            cx.CreateXMLDoc("mainStore.xml","store");
            cx.CreateXMLDoc("jinHuo.xml","inhere");
            cx.CreateXMLDoc("chuHuo.xml","outhere");
            cx.CreateXMLDoc("chaXun.xml","result");
            //以十条为单位，查询其内容并显示在dataGridView1上
            this.dataGridView1.Columns.Add(@"variety",@"品种");
            this.dataGridView1.Columns.Add(@"number", @"型号");
            this.dataGridView1.Columns.Add(@"inprice", @"进价");
            this.dataGridView1.Columns.Add(@"onprice", @"货场标价");
            this.dataGridView1.Columns.Add(@"outprice", @"实际出货价");
            this.dataGridView1.Columns.Add(@"id",@"存储编号");
            this.dataGridView1.Columns.Add(@"date", @"日期");
            this.dataGridView1.Columns.Add(@"shumu", @"数目");
            //不允许用户编辑datagridview中的数据
            this.dataGridView1.ReadOnly = true;
           

            //refresh
            formRefresh("mainStore.xml", "store");
            


        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            //dialog最大化
            this.WindowState = FormWindowState.Maximized;
            //datagridview自适应
            dataGridView1.AutoResizeColumns();
            //datagridview字体调大
            //用vs可视化界面
            //button 隐藏
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;

            button1.Visible = false;
            button1.Visible = false;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    if (dataGridView1.SelectedRows[0].Cells[5].Value != null)
                    {
                        string[] str_ss = { dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), dataGridView1.SelectedRows[i].Cells[2].Value.ToString(), dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), dataGridView1.SelectedRows[i].Cells[4].Value.ToString(), dataGridView1.SelectedRows[i].Cells[5].Value.ToString(), dataGridView1.SelectedRows[i].Cells[7].Value.ToString() };
                        Form5 myform = new Form5();
                        myform.stf = new storeFur(str_ss);
                        myform.ShowDialog(this);
                    }
                }
            }

        }


        //将数据库中的数据刷新到datagridview上
        public void formRefresh(string xmlName,string rootName)
        {
            //总成本、利润及库存
            double totalin,totalout,totalon1,totalon2;
            //通过mainstore.xml刷新datagridview的值
            ArrayList al = cx.searchAllNode(xmlName, rootName);
           
            dataGridView1.Rows.Clear();
            if (al.Count > 0)
            {
                dataGridView1.Rows.Add(al.Count);
                for (int i = al.Count - 1; i >= 0; i--)
                {
                    storeFur stf1 = new storeFur();
                    stf1 = al[al.Count-1-i] as storeFur;
                    dataGridView1.Rows[i].Cells[0].Value = stf1.variety;
                    dataGridView1.Rows[i].Cells[1].Value = stf1.number;
                    dataGridView1.Rows[i].Cells[2].Value = stf1.inprice;
                    dataGridView1.Rows[i].Cells[3].Value = stf1.onprice;
                    dataGridView1.Rows[i].Cells[4].Value = stf1.outprice;
                    dataGridView1.Rows[i].Cells[5].Value = stf1.date;
                    dataGridView1.Rows[i].Cells[6].Value = stf1.num2Date();
                    dataGridView1.Rows[i].Cells[7].Value = Convert.ToString(stf1.shumu);
                   
                    
                }
                
                switch (xmlName)
                {
                    case "mainStore.xml":
                        label1.Text = "库存状况";
                        //标价总额
                        totalon1 = 0;
                        totalon2 = 0;
                        for (int i1 = 0; i1 < al.Count; i1++)
                        {
                            totalon1 += double.Parse(dataGridView1.Rows[i1].Cells[2].Value.ToString()) * double.Parse(dataGridView1.Rows[i1].Cells[7].Value.ToString());
                            totalon2 += double.Parse(dataGridView1.Rows[i1].Cells[3].Value.ToString()) * double.Parse(dataGridView1.Rows[i1].Cells[7].Value.ToString());
                        }
                        label2.Text = "当前货场投入成本:" + totalon1 + "； 货场总标价" + totalon2;
                        break;
                    case "jinHuo.xml":
                        label1.Text = "进货记录";
                        //进货总成本
                        totalin = 0;
                        for (int i1 = 0; i1 < al.Count; i1++)
                        {
                            totalin += double.Parse(dataGridView1.Rows[i1].Cells[2].Value.ToString()) * double.Parse(dataGridView1.Rows[i1].Cells[7].Value.ToString());
                        }
                        label2.Text = "进货总成本:" + totalin;

                        break;
                    case "chuHuo.xml":
                        label1.Text = "出货记录";
                        //总营业额
                        totalout = 0;
                        for (int i1 = 0; i1 < al.Count; i1++)
                        {
                            totalout += double.Parse(dataGridView1.Rows[i1].Cells[4].Value.ToString()) * double.Parse(dataGridView1.Rows[i1].Cells[7].Value.ToString());
                        }
                        label2.Text = "总营业额:" + totalout;
                        break;
                    case "chaXun.xml":
                        label1.Text = "查询结果";
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //打开form2,如光标选中了dataGridView1的某项，则将其内容传递到form2
            Form2 myform = new Form2();
            myform.ShowDialog(this);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    if (dataGridView1.SelectedRows[0].Cells[5].Value != null)
                    {
                        string[] str_ss= { dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), dataGridView1.SelectedRows[i].Cells[2].Value.ToString(), dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), dataGridView1.SelectedRows[i].Cells[4].Value.ToString(), dataGridView1.SelectedRows[i].Cells[5].Value.ToString(),dataGridView1.SelectedRows[i].Cells[7].Value.ToString() };
                        Form3 myform = new Form3();
                        myform.stf = new storeFur(str_ss);
                        myform.targetXML = label1.Text;
                        myform.ShowDialog(this);
                       
                    }
                }
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)//导入
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string str1 = ofd.FileName;
        }

        private void button6_Click(object sender, EventArgs e)//导出
        {
            //选择导出文件路径及名称
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "报表类型|*.txt";
            sfd.DefaultExt = "txt";
            sfd.Title = label1.Text;
            sfd.ShowDialog();   
            string str1 = sfd.FileName;
            if (str1 != "")
            {
                //利用FileWriter写入txt
                FileStream fs = new FileStream(str1, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);

                ArrayList al = cx.searchAllNode("mainStore.xml", "store");
                if (al.Count > 0)
                {
                    sw.WriteLine("品种".PadRight(8)+ "型号".PadRight(8)+ "进价".PadRight(8)+ "标价".PadRight(8)+ "出货价".PadRight(8)+ "编号".PadRight(8)+ "数目".PadRight(8));
                    for (int i = 0; i < al.Count; i++)
                    {
                        storeFur stf1 = new storeFur();
                        stf1 = al[i] as storeFur;
                        stf1.ziBuqi();
                        sw.WriteLine(stf1.variety + stf1.number + stf1.inprice + stf1.onprice + stf1.outprice + stf1.date + " " + stf1.shumu);
                    }
                }
                sw.Close();
            }
            
         }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog(this);
        }

        private void 使用帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 当前库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRefresh("mainStore.xml", "store");
        }

        private void 进货记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRefresh("jinHuo.xml","inhere");
        }

        private void 出货记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formRefresh("chuHuo.xml", "outhere");
        }
        public void noResultWarning()
        {
            dataGridView1.Rows.Clear();
            MessageBox.Show("无匹配结果");
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 进出货操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void 出货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void 更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void 导入txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void 导出txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void 进货状况导出txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //选择导出文件路径及名称
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "报表类型|*.txt";
            sfd.DefaultExt = "txt";
            sfd.Title = label1.Text;
            sfd.ShowDialog();
            string str1 = sfd.FileName;
            if (str1 != "")
            {
                //利用FileWriter写入txt
                FileStream fs = new FileStream(str1, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);

                ArrayList al = cx.searchAllNode("jinHuo.xml", "inhere");


                if (al.Count > 0)
                {
                    sw.WriteLine("品种".PadRight(8)+ "型号".PadRight(8)+ "进价".PadRight(8)+ "标价".PadRight(8)+ "出货价".PadRight(8)+ "编号".PadRight(8)+ "数目".PadRight(8));
                    for (int i = 0; i < al.Count; i++)
                    {
                        storeFur stf1 = new storeFur();
                        stf1 = al[i] as storeFur;
                        stf1.ziBuqi();
                        sw.WriteLine(stf1.variety + stf1.number + stf1.inprice + stf1.onprice + stf1.outprice + stf1.date + " " + stf1.shumu);

                    }
                }
                sw.Close();
            }
        }

        private void 导出txt出货状况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //选择导出文件路径及名称
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = label1.Text;
            sfd.Filter = "报表类型|*.txt";
            sfd.DefaultExt = "txt";
            sfd.ShowDialog();
            string str1 = sfd.FileName;
            if (str1 != "")
            {
                //利用FileWriter写入txt
                FileStream fs = new FileStream(str1, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);

                ArrayList al = cx.searchAllNode("chuHuo.xml", "outhere");


                if (al.Count > 0)
                {
                    sw.WriteLine("品种".PadRight(8)+ "型号".PadRight(8)+ "进价".PadRight(8)+ "标价".PadRight(8)+ "出货价".PadRight(8)+ "编号".PadRight(8)+ "数目".PadRight(8));
                    for (int i = 0; i < al.Count; i++)
                    {
                        storeFur stf1 = new storeFur();
                        stf1 = al[i] as storeFur;
                        stf1.ziBuqi();
                        sw.WriteLine(stf1.variety + stf1.number + stf1.inprice + stf1.onprice + stf1.outprice + stf1.date + " " + stf1.shumu);

                    }
                }
                sw.Close();
            }
        }

        private void 利润情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
