using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "컬럼1";
            dataGridView1.Columns[1].Name = "컬럼2";

            List<string> list = new List<string>();
            list.Add("AAA");
            list.Add("BBB");

            dataGridView1.DataSource = list;

            ////dataGridView1.Rows.Add("dddd");
            ////dataGridView1.Rows.Add("bbbb");

            //DataGridViewColumn column = dataGridView1.Columns[0];
            //column.Width = 1;
            //column = dataGridView1.Columns[1];
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            

            return;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.SelectedRows[3].Selected = true;



            dataGridView1.Enabled = false;

            Task.Run(async ()=>
            {
                await Task.Delay(3000);
                dataGridView1.Enabled = true;
            });

            



        }

        private bool ischk = false;

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
