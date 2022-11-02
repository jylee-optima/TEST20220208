using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {

            
            InitializeComponent();


            //base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//중요합니다.
            //base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);//중요합니다.
            //base.SetStyle(ControlStyles.UserPaint, true);//중요합니다.

            //base.SetStyle(ControlStyles.Selectable | ControlStyles.FixedHeight, false);

            //base.SetStyle(ControlStyles.ResizeRedraw, true);

            //this.TabStop = false;

            //this.BackColor = Color.Transparent;//중요합니다.

            


        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams CP = base.CreateParams;
        //        CP.ExStyle = CP.ExStyle | 0x02000000;
        //        return CP;
        //    }
        //}

        

        private void AfterLoading(object sender, EventArgs e)
        {
            
             Save_ScreenDump("C:\\Optima\\History\\ScreenDump", DateTime.Now.ToString("yyMMdd_HHmmss_fff") + ".jpg");
        }


        private void Form3_Load(object sender, EventArgs e)
        {
           // timer1.Start();
            //  fn_LogWrite("------------------------------");
               this.Activated += AfterLoading;
               
        }


        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    base.OnPaintBackground(e);

        //    //Save_ScreenDump("C:\\Optima\\History\\ScreenDump", DateTime.Now.ToString("yyMMdd_HHmmss_fff") + ".jpg");
        //}

        //protected override void OnActivated(EventArgs e)
        //{
        //    base.OnActivated(e);
        //}

        //protected override void OnBackgroundImageLayoutChanged(EventArgs e)
        //{
        //    base.OnBackgroundImageLayoutChanged(e);
        //}



        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);
            //fn_LogWrite(m.Msg.ToString());


            //if (m.Msg.ToString().Equals("799"))
            //{
            //    Save_ScreenDump("C:\\Optima\\History\\ScreenDump", DateTime.Now.ToString("yyMMdd_HHmmss_fff") + ".jpg");
            //}


            //if (m.Msg.ToString().Equals("134"))
            //{
            //    cnt++;
            //    if (isSw == false)
            //    {
            //        if(cnt == 2)
            //        {
            //            Save_ScreenDump("C:\\Optima\\History\\ScreenDump", DateTime.Now.ToString("yyMMdd_HHmmss_fff") + ".jpg");
            //        }

            //        isSw = true;
            //        cnt = 3;
            //    }
            //    else
            //    {
            //        isSw = false;
            //    }
            //}

        }


        public static void Save_ScreenDump(string path, string filename)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Rectangle rect = Screen.PrimaryScreen.Bounds;

            //Get Primary Screem Info
            // 2nd screen = Screen.AllScreens[1]

            //Get Pixel Info (Optional)
            int bitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
            if (bitsPerPixel <= 16)
            {
                pixelFormat = PixelFormat.Format16bppRgb565;
            }
            if (bitsPerPixel == 24)
            {
                pixelFormat = PixelFormat.Format24bppRgb;
            }

            // Create a bitmap of the appropriate size to receive the full-screen screenshot.
            using (Bitmap bmp = new Bitmap(rect.Width, rect.Height, pixelFormat))
            {
                using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp))
                {
                    gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
                }

                try
                {
                    bmp.Save(Path.Combine(path, filename), ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void fn_LogWrite(string str)
        {
            string DirPath = "C:\\Log";
            string FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("MMdd") + ".log";
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fn_LogWrite(this.Opacity.ToString());

        }
    }
}
