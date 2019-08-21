using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Net;
using System.Configuration;

namespace GstudentData
{
    public partial class mainform : Form
    {
        //connect to the excel files
        DataRow drow;
        public static int score_mark1, score_mark2, score_mark3, score_mark4;//global variables to calculate the average of student
        public static string name, ID, Intake, Study, Award;
        String strExcelConn;
        OleDbConnection connExcel = new OleDbConnection(); //oledbconnection connects to the excel data sheet
        //OleDbCommand cmdExcel = new OleDbCommand(); // requesting data from the excel sheet
        OleDbDataAdapter da;
        DataSet ds;
        int rno = 0;
        public mainform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
      


        private void btnSearch_Click(object sender, EventArgs e)
        {
            showdata();
            
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //method to connect to the excel file
        void connectToExcel(String file, String sheet)
        {
            try //try catch any possible error to avoid application termination
            {
                //connecting and reading from the excel file
                strExcelConn = ("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + file + "';Extended Properties = Excel 8.0");
                connExcel.ConnectionString = strExcelConn;
                connExcel.Open();
                da = new OleDbDataAdapter("select * from [" + sheet + "]", connExcel);
                ds = new DataSet();
                da.Fill(ds);
                connExcel.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       public void showdata()//method that carries the whole data
        {
           //fetching data from the excel file (class list) to show student data
                connectToExcel("CESCOM10153_6_Class_List", "Class List Module$B7:P27");
                System.Data.DataTable table = ds.Tables[0];
                table.PrimaryKey = new DataColumn[] { table.Columns[0] };
                try
                {
                    int n = Convert.ToInt32(txtSearch.Text);
                     drow = ds.Tables[0].Rows.Find(n);
                    if (drow != null)
                    {
                        if (webscrape())//check for internet connection before loading file
                        {
                            name = drow[1].ToString();//name
                            labelStudentName.Text = Convert.ToString(name);
                            ID = drow[0].ToString();//ID
                            labelID.Text = Convert.ToString(ID);
                            Intake = drow[10].ToString();//Intake
                            labelIntake.Text = Convert.ToString(Intake);
                            labelStudytype.Text = drow[9].ToString();//Study
                            labelAward_Code.Text = drow[14].ToString();//Award code

                            //fetching data for the attendance
                            connectToExcel("CESCOM10153_6_Attendance", "register$B3:AB23");
                            System.Data.DataTable atten1 = ds.Tables[0];//datatable package all attendance data of the student
                            atten1.PrimaryKey = new DataColumn[] { atten1.Columns[0] };//this columun is the primary key from this excel file
                            DataRow drowAtt = ds.Tables[0].Rows.Find(n);
                            double attends = (Convert.ToDouble(drowAtt[2]) * 100);//
                            labelAttend1.Text = Convert.ToString(Math.Round(attends, 1)+ "%");

                            connectToExcel("COSE60590_Attendance", "register$B3:AB23");
                            System.Data.DataTable atten2 = ds.Tables[0];
                            atten2.PrimaryKey = new DataColumn[] { atten2.Columns[0] };
                            DataRow drowAtt2 = ds.Tables[0].Rows.Find(n);
                            double attends2 = (Convert.ToDouble(drowAtt2[2]) * 100);
                            labelAttend2.Text = Convert.ToString(Math.Round(attends2, 1)+ "%");

                            connectToExcel("COWB60299_Attendance", "register$B3:AB23");
                            System.Data.DataTable atten3 = ds.Tables[0];
                            atten3.PrimaryKey = new DataColumn[] { atten3.Columns[0] };
                            DataRow drowAtt3 = ds.Tables[0].Rows.Find(n);
                            double attends3 = (Convert.ToDouble(drowAtt3[2]) * 100);
                            labelAttend3.Text = Convert.ToString(Math.Round(attends3, 1)+ "%");

                            connectToExcel("COSE60597_Attendance", "register$B3:AB23");
                            System.Data.DataTable atten4 = ds.Tables[0];
                            atten4.PrimaryKey = new DataColumn[] { atten4.Columns[0] };
                            DataRow drowAtt4 = ds.Tables[0].Rows.Find(n);
                            double attends4 = (Convert.ToDouble(drowAtt4[2]) * 100);
                            labelAttend4.Text = Convert.ToString(Math.Round(attends4, 1)+ "%");

                            //fetching data for student scores
                            connectToExcel("CESCOM10153_6_Course1_Marks", "Marks Proforma$B14:L34");
                            System.Data.DataTable first_score = ds.Tables[0];
                            first_score.PrimaryKey = new DataColumn[] { first_score.Columns[0] };
                            DataRow drowScore = ds.Tables[0].Rows.Find(n);
                            score_mark1 = Convert.ToInt32(drowScore[10]);
                            labelMark1.Text = Convert.ToString(score_mark1);
                            

                            connectToExcel("COSE60590_Course2_Marks", "Marks Proforma$B15:L34");
                            System.Data.DataTable second_score = ds.Tables[0];
                            second_score.PrimaryKey = new DataColumn[] { second_score.Columns[0] };
                            DataRow drowScore2 = ds.Tables[0].Rows.Find(n);
                            score_mark2 = Convert.ToInt32(drowScore2[10]);
                            labelMark2.Text = Convert.ToString(score_mark2);

                            connectToExcel("COWB60299_Course3_Marks", "Marks Proforma$B15:L34");
                            System.Data.DataTable third_score = ds.Tables[0];
                            third_score.PrimaryKey = new DataColumn[] { third_score.Columns[0] };
                            DataRow drowScore3 = ds.Tables[0].Rows.Find(n);
                            score_mark3 = Convert.ToInt32(drowScore3[10]);
                            labelMark3.Text = Convert.ToString(score_mark3);

                            connectToExcel("COSE60597_Course4_Marks", "Marks Proforma$B15:L34");
                            System.Data.DataTable fourth_score = ds.Tables[0];
                            fourth_score.PrimaryKey = new DataColumn[] { fourth_score.Columns[0] };
                            DataRow drowScore4 = ds.Tables[0].Rows.Find(n);
                            score_mark4 = Convert.ToInt32(drowScore4[10]);
                            labelMark4.Text = Convert.ToString(score_mark4);

                        }
                        else
                        {
                            MessageBox.Show("Loading");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Record not found");
                    }
                }catch(Exception ex)
                {

                }
                
          }
            
      //method to scrape the web
        public bool webscrape()
        {
            string url = "http://www.staffs.ac.uk/current/student/modules/showmodule.php?code=COSE60636";
            Scraper.getSourc(url);
            labelTitle1.Text = Scraper.regularexp("sourcecode", @"Title:[\s]+<\/b><\/TD><TD[\s].*?>(.*?)<\/td>");

            Scraper.getSourc(url);
            labelCode1.Text = Scraper.regularexp("sourcecode", @"([A-Z]{4}[0-9]{5})");

            Scraper.getSourc(url);
            labelLevel1.Text = Scraper.regularexp("sourcecode", @"Level:[\s]+<.*?><.*?><.*?>(.*?)<");

            Scraper.getSourc(url);
            labelLeader1.Text = Scraper.regularexp("sourcecode", @"VLE<.*?><.*?><.*?><.*?>(.*?)<");

            //MODULE2
            string url2 = "http://www.staffs.ac.uk/current/student/modules/showmodule.php?code=COSE60625";
            Scraper.getSourc(url2);
            labelTitle2.Text = Scraper.regularexp("sourcecode", @"Title:[\s]+<\/b><\/TD><TD[\s].*?>(.*?)<\/td>");

            Scraper.getSourc(url2);
            labelCode2.Text = Scraper.regularexp("sourcecode", @"([\D]{4}[\d]{5})");

            Scraper.getSourc(url2);
            labelLevel2.Text = Scraper.regularexp("sourcecode", @"Level:[\s]+<.*?><.*?><.*?>(.*?)<");

            Scraper.getSourc(url2);
            labelLeader2.Text = Scraper.regularexp("sourcecode", @"VLE<.*?><.*?><.*?><.*?>(.*?)<");

            //MODULE 3
            string url3 = "http://www.staffs.ac.uk/current/student/modules/showmodule.php?code=COSE60502";
            Scraper.getSourc(url3);
            labelTitle3.Text = Scraper.regularexp("sourcecode", @"Title:[\s]+<\/b><\/TD><TD[\s].*?>(.*?)<\/td>");

            Scraper.getSourc(url3);
            labelCode3.Text = Scraper.regularexp("sourcecode", @"([\D]{4}[\d]{5})");

            Scraper.getSourc(url3);
            labelLevel3.Text = Scraper.regularexp("sourcecode", @"Level:[\s]+<.*?><.*?><.*?>(.*?)<");

            Scraper.getSourc(url3);
            labelLeader3.Text = Scraper.regularexp("sourcecode", @"VLE<.*?><.*?><.*?><.*?>(.*?)<");

            //MODULE 4
            string url4 = "http://www.staffs.ac.uk/current/student/modules/showmodule.php?code=COSE60474";
            Scraper.getSourc(url4);
            labelTitle4.Text = Scraper.regularexp("sourcecode", @"Title:[\s]+<\/b><\/TD><TD[\s].*?>(.*?)<\/td>");

            Scraper.getSourc(url4);
            labelCode4.Text = Scraper.regularexp("sourcecode", @"([\D]{4}[\d]{5})");

            Scraper.getSourc(url4);
            labelLevel4.Text = Scraper.regularexp("sourcecode", @"Level:[\s]+<.*?><.*?><.*?>(.*?)<");

            Scraper.getSourc(url4);
            labelLeader4.Text = Scraper.regularexp("sourcecode", @"VLE<.*?><.*?><.*?><.*?>(.*?)<");
            return true;
        }

        private void labelLevel1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Aggregate agg = new Aggregate();
            agg.Show();
           // this.Close();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
