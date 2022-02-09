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


            iTextSharp.text.Font font1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.COURIER.ToString(),25, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font2 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.COURIER.ToString(), 17, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font3 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 13);
            iTextSharp.text.Font font4 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 13, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font5 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 8);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(resumeout.Image);
            image.ScalePercent(27f);
            image.Alignment = 6;
            LineSeparator horiLine = new LineSeparator(4f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER,1);
            Paragraph fullname = new Paragraph(resumeout.Full_Name+"\n", font1);
            Paragraph homeAddress = new Paragraph("\n"+resumeout.Home_Address);            
            Paragraph emailAddress = new Paragraph(resumeout.Email_Address);
            Paragraph contactNum = new Paragraph(resumeout.Contact_num);
            Paragraph birthdate = new Paragraph(resumeout.Birthdate + "\n\n");
            Paragraph objectiveHeader = new Paragraph(resumeout.objective_Header+"\n\n", font2);
            Paragraph objective = new Paragraph("      "+resumeout.Objective+"\n\n");
            Paragraph educHeader = new Paragraph(resumeout.Educ_Header + "\n\n", font2);
            Phrase cyear = new Phrase("     " + resumeout.Cyear, font3);
            Phrase college = new Phrase("          College                   " + resumeout.College+"\n\n", font3);
            Phrase hsyear = new Phrase("     " + resumeout.HSyear, font3);
            Phrase highschool = new Phrase("          Highschool             "+resumeout.Highschool+"\n\n", font3);
            Phrase eyear = new Phrase("     " + resumeout.Eyear, font3);
            Phrase elementary = new Phrase("          Elementary             " + resumeout.Elementary+"\n\n", font3);
            Paragraph strHeader = new Paragraph(resumeout.Str_Header + "\n\n", font2);
            Paragraph str1 = new Paragraph("\n"+ "        • " + resumeout.Str1+"\n\n", font4);
            Paragraph str2 = new Paragraph("        • " + resumeout.Str2 + "\n\n", font4);
            Paragraph str3 = new Paragraph("        • " + resumeout.Str3 + "\n\n", font4);
            Paragraph str4 = new Paragraph("        • " + resumeout.Str4 + "\n\n\n\n\n", font4);
            Paragraph footer = new Paragraph(resumeout.Footer, font5);
            footer.Alignment = Element.ALIGN_CENTER;

            pdfcreator.Open();

            pdfcreator.Add(image);
            pdfcreator.Add(fullname); 
            pdfcreator.Add(homeAddress);            
            pdfcreator.Add(emailAddress);            
            pdfcreator.Add(contactNum);
            pdfcreator.Add(birthdate);
            pdfcreator.Add(objectiveHeader);
            pdfcreator.Add(horiLine);
            pdfcreator.Add(objective);
            pdfcreator.Add(educHeader);
            pdfcreator.Add(horiLine);
            pdfcreator.Add(cyear);
            pdfcreator.Add(college);
            pdfcreator.Add(hsyear);
            pdfcreator.Add(highschool);
            pdfcreator.Add(eyear);
            pdfcreator.Add(elementary);
            pdfcreator.Add(strHeader);
            pdfcreator.Add(horiLine);
            pdfcreator.Add(str1);
            pdfcreator.Add(str2);
            pdfcreator.Add(str3);
            pdfcreator.Add(str4);
            pdfcreator.Add(footer);

            pdfcreator.Close();
            
        }

        public class jsonreader
        {
            public string Image
            {
                get; set;
            }
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
            public string objective_Header
            {
                get; set;
            }
            public string Objective
            {
                get; set;
            }
            public string Educ_Header
            {
                get; set;
            }
            public string College
            {
                get; set;
            }
            public string Cyear
            {
                get; set;
            }
            public string Highschool
            {
                get; set;
            }
            public string HSyear
            {
                get; set;
            }
            public string Elementary
            {
                get; set;
            }
            public string Eyear
            {
                get; set;
            }
            public string Str_Header
            {
                get; set;
            }
            public string Str1
            {
                get; set;
            }
            public string Str2
            {
                get; set;
            }
            public string Str3
            {
                get; set;
            }
            public string Str4
            {
                get; set;
            }
            public string Footer
            {
                get; set;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
