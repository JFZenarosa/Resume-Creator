using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace Resume_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void create_button_Click(object sender, EventArgs e)
        {
            string jsonpath = @"X:\School\Visual Studio\Repository\Resume Creator\Resume Creator\resumeCreator.json";

            string openfile = File.ReadAllText(jsonpath);
            jsonreader resumeout = JsonConvert.DeserializeObject<jsonreader>(openfile);

            Document pdfcreator = new Document();
            PdfWriter.GetInstance(pdfcreator, new FileStream(@"X:\School\Visual Studio\Repository\Resume Creator\Resume Creator\ZENAROSA_JAIREH.pdf",FileMode.Create));

            Paragraph fullname = new Paragraph(resumeout.Full_Name+"\n\n");
            Paragraph homeAddress = new Paragraph(resumeout.Home_Address);
            Paragraph birthdate = new Paragraph(resumeout.Birthdate);
            Paragraph emailAddress = new Paragraph(resumeout.Email_Address);
            Paragraph contactNum = new Paragraph(resumeout.Contact_num);

            pdfcreator.Open();            
            pdfcreator.Add(fullname); 
            pdfcreator.Add(homeAddress);
            pdfcreator.Add(birthdate);
            pdfcreator.Add(emailAddress);
            pdfcreator.Add(contactNum);
            pdfcreator.Close();
            
        }

        public class jsonreader
        {
            public string Full_Name
            {
                get;set;
            }
            public string Home_Address
            {
                get;set;
            }
            public string Birthdate
            {
                get; set;
            }
            public string Email_Address
            {
                get; set;
            }
            public string Contact_num
            {
                get; set;
            }
        }
    }
}
