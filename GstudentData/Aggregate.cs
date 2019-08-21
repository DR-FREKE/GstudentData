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
    public partial class Aggregate : Form
    {
        int score1;
        mainform main = new mainform();
        public Aggregate()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calave();
        }

        private void Aggregate_Load(object sender, EventArgs e)
        {
             score1 = Convert.ToInt32(mainform.score_mark1);
             labelscore1.Text = Convert.ToString(score1);
             labelscore2.Text = Convert.ToString(mainform.score_mark2);
             labelscore3.Text = Convert.ToString(mainform.score_mark3);
             labelscore4.Text = Convert.ToString(mainform.score_mark4);
             labelStudentName.Text = Convert.ToString(mainform.name);
             labelID.Text = Convert.ToString(mainform.ID);
             labelIntake.Text = Convert.ToString(mainform.Intake);
            // MessageBox.Show(""+main.score_mark4);
        }
        void calave()
        {
            int ave = (mainform.score_mark1 + mainform.score_mark2 + mainform.score_mark3 + mainform.score_mark4) / 4;
            labelcal.Text = Convert.ToString(ave);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
