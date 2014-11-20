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

namespace RIS
{
    public partial class Form_Query_6 : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        private DataTable table;
        private string queryName = "query06";
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("sale_date", "date", "Дата продажи"),
                                                            new TableColumn("titl", "text", "Категория"),
                                                            new TableColumn("compid", "int", "ИД компании"),
                                                            new TableColumn("modell", "text", "Модель"),
                                                            new TableColumn("summa", "num", "Сумма")};
        public Form_Query_6(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            this.table = new DataTable();

            try
            {
                Class_Helper.SetColumns(table, dataGridView_Orders, columns);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid: " + ex.Message);
            }
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int month = (int)numericUpDown_Month.Value;

            List<Parameter> parameters = new List<Parameter> { new Parameter("month", "int", month) };

            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryName, table, parameters);
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

        private void Form_Query_6_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
    }
}
