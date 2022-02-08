using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casting_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TestClass tc = new TestClass();

            tc.GetName2();


            iTestClass tmptc = (iTestClass)tc;

            tmptc.GetName1();

            TestClass tmpClass;

            tmpClass = (TestClass)tmptc;

            tmpClass.GetName1();
            tmpClass.GetName2();
            

        }
    }
}
