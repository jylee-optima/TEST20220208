using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Optima.Framework.UIComponents.WinForm.Controls;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.IO;
using System.Collections.Concurrent;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;
using System.Reflection;

namespace WindowsFormsApp1
{

        

    public partial class Form1 : Form
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _strText;

        private OptionConfig config;

        public event EventHandler TestEvent;

        public event EventHandler testeventHandler = null;

        private async void ExecSafeLoadCarrier(object p)
        {
            //EventMessage = $"Start [{comd}] Command";
            //OperationResult or = new OperationResult(OperationResult.Success);

            //switch (comd)
            //{
            //    case nameof(ComdInit):
            //        or = await _Efem.LoadPortInit(_LoadPortNo);
            //        break;
            //    case nameof(ComdClamp):
            //        or = await _Efem.LoadPortClamp(_LoadPortNo);
            //        break;
            //    case nameof(ComdUnclamp):
            //        or = await _Efem.LoadPortUnclamp(_LoadPortNo);
            //        break;
            //    case nameof(ComdDock):
            //        or = await _Efem.LoadPortDock(_LoadPortNo);
            //        break;
            //    case nameof(ComdUndock):
            //        or = await _Efem.LoadPortUndock(_LoadPortNo);
            //        break;
            //    case nameof(ComdOpen):
            //        or = await _Efem.LoadPortDoorOpen(_LoadPortNo);
            //        break;
            //    case nameof(ComdClose):
            //        or = await _Efem.LoadPortDoorClose(_LoadPortNo);
            //        break;
            //    case nameof(ComdRead):
            //        or = await _Efem.LoadPortReadCarrierID(_LoadPortNo);
            //        break;
            //    case nameof(ComdSlotMap):
            //        or = await _Efem.LoadPortMap(_LoadPortNo);
            //        break;
            //    case nameof(ComdLoadCarrier):
            //        or = await _System.SafeLoadCarrier(_LoadPortNo, _Efem.LoadPortStatus[_LoadPortNo].CarrierType);
            //        break;
            //    case nameof(ComdUnloadCarrier):
            //        or = await _System.SafeUnloadCarrier(_LoadPortNo);
            //        break;
            //    case nameof(ComdSetCarrierId):
            //        await Task.Delay(100);
            //        break;
            //    case nameof(SetCarrierId):
            //        or = await _System.SetCarrierId(_LoadPortNo, NewCarrierId);
            //        break;
            //    default:
            //        {
            //            EventMessage = $"Failed Command Execution : Unkonwn Command";
            //            return;
            //        }
            //}

            //if (or.Status == OperationalStatus.Error)
            //    EventMessage = $"Failed [{comd}] Command \n\tMessage : {or.Message}\n\tException : {or.Exception}";
            //else
            //    EventMessage = $"Succeeded in [{comd}] Command";
        }




        public string strText
        {
            get { return _strText; }
            set
            {
                _strText = value;
                //textBox1.Text = _strText;
            }
        }


        public Form1()
        {
            //SetStyle(ControlStyles.EnableNotifyMessage, true);
    
            //string path = Path.GetFullPath(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\")) + "logs\\ScreenShot\\";

            ////string path = System.IO.Directory.GetCurrentDirectory();

            ////string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));

            InitializeComponent();

            //base.SetStyle(ControlStyles.OptimizedDoubleBuffer , true);//중요합니다.
            //base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);//중요합니다.
            //base.SetStyle(ControlStyles.UserPaint, true);//중요합니다.

            //base.SetStyle(ControlStyles.Selectable | ControlStyles.FixedHeight, false);

            //base.SetStyle(ControlStyles.ResizeRedraw, true);

            //this.TabStop = false;

            //this.BackColor = Color.Transparent;//중요합니다.

            //this.FormClosing += Form1_Closing;
            // config = new OptionConfig();


            //ConTest ctest = new ConTest();

            //propertyGrid1.DataBindings.Add("SelectedObject", ctest, nameof(ctest.config),true,DataSourceUpdateMode.OnPropertyChanged);

        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            
        }
        protected override void OnNotifyMessage(Message m)
        {
      //      base.OnNotifyMessage(m);
        }

