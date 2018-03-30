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
        int form4_back;
        public Form1()
        {
            InitializeComponent();
            //并打开一个xml文件，如不存在，则创建之
            xh = new XmlHelper();
            cx = new cmdXML();
            string pathname = "mainStore.xml";
            xh.CreateXML(pathname);
            //以十条为单位，查询其内容并显示在dataGridView1上
            this.dataGridView1.Columns.Add(@"variety",@"品种");
            this.dataGridView1.Columns.Add(@"number", @"型号");
            this.dataGridView1.Columns.Add(@"inprice", @"进价");
            this.dataGridView1.Columns.Add(@"onprice", @"货场标价");
            this.dataGridView1.Columns.Add(@"outprice", @"实际出货价");
            this.dataGridView1.Columns.Add(@"date",@"日期");
            //不允许用户编辑datagridview中的数据
            this.dataGridView1.ReadOnly = true;


            //refresh
            formRefresh();
            


        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            //datagridview自适应
            dataGridView1.AutoResizeColumns();
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
                        string str_s = dataGridView1.SelectedRows[i].Cells[5].Value.ToString();
                        cx.deleteSingleNode("mainStore.xml", "/store", str_s);
                    }
                }
            }
            this.formRefresh();
        }
       
       
        //将数据库中的数据刷新到datagridview上
        public void formRefresh()
        {
            
            //通过mainstore.xml刷新datagridview的值
            ArrayList al = cx.searchAllNode("mainStore.xml", "/store");
           
            dataGridView1.Rows.Clear();
            if (al.Count > 0)
            {
                dataGridView1.Rows.Add(al.Count);
                for (int i = 0; i < al.Count; i++)
                {
                    storeFur stf1 = new storeFur();
                    stf1 = al[i] as storeFur;
                    dataGridView1.Rows[i].Cells[0].Value = stf1.variety;
                    dataGridView1.Rows[i].Cells[1].Value = stf1.number;
                    dataGridView1.Rows[i].Cells[2].Value = stf1.inprice;
                    dataGridView1.Rows[i].Cells[3].Value = stf1.onprice;
                    dataGridView1.Rows[i].Cells[4].Value = stf1.outprice;
                    dataGridView1.Rows[i].Cells[5].Value = stf1.date;
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
                        string[] str_ss= { dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), dataGridView1.SelectedRows[i].Cells[2].Value.ToString(), dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), dataGridView1.SelectedRows[i].Cells[4].Value.ToString(), dataGridView1.SelectedRows[i].Cells[5].Value.ToString() };
                        Form3 myform = new Form3();
                        myform.stf = new storeFur(str_ss);
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
            sfd.ShowDialog();   
            string str1 = sfd.FileName;

            //利用FileWriter写入txt
            FileStream fs = new FileStream(str1, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            ArrayList al = cx.searchAllNode("mainStore.xml", "/store");

            
            if (al.Count > 0)
            {
                
                for (int i = 0; i < al.Count; i++)
                {
                    storeFur stf1 = new storeFur();
                    stf1 = al[i] as storeFur;
                    sw.WriteLine(stf1.variety+" "+stf1.number+" "+stf1.inprice+" "+stf1.onprice+" "+stf1.outprice+" "+stf1.date);
                 
                }
            }
            sw.Close();
         }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog(this);
        }
    }
}
