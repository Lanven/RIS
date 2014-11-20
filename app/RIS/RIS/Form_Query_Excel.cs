using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Office.Interop.Excel;

namespace RIS
{
    public partial class Form_Query_Excel : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        private System.Data.DataTable tableFirms;
        private string queryFirms = "query91";
        List<TableColumn> members = new List<TableColumn> {new TableColumn("name", "text", "Название"),
                                                           new TableColumn("id", "int", "ИД")};
        private System.Data.DataTable tableData;
        private string queryData = "query92";
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("surnam", "text", "Фамилия"),
                                                           new TableColumn("nam", "text", "Имя"),
                                                           new TableColumn("patronymi", "text", "Отчество"),
                                                           new TableColumn("birthdat", "date", "Дата рождения"),
                                                           new TableColumn("passport_serie", "text", "Серия паспорта"),
                                                           new TableColumn("passport_numbe", "text", "Номер паспорта"),
                                                           new TableColumn("summ", "num", "Сумма")};
        public Form_Query_Excel(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            this.tableFirms = new System.Data.DataTable();
            this.tableData = new System.Data.DataTable();

            try
            {
                Class_Helper.SetColumns(tableData, dataGridView_Data, columns);
                Class_Helper.SetMember(tableFirms, comboBox_Firms, members, "name", "id");
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid/combobox: " + ex.Message);
            }        
        }

        private void getFirmList()
        {
            Cursor.Current = Cursors.WaitCursor;
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryFirms, tableFirms);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = result;
        }

        private void button_GetFirmList_Click(object sender, EventArgs e)
        {
            getFirmList();
        }

        private bool IsDate(string str)
        {
            DateTime myDate;
            if (DateTime.TryParse(str, out myDate))
                return true;
            return false;
        }

        private void button_GetLook_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBox_Firms.SelectedIndex == -1)
            {
                MessageBox.Show("Choose firm");
                return;
            }

            int firmID = Convert.ToInt32(comboBox_Firms.SelectedValue);
            string fromStr = maskedTextBox_From.Text;
            string toStr = maskedTextBox_To.Text;

            if (!IsDate(fromStr) || !IsDate(toStr))
            {
                MessageBox.Show("Incorrect dates");
                return;
            }
            DateTime from = DateTime.Parse(fromStr);
            DateTime to = DateTime.Parse(toStr);
            /**************************************/
            label5.Text = fromStr;
            label6.Text = toStr;
            label7.Text = ((System.Data.DataRowView)comboBox_Firms.SelectedItem).Row["name"].ToString();
            /**************************************/
            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", firmID),
                                                                new Parameter("from", "date", from),
                                                                new Parameter("to", "date", to)};
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryData, tableData, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = result;
        }

        private void button_GetExcelReport_Click(object sender, EventArgs e)
        {
            string from = label5.Text;
            string to = label6.Text;
            string name = label7.Text;

            if (name == "")
            {
                MessageBox.Show("Пожалуйста, введите данные и нажмите просмотр");
                return;
            }
            Microsoft.Office.Interop.Excel.Application excelApp;
            excelApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook excelWorkBook;
            Worksheet excelWorkSheet;
            excelWorkBook = excelApp.Workbooks.Add();
            excelWorkSheet = (Worksheet)excelWorkBook.Worksheets[1];

            excelApp.Cells[1, 1] = "Фирма";
            excelWorkSheet.Cells[1, 1].Font.Bold = true;
            excelWorkSheet.Range["B1:G1"].Merge();
            excelApp.Cells[1, 2] = name;
            excelWorkSheet.Cells[1, 2].Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            excelWorkSheet.Cells[1, 2].Font.Bold = true;
            excelWorkSheet.Cells[1, 2].Font.Size = 16;

            excelApp.Cells[2, 1] = "Период:";
            excelWorkSheet.Cells[2, 1].Font.Bold = true;
            excelApp.Cells[2, 2] = from;
            excelApp.Cells[2, 3] = to;
            

            int num = 4;
            for (int i = 0; i < dataGridView_Data.ColumnCount; i++)
            {
                excelApp.Cells[num, i + 1] = dataGridView_Data.Columns[i].HeaderText;
            }
            excelWorkSheet.Cells[num, 1].EntireRow.Font.Bold = true; 
            num++;

            for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_Data.ColumnCount; j++)
                {
                    excelApp.Cells[num + i, j + 1] = dataGridView_Data.Rows[i].Cells[j].Value;
                }
            }

            excelWorkSheet.Range["A4:G" + Convert.ToString(dataGridView_Data.Rows.Count + num - 1)].Borders.LineStyle = XlLineStyle.xlContinuous;
            excelApp.Columns.AutoFit();
            excelApp.Visible = true;
            
        }
    }
}
