using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VirtualTest
{
    public class virtualClass
    {
        public delegate void daaa(string s);
        public event daaa chainEvent1;
        public event daaa chainEvent2;
        public virtual void ShowMsg()
        {
            chainEvent1 += print1;
            chainEvent2 += print2;
            chainEvent1 += chainEvent2;
            

            chainEvent1.Invoke("이벤트1");
            chainEvent2.Invoke("이벤트2");



        }

        public void print1(string a)
        {
            MessageBox.Show(a);
        }

        public void print2(string b)
        {
            MessageBox.Show(b);
        }


    }


    public class virtualClassMain : virtualClass
    {

        public override void ShowMsg()
        {
            
            base.ShowMsg();
        }

    }
}
