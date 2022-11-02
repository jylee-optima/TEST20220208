using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Form1 frm1;
        public Form2(Form1 _frm1)
        {
            InitializeComponent();

            frm1 = _frm1;

            frm1.TestEvent += eventtest;
        }

        private void eventtest(object sender, EventArgs e)
        {
            int ii = 0;
            while (true)
            {
                //ii = "dddd";
                throw new Exception("dddd");
            }
        }


        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        private const int WM_PAINT = 0x0f;
        private const int WM_SETFONT = 0x30;
        private const int WM_FONTCHANGE = 0x1d;
        private const int WM_ACTIVATEAPP = 0x001C;
        private System.Drawing.Bitmap buffer;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_ACTIVATEAPP)
            {
                string aaa;
                aaa = "!";
                //  timer1.Start();
            }


            base.WndProc(ref m);
        }
    }
}
