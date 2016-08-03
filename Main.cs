using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using System.IO;

namespace HelloCSharp
{
    public partial class Main : Form
    {
        #region 变量
        public Scintilla scintilla = new Scintilla();
        #endregion

        #region 初始化
        public Main()
        {
            #region Scintilla 初始化
            /// <summary>
            /// 初始化代码编辑器 Scintilla
            /// </summary>

            this.scintilla.Dock = DockStyle.Fill;
            this.scintilla.ConfigurationManager.Language = "cs";
            this.scintilla.Margins.Margin1.IsClickable = true;
            this.scintilla.Margins.Margin2.Width = 16;
            this.scintilla.AutoComplete.List.Add("Console");
            this.scintilla.AutoComplete.List.Add("Console.WriteLine");
            ReadSimpleFile();

            #endregion

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(this.scintilla);
        }

        #endregion

        #region 模块

        public void ReadSimpleFile()
        {
            this.scintilla.Text = File.ReadAllText("Console.cs");   
        }

        public bool Save()
        {
            if (String.IsNullOrEmpty(Class.FileName))
                return SaveAs();
            File.WriteAllText(Class.FileName, scintilla.Text);
            return true;
        }

        public bool SaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Class.FileName = this.saveFileDialog1.FileName;
                return Save();
            }
            return true;
        }

        public void Open()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Class.FileName = openFileDialog1.FileName;
                scintilla.Text = File.ReadAllText(openFileDialog1.FileName);
            }

        }

        public bool QuestionSave()
        {
            if (MessageBox.Show("确定？\n\n所有未保存的数据将会丢失。", "信息：", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;
            return false;
        }

        #endregion
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出？\n\n所有没有保存的数据将会丢失。", "信息：", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QuestionSave())
            {
                Open();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QuestionSave())
                scintilla.Text = "";
        }
        
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog()==DialogResult.OK)
            {
                Class.Compile(Class.FileName, saveFileDialog2.FileName);
                Compile form = new Compile();
                form.ShowDialog();
            }
        }
    }
}
