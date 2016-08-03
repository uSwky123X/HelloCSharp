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

namespace HelloCSharp
{
    public partial class Compile : Form
    {
        public Compile()
        {
            InitializeComponent();
        }

        private void Compile_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = File.ReadAllText(@"CSharp\log");
        }
    }
}
