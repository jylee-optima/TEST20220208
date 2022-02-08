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

namespace 람다
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            
            list.Add("a");
            list.Add("p");
            list.Add("p");
            list.Add("l");
            list.Add("e");

            list.Sort((x, y) => x.CompareTo(y));

            foreach (var _list in list)
            {
                MessageBox.Show(_list);

            }
        }
    }
}
