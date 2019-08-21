using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GstudentData
{
    class Scraper
    {
        public static string getSourc(string pURL)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(pURL);
            HttpWebResponse resp = null;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }catch(Exception ex)
            {
                //MessageBox.Show("No connection");
                Errormsg error = new Errormsg();
                error.ShowDialog();
            }
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string sourceCode = sr.ReadToEnd();
            sr.Close();
            resp.Close();

            StreamWriter write = new StreamWriter("sourcecode");
            write.Write(sourceCode);
            write.Close();
            return sourceCode;

        }

       public static string regularexp(string filename, string regex)
        {
            StreamReader sr = new StreamReader(filename);
            string sourceCode = sr.ReadToEnd();
            sr.Close();

            Regex exp = new Regex(regex);
            Match ma = exp.Match(sourceCode);

            String val = " ";

            foreach(Group k in ma.Groups)
            {
                val = k.Value;
            }
           return val;
        }
         
    }
}
