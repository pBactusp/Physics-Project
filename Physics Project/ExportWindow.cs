using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace Physics_Project
{
    public partial class ExportWindow : Form
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                directoryTB.Text = fbd.SelectedPath;
        }



        public void ExportToExcel(object input, string type, string letter = "A", int number = 1)
        {
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWb = new Excel.Workbook();

            List<NamedList> data = new List<NamedList>();

            type = type.ToUpper();

            
            switch (type)
            {
                case "GRAPHER":


                    break;

                case "TABLE":


                    break;

                default:
                    break;
            }








        }



        private void directoryTB_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
