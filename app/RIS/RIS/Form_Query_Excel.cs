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
        NpgsqlConnection conn;

        public Form_Query_Excel(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            dataGridView_Data.AutoGenerateColumns = true;
        }

        private void button_GetFirmList_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();

            DataSet dataSet = new DataSet();
            System.Data.DataTable table = new System.Data.DataTable();

            string query = "SELECT * FROM ( " +
                            "SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru  " +
                            "port=5432 user=risbd6 password=ris14bd6',  " +
                            "'SELECT sa.companies.id, sa.companies.name, sa.companies.country_id " +
                            "FROM sa.companies') as company (id integer, name text, country_id integer) " +
                            "UNION " +
                            "SELECT sb.companies.id, sb.companies.name, sb.companies.country_id " +
                            "FROM sb.companies " +
                            ") a " +
                            "ORDER BY 2 ";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);

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

        private bool checkIsDate(string str)
        {
            DateTime myDate;
            if (DateTime.TryParse(str, out myDate))
                return true;
            return false;
        }

        private void button_GetLook_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            DataSet dataSet = new DataSet();
            System.Data.DataTable table = new System.Data.DataTable();

            string from = textBox_From.Text;
            string to = textBox_To.Text;

            if (!checkIsDate(from) || !checkIsDate(to))
            {
                MessageBox.Show("Incorrect");
                return;
            }

            string tmp = "select count(*) from sb.companies a where a.id = :id";
            NpgsqlCommand tmpcommand = new NpgsqlCommand(tmp, conn);
            tmpcommand.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);

            string query;
            if ((long)tmpcommand.ExecuteScalar() == 0)
            {
                var cmd1 = new Npgsql.NpgsqlCommand("query92", conn);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                cmd1.Parameters.Add("from", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(from);
                cmd1.Parameters.Add("to", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(to);
                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
                da.Fill(table);
                dataGridView_Data.DataSource = table;
                timer.Stop();
            }
            else
            {
                query = "SELECT sb.clients.surname, sb.clients.name, sb.clients.patronymic, sb.clients.birthdate, " +
                        "    sb.clients.passport_series, sb.clients.passport_number, sum(sale_amount) " +
                        "FROM (SELECT id FROM sb.goods_main WHERE sb.goods_main.company_id = :id) as good " +
                        "JOIN (SELECT goods_id, client_id, sale_amount FROM sb.orders_main  " +
                        "    WHERE on_sale_date BETWEEN :from and :to) as ordr " +
                        "    ON ordr.goods_id = good.id " +
                        "JOIN sb.clients ON sb.clients.id = ordr.client_id " +
                        "GROUP BY sb.clients.surname, sb.clients.name, sb.clients.patronymic, sb.clients.birthdate, " +
                        "    sb.clients.passport_series, sb.clients.passport_number " +
                        "ORDER BY 7 DESC, (1,2,3) ASC, 4 ASC ";

                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                command.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = Convert.ToInt32(comboBox_Firms.SelectedValue);
                command.Parameters.Add("from", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(from);
                command.Parameters.Add("to", NpgsqlTypes.NpgsqlDbType.Date).Value = DateTime.Parse(to);
                timer.Start();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                da.Fill(table);
                dataGridView_Data.DataSource = table;
                timer.Stop();
            }

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


    }
}
