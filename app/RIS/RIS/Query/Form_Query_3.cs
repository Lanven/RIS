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
    public partial class Form_Query_3 : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        private DataTable table;
        private string queryName = "query03";
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("surnam", "text", "Фамилия"),
                                                            new TableColumn("nam", "text", "Имя"),
                                                            new TableColumn("patronymi", "text", "Отчество"),
                                                            new TableColumn("birthdat", "date", "Дата рождения"),
                                                            new TableColumn("phon", "text", "Телефон"),
                                                            new TableColumn("emai", "text", "Е-мэйл"),
                                                            new TableColumn("addres", "text", "Адрес")};
        public Form_Query_3(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            this.table = new DataTable();

            try
            {
                Class_Helper.SetColumns(table, dataGridView_Clients, columns);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid: " + ex.Message);
            }
        }

        private void button_Get_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string result = "";
            try
            {
                result = Class_Helper.ExecuteStoredQuery(conn, queryName, table);
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
    }
}
