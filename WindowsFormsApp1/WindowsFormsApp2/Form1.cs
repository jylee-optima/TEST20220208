using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public event EventHandler MenuBtnClickEvent;


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private string _teststr;
        private string teststr
        {
            get => _teststr;
        }

        Traffic traffic;
        Thread v;
        Thread h;
        public Form1()
        {
            InitializeComponent();
        }

        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                //else
                //    Debug.Fail(msg);
            }
        }
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        public void NotifyPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _B;

        private string B
        {
            get => _B;
            set
            {
                NotifyPropertyChanged(nameof(B));
            }

        }

        private string A;

        private async void isttt()
        {
            await Task.Delay(5000);

            Task.Delay(5000).Wait();

        }



        private void button1_Click(object sender, EventArgs e)
        {


            //tabControl1.Size.Width = 10;


            // Checking the version using >= enables forward compatibility.
            string CheckFor45PlusVersion(int releaseKey)
            {
                if (releaseKey >= 528040)
                    return "4.8 or later";
                if (releaseKey >= 461808)
                    return "4.7.2";
                if (releaseKey >= 461308)
                    return "4.7.1";
                if (releaseKey >= 460798)
                    return "4.7";
                if (releaseKey >= 394802)
                    return "4.6.2";
                if (releaseKey >= 394254)
                    return "4.6.1";
                if (releaseKey >= 393295)
                    return "4.6";
                if (releaseKey >= 379893)
                    return "4.5.2";
                if (releaseKey >= 378675)
                    return "4.5.1";
                if (releaseKey >= 378389)
                    return "4.5";
                // This code should never execute. A non-null release key should mean
                // that 4.5 or later is installed.
                return "No 4.5 or later version detected";
            }


            Student A = presenter.student();
            Student B = presenter.student();







            DataTable dt = new DataTable();

            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");


            DataRow row = dt.NewRow();

            row[0] = "AAA";
            row[1] = "BBB";
            row["C"] = "CCC";


            dt.Rows.Add(row);

            DataRow row2 = dt.NewRow();
            row2[0] = "AAA1";
            row2[1] = "BBB2";
            row2["C"] = "CCC3";

            dt.Rows.Add(row2);


            MessageBox.Show(dt.Rows[1][0].ToString());
            return;






            int cnt = 0;
            double ccnt = 100;


            ccnt = cnt;
            ccnt = cnt;







            // Task.Run(  async () =>
            //{
            //    await isttt();


            //}).Wait();


            // MessageBox.Show("end");
            // return;




            return;






            //tabControl1.TabPages.Clear();

            //tabControl1.TabPages.Add("ddd");
            //tabControl1.TabPages.Add("aaa");

            return;


            StringBuilder Name = new StringBuilder();

            int result = GetPrivateProfileString("Height99", "Isis_X_Axis", "", Name, 32, "D:\\GD\\Data\\T_1_2_13367_12943_HT\\1_2_13367_12943_Result.csv");





            string sss = "";
            char ch = '0';

            float fss;


            fss = float.Parse(sss.ToString().PadLeft(1, ch));






            //int cnt = 0;

            MessageBox.Show(cnt++.ToString());

            MessageBox.Show(cnt++.ToString());

            MessageBox.Show(cnt++.ToString());






            try
            {
                string path = "C:\\App.UI.log";
                string npath = "\\\\192.168.1.10\\aaa.txt";
                string path3 = "\\\\192.168.0.27\\Test\\1_6_2216_16049_HT1_LineChart1.bmp";

                //                var file = File.OpenRead(npath);

                if (!File.Exists(npath))
                {
                    MessageBox.Show("dd");
                }
                var file2 = File.Open(npath, FileMode.Open);


                //if (File.OpenRead(path3))
                //{
                //    MessageBox.Show("ddd");
                //}

                if (File.Exists(npath))
                {
                    MessageBox.Show("OK");
                }


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }




            return;



            string[] teststr = new string[] { "C:\\Optima\\Recipe\\11.rcp", "C:\\Optima\\Recipe\\2.rcp", "C:\\Optima\\Recipe\\333a.rcp", "C:\\Optima\\Recipe\\4.rcp", "C:\\Optima\\Recipe\\55555.rcp", "a" };

            var test = (from test1 in teststr
                        where Path.GetFileName(test1.ToString()).Replace(".rcp", "").Length <= 2
                           && Regex.IsMatch(Path.GetFileName(test1.ToString()).Replace(".rcp", ""), @"^[0-9]+$") == true
                        select test1);





            //Action ac = new Action(test);

            //ac.Method.Name.ToString();


            //traffic.ProcessVertical();
        }
        private void test()
        {
            //Task.Delay(1000).Wait();
            MessageBox.Show("b");
        }

        
        private void clickTest(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Click += MenuBtnClickEvent;

            MenuBtnClickEvent += clickTest;



            UserControl1 ucr1 = new UserControl1();
            UserControl2 ucr2 = new UserControl2();
            UserControl1 ucr3 = new UserControl1();
            UserControl2 ucr4 = new UserControl2();

            TabPage page3 = new TabPage("p3");
            TabPage page4 = new TabPage("p4");

            page3.Controls.Add(ucr3);
            page4.Controls.Add(ucr4);

            tabControl1.TabPages.Add(page3);
            tabControl1.TabPages.Add(page4);

            //tabControl1.TabPages[0].Controls.Add(ucr1);
            //tabControl1.TabPages[1].Controls.Add(ucr2);


            //cpanel.Opacity = 70;
            //cpanel.BringToFront();


            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            return;
            BlockingCollection<Action> _EventQueue = new BlockingCollection<Action>();

            Action action1;
            Action action2;

            Task.Run(() =>
            {
                action1 = _EventQueue.Take();
                MessageBox.Show("action1");
            });

            Task.Run(() =>
            {
                action2 = _EventQueue.Take();
                MessageBox.Show("action2");
            });

            _EventQueue.Add(

                new Action(() =>
               {

               })

                );

            while (true)
            {

            }
            //var action = _EventQueue.Take();
            traffic = new Traffic();

            // 2개의 쓰레드 구동
            v = new Thread(traffic.ProcessVertical);
            h = new Thread(traffic.ProcessHorizontal);
            v.Start();
            h.Start();


            //while (true)
            //{
            //    Task.Delay(1000);
            //}


            //// 메인쓰레드에서 데이타 전송
            //for (int i = 0; i < 30; i += 3)
            //{
            //    traffic.AddVertical(new int[] { i, i + 1, i + 2 });
            //    traffic.AddHorizontal(new int[] { i, i + 1, i + 2 });
            //    Thread.Sleep(10);
            //}

            //Thread.Sleep(1000);
            //traffic.Running = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            traffic.ProcessHorizontal();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {

        }
        private void settext()
        {

            if(InvokeRequired)
            {
                Invoke((MethodInvoker)delegate() { settext(); });
            }
            else
            {
                textBox1.Text = "dd";

            }

        }
        enum PeopleName
        {
            Name1 = 1,
            Name2 = 2
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            List<string> list = new List<string>();

            list.Add("aaa");
            list.Add("bbb");
            list.Insert(0, "ccc");


            List<Tuple<int, string>> newtuple = new List<Tuple<int, string>>() { new Tuple<int, string>(1,"1"),
                                                                                 new Tuple<int, string>(2,"2"),
                                                                                };


            Dictionary<int, string> dicTest = new Dictionary<int, string>
            {
                {1,"1" },
                {2,"2" },
                {3,"3" },
                {3,"4" }
            };

            string tt;
            dicTest.TryGetValue(1, out tt);


            
            var di = dicTest.Where(x => x.Key == 3);


            var aaa = newtuple.Where(x => x.Item1 == 1);

            return;
            string aa = Path.Combine("C:\\", "ABC", ".rcp");

            MessageBox.Show(((int)PeopleName.Name1).ToString());



            var task = Task.Run(() =>
            {
                settext();
            });

            while(!task.IsCompleted)
            {
             //   return;
            }


            return;


            textBox1.Text = "dd";

            return;



            Student st = presenter.student();

            MessageBox.Show(st.aName);

            Student st2 = presenter.student();

            MessageBox.Show(st2.aName);


            MessageBox.Show(st.aName);
            MessageBox.Show(st2.aName);

        }

        private Bitmap pointtest()
        {
            Student student = new Student("str");

            student = null;

            return student?.bitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point apoint = new Point(10, 10);
            //cpanel.Location = apoint;

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            //this.cpanel.BackColor = Color.Black;
            //this.cpanel.Location = new Point(10, 10);
            //this.cpanel.Size = new Size(100, 100);
            //this.cpanel.Opacity = 70;
            //panel2.Parent = this;


            //this.panel2.BringToFront();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, SystemColors.ActiveBorder, ButtonBorderStyle.Solid);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            userControl11.Enabled = true;

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(radioButton1.Enabled.ToString());

        }
    }

    public class Student
    {
        public Bitmap bitmap;

        public Student(string name )
        {
            aName = name;
        }
        public string aName;
    }

    public class aPoint
    {
        public aPoint()
        {

        }
    }

    public static class presenter
    {
        public static Student student()
        {

            return new Student(DateTime.Now.ToString());
        }

    }

    public class ClassA
    {
        public string Name = "A";
    }


        

    class Traffic
    {
        private bool _running = true;

        // 상하, 좌우 통행 신호 역활을 하는 AutoResetEvent 이벤트들
        private AutoResetEvent _evtVert = new AutoResetEvent(true);
        private AutoResetEvent _evtHoriz = new AutoResetEvent(false);

        private Queue<int> _Qvert = new Queue<int>();
        private Queue<int> _Qhoriz = new Queue<int>();

        // 상하방향의 큐 데이타 처리
        // Vertical 방향의 처리 신호(_evtVert)를 받으면
        // Vertical 큐의 모든 큐 아이템을 처리하고
        // 좌우방향 처리 신호(_evtHoriz)를 보냄
        public void ProcessVertical()
        {
            Thread.Sleep(5000);
            //while (_running)
            //{
            // Vertical 방향 처리 신호 기다림
            _evtVert.WaitOne();

            // Vertical 큐의 모든 데이타 처리
            // 큐는 다른 쓰레드에서 엑세스 가능하므로 lock을 건다
            lock (_Qvert)
            {
                while (_Qvert.Count > 0)
                {
                    int val = _Qvert.Dequeue();
                    Console.WriteLine("Vertical : {0}", val);
                }
            }

            //while(true)
            //{
            //    Task.Delay(1000);
            //}
            // Horizontal 방향 처리 신호 보냄
            _evtVert.Set();
            // }

            Console.WriteLine("ProcessVertical : Done");
        }

        // 좌우방향의 큐 데이타 처리
        // Horizontal 방향의 처리 신호(_evtHoriz)를 받으면
        // Horizontal 큐의 모든 큐 아이템을 처리하고
        // 상하방향 처리 신호(_evtHoriz)를 보냄
        public void ProcessHorizontal()
        {
            //while (_running)
            //{


            Task.Run(() =>
            {
                _evtVert.WaitOne();

                lock (_Qhoriz)
                {
                    while (_Qhoriz.Count > 0)
                    {
                        int val = _Qhoriz.Dequeue();
                        Console.WriteLine("Horizontal : {0}", val);
                    }
                }
                //while (true)
                //{
                //    Task.Delay(1000);
                //}
                MessageBox.Show("test");
                _evtVert.Set();
            });


            //   }

            Console.WriteLine("ProcessHorizontal : Done");
        }

        public bool Running
        {
            get { return _running; }
            set { _running = value; }
        }

        public void AddVertical(int[] data)
        {
            lock (_Qvert)
            {
                foreach (var item in data)
                {
                    _Qvert.Enqueue(item);
                }
            }
        }

        public void AddHorizontal(int[] data)
        {
            lock (_Qhoriz)
            {
                foreach (var item in data)
                {
                    _Qhoriz.Enqueue(item);
                }
            }
        }
    }

    public static class UiUtil
    {
        public static Control[] GetAllControlsUsingRecursive(Control containerControl)
        {
            List<Control> allControls = new List<Control>();

            foreach (Control control in containerControl.Controls)
            {
                allControls.Add(control);

                if (control.Controls.Count > 0)
                {
                    allControls.AddRange(GetAllControlsUsingRecursive(control));
                }
            }

            return allControls.ToArray();

        }
    }
}
