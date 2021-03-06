﻿using System;
using System.Collections;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox3.Text = "0";
            textBox3_1.Text = "999999";

            textBox4.Text = "0";
            textBox4_1.Text = "999999";

            textBox5.Text = "0";
            textBox5_1.Text = "999999";

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true; textBox3_1.ReadOnly = true;
            textBox4.ReadOnly = true; textBox4_1.ReadOnly = true;
            textBox5.ReadOnly = true; textBox5_1.ReadOnly = true;

            comboBox1.Text = "库存状况";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.ReadOnly = false;
            }
            else
            {
                textBox1.ReadOnly = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.ReadOnly = false;
            }
            else
            {
                textBox2.ReadOnly = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox3.ReadOnly = false; textBox3_1.ReadOnly = false;
            }
            else
            {
                textBox3.ReadOnly = true; textBox3_1.ReadOnly = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox4.ReadOnly = false; textBox4_1.ReadOnly = false;
            }
            else
            {
                textBox4.ReadOnly = true; textBox4_1.ReadOnly = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox5.ReadOnly = false; textBox5_1.ReadOnly = false;
            }
            else
            {
                textBox5.ReadOnly = true; textBox5_1.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                float.Parse(textBox3.Text);
                float.Parse(textBox4.Text);
                float.Parse(textBox5.Text);

                float.Parse(textBox3_1.Text);
                float.Parse(textBox4_1.Text);
                float.Parse(textBox5_1.Text);

            }
            catch
            {
                MessageBox.Show("价格必须是一个数字");
                return;
            }

            //得到匹配字符串
            string[] str_pipei = new string[8];
            if (checkBox1.Checked == true)
                str_pipei[0] = textBox1.Text.ToString();
            else
                str_pipei[0] = "strnouse";

            if (checkBox2.Checked == true)
                str_pipei[1] = textBox2.Text.ToString();
            else
                str_pipei[1] = "strnouse";

            if (checkBox3.Checked == true)
            {
                str_pipei[2] = textBox3.Text.ToString();
                str_pipei[3] = textBox3_1.Text.ToString();
            }
            else
                str_pipei[2] = "strnouse";

            if (checkBox4.Checked == true)
            {
                str_pipei[4] = textBox4.Text.ToString();
                str_pipei[5] = textBox4_1.Text.ToString();
            }
            else
                str_pipei[4] = "strnouse";

            if (checkBox5.Checked == true)
            {
                str_pipei[6] = textBox5.Text.ToString();
                str_pipei[7] = textBox5_1.Text.ToString();
            }
            else
                str_pipei[6] = "strnouse";

            //取得xml中的值,进行匹配
            {
                cmdXML cx = new cmdXML();
                ArrayList al;
                switch (comboBox1.Text)
                {
                    case "库存状况":
                        al = cx.searchAllNode("mainStore.xml", "store");
                        break;
                    case "进货记录":
                        al = cx.searchAllNode("jinHuo.xml", "inhere");
                        break;
                    case "出货记录":
                        al = cx.searchAllNode("chuHuo.xml", "outhere");
                        break;
                    default:
                        al = new ArrayList();
                        break;
                }
                
                if (al.Count > 0)
                {
                    int i = 0;
                    while (i < al.Count)
                    {
                        storeFur stf = al[i] as storeFur;
                        if (pipeiStore(stf, str_pipei))
                        {
                            i++;
                        }
                        else
                        {
                            al.RemoveAt(i);
                        }
                    }

                }
            
            //书写匹配结果xml,如无结果，主对话框datagridview清空，且弹出消息框
            
                cmdXML cx1 = new cmdXML();
                
                if (al.Count == 0)
                {
                    //告诉主对话框进行刷新
                    Form1 f1 = (Form1)this.Owner;
                    f1.noResultWarning();
                }
                else
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        storeFur stf1 = new storeFur();
                        stf1 = al[i] as storeFur;
                        cx1.AddFurElement("chaXun.xml", stf1, "result");
                    }
                    {
                        //告诉主对话框进行刷新
                        Form1 f1 = (Form1)this.Owner;
                        f1.formRefresh("chaXun.xml", "result");
                        
                        
                    }
                }
                {
                    cmdXML cx2 = new cmdXML();
                    cx2.deleteAllNode("chaXun.xml", "result");
                    this.Close();
                }
            }
            
        }
        //查询定义匹配函数
        public bool pipeiStore(storeFur stf, string[] str)
        {
            //满足所有匹配项目返回true,否则返回false
            if ((stf.variety == str[0] || str[0] == "strnouse")
                && (stf.number == str[1] || str[1] == "strnouse")
                && ((str[2] == "strnouse")
                ||((float.Parse(stf.inprice) >= float.Parse(str[2]))
                && (float.Parse(stf.inprice) <= float.Parse(str[3]))))
                && ((str[4] == "strnouse")
                ||((float.Parse(stf.onprice) >= float.Parse(str[4]))
                && (float.Parse(stf.onprice) <= float.Parse(str[5]))))
                && ((str[6] == "strnouse")
                ||((float.Parse(stf.outprice) >= float.Parse(str[6])) 
                && (float.Parse(stf.outprice) <= float.Parse(str[7]))))
                )
            {
                return true;
           
            }
            else
            {
                return false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