        void Application_Idle()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {


          //  loadpit();



        }

        private async void loadpit()
        {
           // MessageBox.Show("ddd");
        }

        //public void NotifyPropertyChanged(string propertyName)
        //{
        //    this.VerifyPropertyName(propertyName);
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        private void Form1_Load(object sender, EventArgs e)
        {


            //timer1.Interval = 1;
            //timer1.Tick += timer1_Tick;
            //this.SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

        }


   

        private void button1_Click_1(object sender, EventArgs e)
        {


            timer1.Start();




        }

        
        private void testrn()
        {

            

            //var task = new Task(() =>
            //{
            //   using( frm2 = new Form2())
            //   {

            //        frm2.label1.Text = DateTime.Now.ToString();

            //        this.Invoke((Action)(() =>
            //        {
            //            if (frm2.ShowDialog(this) == DialogResult.OK)
            //            {

            //            }
            //        }));
            //    }


            //}, TaskCreationOptions.LongRunning);


           // task.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(this);
            frm2.Show();

        }
        private int RunCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //if(RunCount > 0)
            //{
            //    Save_ScreenDump("C:\\Optima\\History\\ScreenDump", DateTime.Now.ToString("yyMMdd_HHmmss_fff") + ".jpg");
            //    timer1.Stop();
            //}
                

            //RunCount++;

            


