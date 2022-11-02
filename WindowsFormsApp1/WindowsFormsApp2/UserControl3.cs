using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UserControl3 : UserControl
    {
        bool istrue;
        public UserControl3()
        {
            InitializeComponent();
            istrue = true;
        }

        public void set()
        {
            istrue = !istrue;
            propertyGrid_Common.Enabled = istrue;
        }
    }
}
