﻿using System;
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


            iTextSharp.text.Font font1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(),28, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font2 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(resumeout.Image);
            image.ScalePercent(27f);
            image.Alignment = 6;
            LineSeparator horiLine = new LineSeparator(4f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER,1);
            Paragraph fullname = new Paragraph(resumeout.Full_Name+"\n", font1);
            Paragraph homeAddress = new Paragraph("\n"+resumeout.Home_Address);
            Paragraph birthdate = new Paragraph(resumeout.Birthdate);
            Paragraph emailAddress = new Paragraph(resumeout.Email_Address);
            Paragraph contactNum = new Paragraph(resumeout.Contact_num+"\n\n\n");
            Paragraph objectiveHeader = new Paragraph(resumeout.objective_Header+"\n\n", font2);
            Paragraph objective = new Paragraph(resumeout.Objective+"\n\n\n");
            Paragraph educHeader = new Paragraph(resumeout.Educ_Header + "\n\n", font2);


            pdfcreator.Open();
            pdfcreator.Add(image);
            pdfcreator.Add(fullname); 
            pdfcreator.Add(homeAddress);
            pdfcreator.Add(birthdate);
            pdfcreator.Add(emailAddress);
            pdfcreator.Add(contactNum);            
            pdfcreator.Add(objectiveHeader);
            pdfcreator.Add(horiLine);
            pdfcreator.Add(objective);
            pdfcreator.Add(educHeader);
            pdfcreator.Add(horiLine);
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
        }
    }
}
