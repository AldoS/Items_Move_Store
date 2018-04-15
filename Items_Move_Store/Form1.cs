using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Items_Move_Store
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_katastimata_file_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog1.FileName;
                    textBox_File_Katastima.Text = file;
                }
            }
            catch (IOException err)
            {
                MessageBox.Show("Σφάλμα επιλογής αρχείου Καταστημάτων: " + err.Message);
            }
        }

        private void button_kiniseis_file_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog1.FileName;
                    textBox_File_Kiniseis.Text = file;
                }
            }
            catch (IOException err)
            {
                MessageBox.Show("Σφάλμα επιλογής αρχείου Κινήσεων: " + err.Message);
            }
        }

        private void button_Execute_Click(object sender, EventArgs e)
        {
            string[,] Arr_Katastimatwn = new string[100, 10];
            Arr_Katastimatwn = fillArray_Katastimatwn();

            string[,] Arr_Kinisewn = new string[100, 10];
            Arr_Kinisewn = fillArray_Kinisewn();

            //έλεγχος πόσα είδη απο αυτά που ζητήθηκαν θα βρεθούν στα διαθέσιμα καταστήματα
            //θα πάρουμε από αυτό στο οποίο υπάρχουν οι περισσότεροι κωδικοί ειδών

        }

        private string[,] fillArray_Katastimatwn()
        {
            string[,] Arr = new string[100, 10];

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"" + textBox_File_Katastima.Text);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value != null)
                    {
                        //Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                        Arr[i, j] = xlRange.Cells[i, j].Value.ToString();
                    }

                }
            }

            //close and release
            xlWorkbook.Close();

            return Arr;
        }

        private string[,] fillArray_Kinisewn()
        {
            string[,] Arr = new string[100, 10];

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"" + textBox_File_Kiniseis.Text);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value != null)
                    {
                        //Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                        Arr[i, j] = xlRange.Cells[i, j].Value.ToString();
                    }

                }
            }

            //close and release
            xlWorkbook.Close();

            return Arr;
        }

        private void createExcel()
        {
            // Create a list of accounts.
            var bankAccounts = new List<Account> {
                new Account {
                    ID = 345678,
                    Balance = 541.27
                },
                new Account {
                    ID = 1230221,
                    Balance = -127.44
                }
            };
        }
    }

    public class Account
    {
        public int ID { get; set; }
        public double Balance { get; set; }
    }
}
