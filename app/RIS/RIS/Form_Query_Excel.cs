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

        public Form_Query_Excel(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("Something wrong with connection");
                this.Close();
            }

            getFirmList();
            dataGridView_Data.AutoGenerateColumns = true;
        }

        private void getFirmList()
        {
            Stopwatch timer = new Stopwatch();
            System.Data.DataTable table = new System.Data.DataTable();

            NpgsqlCommand command = new NpgsqlCommand("query91", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            timer.Start();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);

            da.Fill(table);

            comboBox_Firms.DataSource = table;
            comboBox_Firms.DisplayMember = "name";
            comboBox_Firms.ValueMember = "id";
            timer.Stop();
            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";

            
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
            Stopwatch timer = new Stopwatch();
            System.Data.DataTable table = new System.Data.DataTable();

            string from = textBox_From.Text;
            string to = textBox_To.Text;

            if (!IsDate(from) || !IsDate(to))
            {
                MessageBox.Show("Incorrect");
                return;
            }

            string tmp = "select count(*) from sb.companies a where a.id = :id";
            NpgsqlCommand tmpcmd = new NpgsqlCommand(tmp, conn);
            tmpcmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);

            if ((long)tmpcmd.ExecuteScalar() == 0)
            {
                var cmdData = new Npgsql.NpgsqlCommand("query92dblink", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                cmdData.Parameters.Add("from", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(from);
                cmdData.Parameters.Add("to", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(to);
                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdData);
                da.Fill(table);
                dataGridView_Data.DataSource = table;
                timer.Stop();
            }
            else
            {
                var cmdData = new Npgsql.NpgsqlCommand("query92", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                cmdData.Parameters.Add("from", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(from);
                cmdData.Parameters.Add("to", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(to);
                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdData);
                da.Fill(table);
                dataGridView_Data.DataSource = table;
                timer.Stop();
            }

            dataGridView_Data.Columns["surnam"].HeaderCell.Value = "Фамилия";
            dataGridView_Data.Columns["nam"].HeaderCell.Value = "Имя";
            dataGridView_Data.Columns["patronymi"].HeaderCell.Value = "Отчество";
            dataGridView_Data.Columns["birthdat"].HeaderCell.Value = "Дата рождения";
            dataGridView_Data.Columns["passport_serie"].HeaderCell.Value = "Серия паспорта";
            dataGridView_Data.Columns["passport_numbe"].HeaderCell.Value = "Номер паспорта";
            dataGridView_Data.Columns["summ"].HeaderCell.Value = "Сумма";

            double time = timer.ElapsedMilliseconds;
            toolStripStatusLabel.Text = Convert.ToString(table.Rows.Count) + " строк. Затрачено " + Convert.ToString(time) + " мсек.";

        }

        private void button_GetExcelReport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excelApp;
            excelApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook excelWorkBook;
            Worksheet excelWorkSheet;
            excelWorkBook = excelApp.Workbooks.Add();
            excelWorkSheet = (Worksheet)excelWorkBook.Worksheets[1];
            
            //ExcelWorkSheet.Range["A1:E1"].Merge();
            //ExcelWorkSheet.Range["B2:E2"].Merge();
            //ExcelApp.Cells[1, 1] = "Книги на руках";
            //ExcelApp.Cells[2, 1] = "Читатель:";
            //ExcelApp.Cells[2, 2] = name;
            //int num = 1;
            for (int i = 0; i < dataGridView_Data.ColumnCount; i++)
                excelApp.Cells[1, i + 1] = dataGridView_Data.Columns[i].HeaderText;

            for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_Data.ColumnCount; j++)
                {
                    excelApp.Cells[i + 2, j + 1] = dataGridView_Data.Rows[i].Cells[j].Value;
                }
               // num++;
            }

            //excelWorkSheet.Range["A1:E" + Convert.ToString(num + 2)].Borders.LineStyle = XlLineStyle.xlContinuous;
            excelApp.Columns.AutoFit();
            excelApp.Visible = true;
            
        }

        private void Form_Query_Excel_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }


    }
}
