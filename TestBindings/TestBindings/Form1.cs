using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBindings
{
    public partial class Form1 : Form
    {
        public event PropertyChangedEventHandler PropertyChanged;


        int cnt = 0;
        private TestB testb = new TestB();



        public Form1()
        {
            InitializeComponent();
            
            label1.DataBindings.Add("Text", testb, nameof(testb.strB));//, true, DataSourceUpdateMode.OnPropertyChanged);

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nameof(TestB.strB).ToString());


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            cnt++;

           // testb.strB = cnt.ToString();
        }





    }

    public class TestA : UserControl
    {
        private List<string> _stra = new List<string>();

        [Browsable(false)]
        [Bindable(true)]
        public List<string> strA
        {
            get => _stra;
            set => _stra = value;
        }
        
        public TestA()
        {
          //  strA.Add("A1");
        }


    }

    public class TestB : UserControl
    {
        //private List<string> _strb = new List<string>();
        //public List<string> strB
        //{
        //    get => _strb;
        //    set => _strb = value;
        //}

        //public TestB()
        //{
        //   // strB.Add("A2");
        //}

        public string _strb = "strB";
        [Browsable(false)]
        [Bindable(true)]
        public string strB
        {
            get { return _strb; }
            set
            {
                _strb = value;
                NotifyPropertyChanged("strB");
            }

        }

        public void NotifyPropertyChanged(string propertyName)
        {

            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}
        }
    }


}
