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
    public partial class Form_Categories : Form
    {
        private string connStr;
        private NpgsqlConnection conn;
        private DataTable table;
        private string queryName = "get_all_categories";
        private string funcCreate = "func_categories_on_insert";
        private string funcChange = "func_categories_on_update";
        private string funcDelete = "func_categories_on_delete";
        List<TableColumn> columns = new List<TableColumn> {new TableColumn("id", "int", "id"),
                                                            new TableColumn("title", "text", "Название")};

        public Form_Categories(string connStr)
        {
            InitializeComponent();
            this.connStr = connStr;
            this.conn = new NpgsqlConnection(connStr);
            this.table = new DataTable();

            try
            {
                Class_Helper.SetColumns(table, dataGridView_Categories, columns);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't init datagrid: " + ex.Message);
            }
            //dataGridView_Categories.Columns["id"].Visible = false;
            //dataGridView_Categories.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dataGridView_Categories_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int row = e.RowIndex;
                    int column = e.ColumnIndex;
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[row].Cells[column];
                    dataGridView_Categories.Rows[row].Selected = true;
                    textBox_Title.Text = (string)dataGridView_Categories["title", row].Value;
                    label_id.Text = ((int)dataGridView_Categories["id", row].Value).ToString();
                }
            }
        }

        private bool IsEveryFieldCorrect()
        {
            string title = textBox_Title.Text;
            if (!Class_Helper.IsCorrect_String(title))
            {
                MessageBox.Show("Неверное название категории");
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
            string title = textBox_Title.Text;

            List<Parameter> parameters = new List<Parameter> { new Parameter("title", "text", title) };

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
                        error = "Категория уже существует";
                    else
                        error = "Smth wrong on category insert";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Категория создана. " + result;
        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите категорию");
                return;
            }
            if (!IsEveryFieldCorrect())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            string title = textBox_Title.Text;
            int category_id = Convert.ToInt32(label_id.Text);

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", category_id),
                                                               new Parameter("title", "text", title)};
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
                        error = "Категория уже существует";
                    else
                        error = "Smth wrong on category update";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Категория изменена. " + result;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_id.Text == "")
            {
                MessageBox.Show("Выберите категорию");
                return;
            }
            if (MessageBox.Show("Действительно удалить категорию (удалятся все связанные данные!)?",
                                    "Danger!",
                                    MessageBoxButtons.YesNo)
                                    == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            int category_id = Convert.ToInt32(label_id.Text);

            List<Parameter> parameters = new List<Parameter> { new Parameter("id", "int", category_id)};
            string result = "";
            try
            {
                result = Class_Helper.ExecuteFunction(conn, funcDelete, parameters);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                string error = "";
                //if (ex.Source == "Npgsql")
                //    if (((NpgsqlException)ex).Code == "P0001")
                //        error = "Категория уже существует";
                //    else
                error = "Smth wrong on category delete";
                MessageBox.Show(error);
                return;
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel.Text = "Категория удалена. " + result;
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
