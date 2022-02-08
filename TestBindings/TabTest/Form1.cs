using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabTest
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();



            //tabControl1.ItemSize = new Size(1, 1);


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();


            frm2.SetTextbox2("시작");

        }
    }
}
