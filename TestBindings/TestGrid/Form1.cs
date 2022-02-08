using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            DataTable dt = new DataTable();

            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("age");

            object[] value = new object[2];
            value[0] = "ez";
            value[1] = 1;

            dt.Rows.Add(value);

            value[0] = "e2";
            value[1] = 20;

            dt.Rows.Add(value);

            value[0] = "e3";
            value[1] = 100;

            dt.Rows.Add(value);


            DataView dv = new DataView(dt,"","",DataViewRowState.CurrentRows);

            dataGridView1.DataSource = dv;


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float aaa = 0.004f;

            MessageBox.Show(System.Math.Round(aaa, 2).ToString());

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
