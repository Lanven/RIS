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

        public Form_Countries(string connStr)
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
            dataGridView_Countries.AutoGenerateColumns = true;

            RefreshData();
            //dataGridView_Categories.Columns["id"].Visible = false;
            dataGridView_Countries.Columns["id"].HeaderText = "id";
            //dataGridView_Categories.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_Countries.Columns["name"].HeaderText = "Название";

            string query = "SELECT id from sb.countries";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            label_ServerB.Text = ((int)cmd.ExecuteScalar()).ToString();
        }

        private void RefreshData()
        {
            DataTable table = new DataTable();
            
            string query = "SELECT id, name FROM ( " +
                            "    SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "        'SELECT sa.countries.id, sa.countries.name " +
                            "        FROM sa.countries' ) as companies (id integer, name text) " +
                            "    UNION " +
                            "    SELECT sb.countries.id, sb.countries.name " +
                            "    FROM sb.countries) a " +
                            "ORDER BY 2; ";

            //string query = "SELECT id, name from sb.countries";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(table);
            dataGridView_Countries.DataSource = table;
        }

        private bool IsEveryFieldCorrect()
        {
            string name = textBox_Name.Text;
            if (name =="")
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

            string name = textBox_Name.Text;

            string tmp = "SELECT count(*) FROM ( " +
                            "    SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "        'SELECT sa.countries.id, sa.countries.name " +
                            "        FROM sa.countries' ) as countries (id integer, name text) " +
                            "    UNION " +
                            "    SELECT sb.countries.id, sb.countries.name " +
                            "    FROM sb.countries) a " +
                            " WHERE name LIKE :name";
            
            //string tmp = "select count(*) from sb.countries a where a.name LIKE :name";
            NpgsqlCommand tmpcmd = new NpgsqlCommand(tmp, conn);
            tmpcmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text).Value = name;

            if ((long)tmpcmd.ExecuteScalar() == 0)
            {
                try
                {
                    var cmdData = new Npgsql.NpgsqlCommand("func_countries_on_insert", conn);
                    cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdData.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text).Value = name;
                    cmdData.ExecuteNonQuery();
                    MessageBox.Show("Страна создана");
                    RefreshData();
                }
                catch
                {
                    MessageBox.Show("Smth wrong on country insert");
                }
            }
            else
            {
                MessageBox.Show("Страна с таким названием уже существует");
            }
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
            string name = textBox_Name.Text;
            int country_id = Convert.ToInt32(label_id.Text);
            
            string tmp = "SELECT count(*) FROM ( " +
                            "    SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru port=5432 user=risbd6 password=ris14bd6', " +
                            "        'SELECT sa.countries.id, sa.countries.name " +
                            "        FROM sa.countries' ) as countries (id integer, name text) " +
                            "    UNION " +
                            "    SELECT sb.countries.id, sb.countries.name " +
                            "    FROM sb.countries) a " +
                            " WHERE name LIKE :name";
            //string tmp = "select count(*) from sb.categories a where a.title LIKE :name AND a.id <> :id";
            NpgsqlCommand tmpcmd = new NpgsqlCommand(tmp, conn);
            tmpcmd.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text).Value = name;
            tmpcmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = country_id;

            if ((long)tmpcmd.ExecuteScalar() == 0)
            {
                try
                {
                    var cmdData = new Npgsql.NpgsqlCommand("func_countries_on_update", conn);
                    cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = country_id;
                    cmdData.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Text).Value = name;
                    cmdData.ExecuteNonQuery();
                    MessageBox.Show("Страна изменена");
                    RefreshData();
                }
                catch
                {
                    MessageBox.Show("Smth wrong on country update");
                }
            }
            else
            {
                MessageBox.Show("Страна с таким названием уже существует");
            }
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
            
            int country_id = Convert.ToInt32(label_id.Text);
            
            NpgsqlCommand tmpcmd = new NpgsqlCommand("func_search_companies_by_country", conn);
            tmpcmd.CommandType = System.Data.CommandType.StoredProcedure;
            tmpcmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = country_id;

            if ((int)tmpcmd.ExecuteScalar() == 0)
            {
                try
                {
                    var cmdData = new Npgsql.NpgsqlCommand("func_countries_on_delete", conn);
                    cmdData.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdData.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = country_id;
                    cmdData.ExecuteNonQuery();
                    MessageBox.Show("Страна удалена");
                    RefreshData();
                }
                catch
                {
                    MessageBox.Show("Smth wrong on country delete");
                }
            }
            else
            {
                MessageBox.Show("Невозможно удалить страну - есть связанные данные");
            }
        }

        private void Form_Countries_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
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
                    // IDBook = (int)dataGridView1["inventory_number", e.RowIndex].Value;
                    // Get mouse position relative to the vehicles grid
                    //var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);

                }
            }
        }
    }
}
