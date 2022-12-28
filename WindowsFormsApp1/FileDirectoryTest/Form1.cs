using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDirectoryTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\aaa");
            FileInfo[] files = dir.GetFiles("*.log1", SearchOption.AllDirectories);

            MessageBox.Show(files[0].FullName);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete(@"D:\aa.txt");
        }
    }
}
