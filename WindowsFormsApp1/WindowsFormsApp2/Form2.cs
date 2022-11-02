using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp2
{
    public enum enumA
    {
        abc = 0,
        def = 1
    }
    public partial class Form2 : Form
    {
        private string _namee;

        [Browsable(false)]
        [Bindable(true)]
        private string namee
        {
            get => _namee;
            set
            {
                namee = value;
            }
        }

        public Form2()
        {
            InitializeComponent();

            label2.Parent = this.pictureBox1;


            father fa = new father();
            Mother mo = new Mother();


            


        }

        private void button5_Click(object sender, EventArgs e)
        {
            propertyGrid2.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string path = @"C:\AAA\abc.txt";

            string test = Path.GetDirectoryName(path);
            string test2 = Path.GetFileNameWithoutExtension(path);


            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Multiselect = false;
                openFile.Filter = "Recipe Files (*.rcp)|*.rcp";
                openFile.CheckFileExists = true;
                openFile.CheckPathExists = true;

                if (openFile.ShowDialog(this) != DialogResult.OK)
                    return;

                
                MessageBox.Show(openFile.SafeFileName);

            }

            return;


            ListViewItem a = new ListViewItem();
            a.Text = "AAA";

            ListViewItem b = new ListViewItem();
            b.Text = "AAA";

            listView1.Items.Add(a);
            listView1.Items.Add(b);

            return;


            string aaa = "bbb";
            MessageBox.Show($"test\r{aaa}\r{aaa}");

            var man = new Man();

            var result = man.getbool("2");


            man.changePeopleName();

            People people;

            people = man;




            

     




        }

        private void tabTest1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Items[0].Selected = true;

            var items = listView1.SelectedItems;

            if (items.Count <= 0)
                return;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CancelEventArgs ea = new CancelEventArgs();
            ea.Cancel = true;

            base.OnTabIndexChanged(ea);

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            CancelEventArgs ea = new CancelEventArgs();
            ea.Cancel = true;

            base.OnClick(ea);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            CancelEventArgs ea = new CancelEventArgs();
            ea.Cancel = true;

            base.OnTabIndexChanged(ea);
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            CancelEventArgs ea = new CancelEventArgs() ;
            ea.Cancel = true;

            base.OnTabIndexChanged(ea);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void tabControl1_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Validated(object sender, EventArgs e)
        {

        }

        private void tabControl1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void tabControl1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_RegionChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            
        }

        private void tabControl1_CursorChanged(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_Deselected(object sender, TabControlEventArgs e)
        {
           
        }

        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {

            e.Cancel = true;


        }

        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }




    public class People
    {
        public string PeopleName = "peoplename";

        public virtual void changePeopleName()
        {
            MessageBox.Show("1");
        }

        public virtual Task<bool> getbool(string name) { throw new NotImplementedException(); }

    }

    public class Man : People
    {
        public string ManName = "manname";

        public override void changePeopleName()
        {
            base.changePeopleName();
            MessageBox.Show("2");
            base.changePeopleName();
        }

        public override async Task<bool> getbool(string name)
        {


            if (name == "1")
                return false;
            else
                return true;

        }

    }


    public class father : Man
    {

    }

    public class Woman : People
    {

    }

    public class Mother : Woman
    {

    }
    public interface iTest
    {
        string name { get; set; }

        void logText();
    }

    [DataContract]
    public class CommonParam
    {

        [DataMember]
        [Category("Shot Image"), Description("Enable to save the shot image")]
        public bool EnabledSaveShotImage { set; get; } = true;
    }


    public enum ButtonType
    {
        Add,
        Copy,
        Edit,
        Delete,
        Reload,
        Save,
        SaveAs
    }
}
