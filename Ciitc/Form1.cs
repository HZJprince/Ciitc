using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Ciitc
{
    public partial class Form1 : Form
    {
        static int count = 0;
        xmlctl xml = new xmlctl();
        static int radio = 0;
        public Form1()
        {
            InitializeComponent();
            //backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择文件";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true && textBox1.Text != "")
            {
                backgroundWorker1.RunWorkerAsync();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            else if (backgroundWorker1.IsBusy != true && textBox1.Text == "")
            {
                MessageBox.Show("请先点击“浏览”按钮输入XML文件");
                return;
            }
            else
            {
                MessageBox.Show("导入程序正在执行，请不要重复点击!");
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (radioButton1.Checked == true)
            {
                sql = "select * from CX where QUERY_SEQUENCE_NO in " +
                         "(select QUERY_SEQUENCE_NO from CX group by QUERY_SEQUENCE_NO having count(*) > 1)" +
                         "order by QUERY_SEQUENCE_NO";
            }
            else if(radioButton2.Checked == true)
            {
                sql = "select * from QD where CONFIRMSEQUENCE_NO in " +
                         "(select CONFIRMSEQUENCE_NO from QD group by CONFIRMSEQUENCE_NO having count(*) > 1)" +
                         "order by CONFIRMSEQUENCE_NO";
            }
            SQLHelper sqlh = new SQLHelper();
            DataTable dt = sqlh.ExecuteDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有重复记录");
            }
            bindingSource1.DataSource = dt;
            dataGridView1.DataSource = bindingSource1;
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radio = 1;
            }
            else
            {
                radio = 0;
            }
            e.Result = xml.xml(textBox1.Text,count,backgroundWorker1,radio);
        }

        private void backgroundWorker1_ProgressChanged(object sender,ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.Equals(false))
            {
                label1.Text = "导入出错";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                count = 0;
                MessageBox.Show("导入出错");
            }
            else
            {
                label1.Text = "导入完成";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                count = 0;
                MessageBox.Show("导入完成");
            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true && backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                radioButton2.Enabled = false;
                radioButton1.Enabled = false;
                label1.Text = "正在删除数据";
            }
            else
            {
                MessageBox.Show("其他进程正在运行，暂时不能操作！");
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radio = 1;
            }
            else
            {
                radio = 0;
            }
            e.Result = xml.yml(radio);
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.Equals(false))
            {
                label1.Text = "清除出错";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                MessageBox.Show("清除出错");
            }
            else
            {
                label1.Text = "清除完成";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                MessageBox.Show("清除完成");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (radioButton1.Checked == true)
            {
                sql = "select * from CX where QUERY_SEQUENCE_NO = '' ";
            }
            else if (radioButton2.Checked == true)
            {
                sql = "select * from QD where CONFIRMSEQUENCE_NO = '' ";
            }
            SQLHelper sqlh = new SQLHelper();
            DataTable dt = sqlh.ExecuteDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有相关记录");
            }
            bindingSource1.DataSource = dt;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
