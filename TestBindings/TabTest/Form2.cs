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
    public partial class Form2 : Form
    {
        System.Threading.Timer _timer;

        public Form2()
        {
            InitializeComponent();


            _timer = new System.Threading.Timer(Timer_Tick, null, 0, 10000);



        }

        private void Timer_Tick(object state)
        {
            //this.textBox1.Text = DateTime.Now.ToString();

            SetTextbox2("시시작");
        }

        public void SetTextbox2(string str)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(

                    (System.Action)(() => { this.textBox2.Text = str; })

                    );
                
            }
            else
            {
                textBox2.Text = str;
            }
            

        }
    }
}
