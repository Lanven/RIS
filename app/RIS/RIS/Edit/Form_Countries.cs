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
    public partial class Form_Countries : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        private DataTable table;
        private string queryName = "get_all_countries";
        private string funcCreate = "func_countries_on_insert";
        private string funcChange = "func_countries_on_update";
        private string funcDelete = "func_countries_on_delete";
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("id", "int", "id"),
                                                            new TableColumn("name", "text", "Название")};

        public Form_Countries(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            this.table = new DataTable();

            try
            {
                Class_Helper.SetColumns(table, dataGridView_Countries, columns);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid: " + ex.Message);
            }

            try
            {
                string query = "SELECT id from sb.countries";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                conn.Open();
                label_ServerB.Text = ((int)cmd.ExecuteScalar()).ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Can't connect to B: " + ex.Message);
            }
        }

        private void RefreshData()
        {
            string result = "";
            Cursor.Current = Cursors.WaitCursor;
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

        private bool IsEveryFieldCorrect()
        {
            string name = textBox_Name.Text;
            if (!Class_Helper.IsCorrect_String(name))
            {
                MessageBox.Show("Неверное название страны");
                return false;
            }
            return true;
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            if (!IsEveryFieldCorrect())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            string name = textBox_Name.Text;

            List<Parameter> parameters = new List<Parameter> { new Parameter("name", "text", name) };

            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcCreate, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                if (ex.Source == "Npgsql")
                    if (((NpgsqlException)ex).Code == "P0001")
                        error = "Страна уже существует";
                    else
                        error = "Smth wrong on country insert";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Страна создана. " + result;
        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите страну");
                return;
            }
            if (label_id.Text == label_ServerB.Text)
            {
                MessageBox.Show("Нельзя изменить");
                return;
            }

            if (!IsEveryFieldCorrect())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            string name = textBox_Name.Text;
            int country_id = Convert.ToInt32(label_id.Text);

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", country_id),
                                                               new Parameter("name", "text", name)};
            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcChange, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                if (ex.Source == "Npgsql")
                    if (((NpgsqlException)ex).Code == "P0001")
                        error = "Страна уже существует";
                    else
                        error = "Smth wrong on country update";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Страна изменена. " + result;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите страну");
                return;
            }

            if (label_id.Text == label_ServerB.Text)
            {
                MessageBox.Show("Нельзя удалить");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int country_id = Convert.ToInt32(label_id.Text);

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", country_id) };
            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcDelete, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                if (ex.Source == "Npgsql")
                    if (((NpgsqlException)ex).Code == "P0001")
                        error = "Невозможно удалить страну - есть связанные данные";
                    else
                        error = "Smth wrong on country delete";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Страна удалена. " + result;
        }

        private void dataGridView_Countries_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int row = e.RowIndex;
                    int column = e.ColumnIndex;
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[row].Cells[column];
                    dataGridView_Countries.Rows[row].Selected = true;
                    textBox_Name.Text = (string)dataGridView_Countries["name", row].Value;
                    label_id.Text = ((int)dataGridView_Countries["id", row].Value).ToString();
                }
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
