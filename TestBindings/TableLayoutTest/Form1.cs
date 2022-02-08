using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Linq;

namespace TableLayoutTest
{
    public partial class Form1 : Form
    {
        public const string cultureInfo_en = "en-US";
        public const string cultureInfo_ko = "ko-KR";
        public const string cultureInfo_ja = "ja-JP";
        public const string cultureInfo_zh = "zh-CN";

        private int beforeindex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         

            label1.Parent = pic1.pictureBox1;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(-100, 0);


            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureInfo_ja);

            //foreach (Control c in this.Controls)
            //    if (c is Button)
            //        c.Visible = false;

            //beforeindex = 1;
            //comboBox1.SelectedIndex = beforeindex;


            //IDictionary<Type, Type> reg = null;
            //reg.Add(typeof(Test1), typeof(Test1));
            //reg.Add(typeof(Test2), typeof(Test2));

            //Type myType = typeof(Test1);
            //var ctor = reg[myType].GetConstructors()



            //var ctor2 = typeof(Test1).GetConstructors().FirstOrDefault(c => c.GetParameters().Length > 0);


            //var service = ctor2.Invoke(

            //    ctor2.GetParameters()

            //    )


            inif aa;

            Test1 ttt = new Test1();

            aa = ttt;

            abc();


            object abc ()
            {
                return "A";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                throw new InvalidCastException();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            if(MessageBox.Show("run?","runtest",MessageBoxButtons.OKCancel) == DialogResult.OK )
            {
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MessageBox.Show(beforeindex.ToString());
            beforeindex = comboBox1.SelectedIndex;
            MessageBox.Show(beforeindex.ToString());


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("1:" + comboBox1.SelectedIndex.ToString());
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.Text);
        }

        private void comboBox1_EnabledChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show("enable");
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           

        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedIndex.ToString());

        }
    }


    public class Test1 : inif
    {
        
        public Test1()
        {

        }

        public Test1(string a, int b)
        {

        }

        public void abc()
        {
            throw new NotImplementedException();
        }
    }

    public class Test2
    {
        public Test2()
        {


        }

        public Test2(int a)
        {

        }
    }

    interface inif
    {
        void abc();
    }

}