            //testrn();
        }


        //[DllImport("user32.dll")]
        //private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        //private const int WM_PAINT = 0x0f;
        //private const int WM_SETFONT = 0x30;
        //private const int WM_FONTCHANGE = 0x1d;
        //private const int WM_ACTIVATEAPP = 0x001C;
        //private System.Drawing.Bitmap buffer;

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_PAINT)
        //    {
        //        RunCount = 0;
        //        //timer1.Stop();
        //        //timer1.Start();
        //    }

        //    //if (m.Msg == 49482)
        //    //{
        //    //  Task.Run(() => { MessageBox.Show("49482"); });
        //    //}

        //    //if (m.Msg == 49959)
        //    //{
        //    //    Task.Run(() => { MessageBox.Show("49959"); });
        //    //}

        //    base.WndProc(ref m);
        //}

        //[Conditional("DEBUG")]
        //[DebuggerStepThrough]
        //public void VerifyPropertyName(string propertyName)
        //{
        //    // Verify that the property name matches a real,  
        //    // public, instance property on this object.
        //    if (TypeDescriptor.GetProperties(this)[propertyName] == null)
        //    {
        //        string msg = "Invalid property name: " + propertyName;

        //        if (this.ThrowOnInvalidPropertyName)
        //            throw new Exception(msg);
        //        else
        //            Debug.Fail(msg);
        //    }
        //}

        //protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

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

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {




            Task.Run(async delegate
            {
                TaskSleep(); //5
                MessageBox.Show("5 - " + Thread.CurrentThread.ManagedThreadId.ToString());
            });


        }

    

        private  async void TaskSleep()
        {
            MessageBox.Show("1 - " + Thread.CurrentThread.ManagedThreadId.ToString());

            await Task.Delay(1000); //6
            //string aaa = await abc();
            //Thread.Sleep(1000);
            MessageBox.Show("3 - " + Thread.CurrentThread.ManagedThreadId.ToString());
            MessageBox.Show("4 - " + Thread.CurrentThread.ManagedThreadId.ToString());

        }

        static async Task<string> abc()
        {
            MessageBox.Show("6 - " + Thread.CurrentThread.ManagedThreadId.ToString());
            return "aaa";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            dataGridView1.Rows.Add("dddd");
            dataGridView1.Rows.Add("bbbb");

        }

        private void Form1_Shown_1(object sender, EventArgs e)
        {
            Save_ScreenDump("C:\\Optima\\History\\ScreenDump", DateTime.Now.ToString("yyMMdd_HHmmss_fff") + ".jpg");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            Label lbl1 = new Label();
            Label lbl2 = new Label();
            Label lbl3 = new Label();

            List<Label> lblList = new List<Label>();

            lbl1.Tag = 1;
            lbl2.Tag = 2;
            lbl3.Tag = 3;

            lbl1.Text = "일";
            lbl2.Text = "이";
            lbl3.Text = "삼";

            lblList.Add(lbl1);
            lblList.Add(lbl2);
            lblList.Add(lbl3);


            int mindata = lblList.Max(x => int.Parse(x.Tag.ToString()));


            bool isaaaa = lblList.Exists(s => int.Parse(s.Tag.ToString()) == 2);

            Label slot = (Label)lblList.Find(x => (int.Parse(x.Tag.ToString()) == 3));

            int aaaa = lblList.FindIndex(x => int.Parse(x.Tag.ToString()) == 2);

            MessageBox.Show(slot.Text);

        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

   

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
            }
            



            //    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, index+2);

            //dataGridView1_CellClick(this, args);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                return;
            }

        }

        private void testevent(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("TEST ERR");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private ManualResetEvent _WaitServiceInit = null;

        private void button2_Click_1(object sender, EventArgs e)
        {



            _WaitServiceInit = new ManualResetEvent(false);

            _WaitServiceInit.Reset();

            _WaitServiceInit.WaitOne(10000);


            try
            {
                throw new Exception("err");
            }
            catch (Exception)
            {

                MessageBox.Show("e");
            }
            finally
            {
                MessageBox.Show("f");
            }









            MessageBox.Show("test",
                            "TEST@22");

            this.testeventHandler += testevent;


            Task.Run(() =>
            {
                while (true)
                {
                    var action = new Action(() =>
                    {

                        testeventHandler.Invoke(this, EventArgs.Empty);

                        //try
                        //{
                        //    throw new Exception("TEST ERR");
                        //}
                        //catch (Exception a)
                        //{
                        //    MessageBox.Show(a.Message.ToString());
                        //}

                    }
                    );

                    action();

                    //Task.Delay(0).Wait();
                    Task.Delay(10).Wait();


                }
            });


            while(true)
            {
                int i = 0;
            }


            try
            {

                Task task = Task.Run(() =>
                {

                    //while(true)
                    //{

                    //}
                    throw new Exception("Test Err"); ;
                    //int i = 0;


                });

                if(!task.Wait(3000))
                {
                    throw new Exception("Test Err"); ;
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
                throw;
            }



            //if(!task.Wait(1000 * 3))
            //{
            //    MessageBox.Show("3초초과");
            //}





            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();

            list1.Add("A");
            list2.Add("A");

            if(list1.Equals(list2))
            {
                MessageBox.Show("same list");
                return;
            }








            using (var sr = new StreamReader("C:\\OptionConfig.xml"))
            {
                var xs = new XmlSerializer(typeof(OptionConfig));
                var prj = (OptionConfig)xs.Deserialize(sr);

                config = prj;

                propertyGrid1.SelectedObject = prj;

            }




            return;








                TestClass2 t1 = new TestClass2();



            iTest it= (iTest)t1;

            it.test();


            string[] findFiles = Directory.GetFiles("D:\\","*.csv");

            findFiles.Where(x => x == "ddd");

            if (false)
            {
                MessageBox.Show("ddd");
            }


            dataGridView1.CurrentCell = dataGridView1.Rows[2].Cells[0];
            //tableLayoutPanel1.ColumnCount = 2;
            button11.Visible = false;
            //tableLayoutPanel1.Controls.Add(button5);


        }

        private void button4_Click(object sender, EventArgs e)
        {




            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            test1();

            MessageBox.Show("async test");
        }

        private async void test1()
        {
            string aaaa = await test2();
        }

        private async Task<string> test2()
        {
            while(true)
                {

            }

            return "aaa";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            config.dataFilePath = "AAAAAA";

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var xs = new XmlSerializer(typeof(OptionConfig));
            using (var sw = new StreamWriter("C:\\OptionConfig.xml"))
            {
                xs.Serialize(sw, config, ns);
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            GridItem changeItem = (e as PropertyValueChangedEventArgs).ChangedItem;

            changeItem.Value.ToString();

            var nodeClz = typeof(OptionConfig);
            foreach(var field in nodeClz.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if(field.Name.Contains(changeItem.Label))
                {
                    field.SetValue(config, changeItem.Value.ToString());
                    return;
                }
            }



          

        }

        private async void button14_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;

            Dictionary<Type, Type> DicTest = new Dictionary<Type, Type>();

            DicTest.Add(typeof(string), typeof(string));

            if(!DicTest.ContainsKey(typeof(string)))
            {
                return;
            }



            await Task.Run(() => { testAsync(); });

            MessageBox.Show("end");
        }


        private async void  testAsync()
        {
            while(true)
            {
              //  await Task.Delay(100);
            }
        }

        private void updategrid()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { updategrid(); });
            }
            else
            {
                dataGridView1.Rows.Add();
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listView1.Items.Add("AAA");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listView1.Items[2].BackColor = SystemColors.Highlight;
            listView1.Items[2].ForeColor = SystemColors.HighlightText;
        }

        private void button17_Click(object sender, EventArgs e)
        {

            Form2 frm2 = new Form2(this);
            frm2.Show();


        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                TestEvent.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString());
            }
            
            
        }
    }


    public class ConTest
    {
        public static OptionConfig config;

        public ConTest()
        {
            config = new OptionConfig();

        }
    }

    public class OptionConfig
    {
        [Category("Common Information")]
        public string dataFilePath { get; set; }
        [Category("Common Information")]
        public string exportPath { get; set; }

        [Category("Surface Chart")]
        public int ChartSizeWidth { get; set; }
        [Category("Surface Chart")]
        public int ChartSizeHeight { get; set; }

        [Category("Line Graph ")]
        public int GraphSizeWidth { get; set; }
        [Category("Line Graph ")]
        public int GraphSizeHeight { get; set; }



        public OptionConfig()
        {
            ChartSizeWidth = 720;
            ChartSizeHeight = 600;

            GraphSizeWidth = 720;
            GraphSizeHeight = 600;
        }


    }


    public class Test
    {
        public string a;

        private bool isA = false;
        private bool isB = true;

        public ICommand ICOMD => new RelayCommand(TestGo, param => (isA || isB));

        public async void TestGo (object p)
        {

        }
    }


    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        virtual public void Merge(ObservableObject source) { }

        protected bool SetNewValue<T>(ref T field, T newValue = default(T), [CallerMemberName] string propertyName = null)
        {
            try
            {
                if (!EqualityComparer<T>.Default.Equals(field, newValue))
                {
                    field = newValue;
                    NotifyPropertyChanged(propertyName);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //throw ex;
                //Framework.Logger.Logger log = new Framework.Logger.Logger("UI.App");
                //log.Exception("Failed to SetNewValue", ex);
                return false;
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyChanges()
        {
            // Notify all properties
            NotifyPropertyChanged("");
        }



        //public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        Action action = new Action(() =>
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //        });

        //        //if (!_control.InvokeRequired)
        //        //    action();
        //        //else
        //        //    _control.BeginInvoke(action);

        //    }
        //}

        #region Debugging Aides
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
        #endregion
    }


    public class RelayCommand : ICommand
    {
        #region Fields
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion // Fields

        #region Constructors
        /// <summary>
        /// RelayCommand
        /// </summary>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// RelayCommand
        /// </summary>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                //throw new ArgumentNullException("execute");
                return;

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members
        /// <summary>
        /// CanExecute
        /// </summary>
        [DebuggerStepThrough]
        public bool CanExecute(object p)
        {
            return _canExecute == null || _canExecute(p);
        }

        /// <summary>
        /// CanExecuteChanged Event
        /// </summary>
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Execute
        /// </summary>
        public void Execute(object p)
        {
            _execute(p);
        }

        #endregion // ICommand Members

    }


    interface iTest
    {
        void test();
    }

    public class TestClass : iTest
    {

        public void test()
        {
            MessageBox.Show("test");
        }
    }

    public class TestClass2 : iTest
    {
        public void test()
        {
            
        }
    }

}
