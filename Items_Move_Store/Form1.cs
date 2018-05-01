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
using System.Data.SQLite;

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
            fillTables_fromExcel(textBox_File_Katastima.Text,"Stores");
            fillTables_fromExcel(textBox_File_Kiniseis.Text, "Movements");

            check_Items_in_Stores();

            /*string[,] Arr_Katastimatwn;
            Arr_Katastimatwn = fillArray_fromExcel(textBox_File_Katastima.Text);
            string[,] Arr_Kinisewn;
            Arr_Kinisewn = fillArray_fromExcel(textBox_File_Kiniseis.Text);*/

            //έλεγχος πόσα είδη απο αυτά που ζητήθηκαν θα βρεθούν στα διαθέσιμα καταστήματα
            //θα πάρουμε από αυτό στο οποίο υπάρχουν οι περισσότεροι κωδικοί ειδών
            find_More_Items_In_Same_Store();

        }

        private void fillTables_fromExcel(String filePath, string tableName)
        {
            string startupPath = Environment.CurrentDirectory;

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"" + filePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            try
            {
                string connectionString = "URI=file: C:\\Users\\Aldo\\source\\repos\\Items_Move_Store\\Items_Move_Store\\database.sqlite";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "delete from " + tableName;
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();

                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        for (int i = 2; i <= rowCount; i++)
                        {
                            string strSql = "INSERT INTO "+ tableName + " (Store,Item,Qty) VALUES(" + xlRange.Cells[i, 1].Value.ToString() + "," + xlRange.Cells[i, 2].Value.ToString() + "," + xlRange.Cells[i, 3].Value.ToString() + ")";
                            cmd.CommandText = strSql;
                            cmd.Connection = conn;

                            //conn.Open();
                            cmd.ExecuteNonQuery();
                            // do something…
                            //conn.Close();
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Σφάλμα στην εισαγωγή δεδομένων στη βάση: "+e.Message);
            }

            //close and release
            xlWorkbook.Close();
        }

        private string[,] fillArray_fromExcel(String filePath)
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"" + filePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count+1;
            int colCount = xlRange.Columns.Count+1;

            string[,] Arr = new string[rowCount, colCount];            

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i < rowCount; i++)
            {
                for (int j = 1; j < colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value != null)
                    {
                        Arr[i, j] = xlRange.Cells[i, j].Value.ToString();
                    }

                }
            }

            //close and release
            xlWorkbook.Close();

            return Arr;
        }

        private void check_Items_in_Stores()
        {
            //θα πάρουμε τα καταστήματα ταξινομημένα βάση των αριθμών των κινήσεων
            string vSql = "select *, "+
                  "  ("+
                  "     select count(*) as kiniseis from Movements"+
                  "     where M.Store = Store"+
                  "     group by Store"+
                  "  ) as kiniseis"+
                  "  from Movements M"+
                  "  order by kiniseis desc  ";
            try
            {
                string connectionString = "URI=file: C:\\Users\\Aldo\\source\\repos\\Items_Move_Store\\Items_Move_Store\\database.sqlite";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(vSql, conn);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int ItemId;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //string asdasdasd = dr["Store"].ToString();
                        ItemId = Int32.Parse(dr["Item"].ToString());
                        vSql = "select * from Stores where Item = '"+ ItemId + "'";
                        //θα γεμίσουμε πίνακα με όπου βρούμε το item που θέλουμε και σε τι ποσοστό
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                MessageBox.Show("Σφάλμα στην εισαγωγή δεδομένων στη βάση: " + e.Message);
            }
        }

        private void find_More_Items_In_Same_Store()
        {

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
