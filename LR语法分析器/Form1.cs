using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LR语法分析器
{
    public partial class Form1 : Form
    {
        string sourceFileName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Clear();textBox2.Clear();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;     //一次只能选取一个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "文本文件文件（*.txt）|*.txt|word文件（*.doc）|*.doc";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sourceFileName = dialog.FileName;
                
            }
            if (sourceFileName != "")
            {
                string[] lines = File.ReadAllLines(sourceFileName);
                // 在textBox1中显示文件内容
                foreach (string line in lines)
                {
                    string str = line + Environment.NewLine;
                    textBox1.AppendText(str);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(sourceFileName!="")
            {
                syntax syt = new syntax(sourceFileName);

                textBox2.Text = syt.starting();
            }
            else
            {
                //出错处理
            }
        }
    }
}
