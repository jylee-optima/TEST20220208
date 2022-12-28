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

namespace ArrayAndListTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ppath = @"D:\GD\Test\ExportFolderMainPc\GD\XXXX0305 - Copy.000";

            IEnumerable<string> line = null;
            List<string> line2 = new List<string>();
            
            if(File.Exists(ppath))
            {
                bool isEndPointInclude;
                line2 = File.ReadLines(ppath).ToList<string>();
                var line3 = File.ReadLines(ppath); //.Where(linea => !(isEndPointInclude = linea.Contains("EndOfFile;")));

                File.Delete(ppath);
            }
            

            var aaa = line.ToArray<string>();
            line = null;

            MessageBox.Show("DKDKDK");


        }

        private void button2_Click(object sender, EventArgs e)
        {

            List<string> line2 = new List<string>();
            line2.Add("aaa");
            line2.Add("bbb");
            line2.Add("ccc");
            
            var result = line2.FindAll(x => x.IndexOf("a") >= 0 || x.IndexOf("b") >= 0);



        }
    }
}
