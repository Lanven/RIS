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

        public Form_Categories(string connStr)
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
            dataGridView_Categories.AutoGenerateColumns = true;

            RefreshData();
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Categories.Columns["id"].HeaderText = "id";
            //dataGridView_Categories.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_Categories.Columns["title"].HeaderText = "Название";
        }

        private void RefreshData()
        {
            DataTable table = new DataTable();
            string query = "SELECT id, title from sb.categories";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            try
            {
                da.Fill(table);
                dataGridView_Categories.DataSource = table;
            }
            catch 
            {
                MessageBox.Show("Cannot perform getting data");
            }
        }

        private void Form_Categories_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
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
                    //dataGridView1.CurrentCell = clickedCell;
                    dataGridView_Categories.Rows[row].Selected = true;
                    textBox_Title.Text = (string)dataGridView_Categories["title", row].Value;
                    label_id.Text = ((int)dataGridView_Categories["id", row].Value).ToString();
                    // IDBook = (int)dataGridView1["inventory_number", e.RowIndex].Value;
                    // Get mouse position relative to the vehicles grid
                    //var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);

                }
            }
        }

        private bool IsEveryFieldCorrect()
        {
            string title = textBox_Title.Text;
            if (title == "")
            {
                MessageBox.Show("Введите название");
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

            string title = textBox_Title.Text;

            string tmp = "select count(*) from sb.categories a where a.title LIKE :title";
            NpgsqlCommand tmpcmd = new NpgsqlCommand(tmp, conn);
            tmpcmd.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Text).Value = title;

            if ((long)tmpcmd.ExecuteScalar() == 0)
            {
                try
                {
                    var cmdData = new Npgsql.NpgsqlCommand("func_categories_on_insert", conn);
                    cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdData.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Text).Value = title;
                    cmdData.ExecuteNonQuery();
                    MessageBox.Show("Категория создана");
                    RefreshData();
                }
                catch
                {
                    MessageBox.Show("Smth wrong on category insert");
                }
            }
            else 
            {
                MessageBox.Show("Категория с таким названием уже существует");
            }
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
            string title = textBox_Title.Text;

            int category_id = Convert.ToInt32(label_id.Text);

            string tmp = "select count(*) from sb.categories a where a.title LIKE :title AND a.id <> :id";
            NpgsqlCommand tmpcmd = new NpgsqlCommand(tmp, conn);
            tmpcmd.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Text).Value = title;
            tmpcmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = category_id;

            if ((long)tmpcmd.ExecuteScalar() == 0)
            {
                try
                {
                    var cmdData = new Npgsql.NpgsqlCommand("func_categories_on_update", conn);
                    cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = category_id;
                    cmdData.Parameters.Add("title", NpgsqlTypes.NpgsqlDbType.Text).Value = title;
                    cmdData.ExecuteNonQuery();
                    MessageBox.Show("Категория изменена");
                    RefreshData();
                }
                catch
                {
                    MessageBox.Show("Smth wrong on category update");
                }
            }
            else
            {
                MessageBox.Show("Категория с таким названием уже существует");
            }
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

            int category_id = Convert.ToInt32(label_id.Text);
           
            try
            {
                var cmdData = new Npgsql.NpgsqlCommand("func_categories_on_delete", conn);
                cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = category_id;
                cmdData.ExecuteNonQuery();
                MessageBox.Show("Категория удалена");
                RefreshData();
            }
            catch
            {
                MessageBox.Show("Smth wrong on category delete");
            }
        }
    }
}
