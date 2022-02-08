using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casting_Test
{
    public class TestClass : iTestClass
    {

        public void GetName1()
        {
            MessageBox.Show("GetName1");
        }

        public void GetName2()
        {
            MessageBox.Show("GetName2");
        }
    }
}
