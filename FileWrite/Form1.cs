using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.Drawing.Text;
using System.Collections;
using System.IO;


namespace FileWrite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //窗口改变事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //在Label写入*
            toolStripLabelMake.Text = "*";
        }
        //打开文本文件
        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            //设置文档类型
            openFileDialog1.Filter = ("文本文档(*.txt)|*.txt");
            //判断打开按键是否按下
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文档路径
                string path = openFileDialog1.FileName;
                //通用编码UTF8
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                //读取文档的数据流
                string text = sr.ReadToEnd();
                //输出文档
                textBoxNote.Text = text;
                //将路径写入窗口text
                this.Text = path;
                //清空计号
                toolStripLabelMake.Text = "";
                //清理缓存
                sr.Close();

            }
           
        }
        //新建文件夹
        private void toolStripButtonNewFile_Click(object sender, EventArgs e)
        {
            //判断新建文件夹按键
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //读取文件夹地址
                string path = folderBrowserDialog1.SelectedPath;
                //新建文件夹
                Directory.CreateDirectory(path);
            }
            
        }
        //保存文档文件
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            //判断文本内容是否为空
            if(textBoxNote.Text.Trim() != "")
            {   //判断窗口text是否为空
                if (this.Text == "")
                {   //文档类型
                    saveFileDialog1.Filter = ("文本文档(*.txt)|*.txt");
                    //判断是否按下
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {   //获取保存地址
                        string path = saveFileDialog1.FileName;
                        //保存到指定路径
                        StreamWriter sw = new StreamWriter(path, false);
                        sw.WriteLine(textBoxNote.Text.Trim());
                        this.Text = path;
                        toolStripLabelMake.Text = "";
                        sw.Close();

                    }
                }
                //已经打开的文档直接保存
                else
                {  
                    string path = saveFileDialog1.FileName;
                    path = this.Text;
                    StreamWriter sw = new StreamWriter(path, false);
                    sw.WriteLine(textBoxNote.Text.Trim());
                    toolStripLabelMake.Text = "";
                    sw.Close();
                }
                
               
            }
            
           
        }
        //删除文件文档
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.Filter = ("文本文档(*.txt)|*.txt");
            openFileDialog1.Title = "删除";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                File.Delete(path);
            
            }
        }
        //新建文件文档
        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            textBoxNote.Text = "";
            toolStripLabelMake.Text = "";
            this.Text = "";
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        //未保存退出判断
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toolStripLabelMake.Text == "*")
            {
                DialogResult dr = MessageBox.Show("文本未保存，确认退出吗？", "信息质询",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    this.Dispose();
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }

        private void toolStripLabelMake_Click(object sender, EventArgs e)
        {

        }
        //另存为
        private void toolStripButtonElseSave_Click(object sender, EventArgs e)
        {
            if (textBoxNote.Text.Trim() != "")
            {
                saveFileDialog1.Filter = ("文本文档(*.txt)|*.txt");
                //判断是否按下
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {   //获取保存地址
                    string path = saveFileDialog1.FileName;
                    //保存到指定路径
                    StreamWriter sw = new StreamWriter(path, false);
                    sw.WriteLine(textBoxNote.Text.Trim());
                    this.Text = path;
                    toolStripLabelMake.Text = "";
                    sw.Close();

                }
            }
        }
    }
}
