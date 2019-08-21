using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GstudentData
{
    public partial class Errormsg : Form
    {
        public Errormsg()
        {
            InitializeComponent();
        }

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainform main = new mainform();
            if(main.webscrape())
            {
                main.showdata();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
